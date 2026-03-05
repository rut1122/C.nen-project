using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using BL.BlApi;
using BL.BO;
using DalApi;
using System.Diagnostics;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private readonly IDal dal = Factory.Get;

        //עדכון המבצעים המתאימים למוצר בהזמנה

        public void SearchSaleForProduct(ProductInOrder product, bool existsCustomer)
        {
            var now = DateTime.Now;
            //שאילתה האם עונה על כל התנאים
            var sales = from s in dal.Sale.ReadAll()
                        where s.productId == product.id
                        && s.beginSale <= now
                        && s.endSale == null || s.endSale >= now
                        && s.RequiredAmount <= product.amount
                        select s;
           
            if (!existsCustomer)
            {
                sales = sales.Where(s => s.onlyClub == false);
            }
            //יצירת רשימה ממויינת לפי הדרישה
            product.saleList = sales
                .OrderBy(s => s.salePrice)
               .Select(s => BO.Tools.ConvertSaleToProductInsale(s))
               .ToList();

        }
        //הוספת מוצר להזמנה
        public List<SaleInProduct> AddPoductToOrder(int productId, int amount, Order order)
{
            //שליפה מהדאל
            var doProduct = dal.Product.Read(productId) ?? throw new Exception("Product not found");
            //אם יש מספיק במלאי
            if (doProduct.amount < amount)
                throw new Exception("Not enough in stock");
            //שליפת המזהה של המוצר המבוקש
            var existingProduct = order.products?.FirstOrDefault(p => p.id == productId);

            if (existingProduct != null)
            {
                //אם יש מספיק במלאי
                if (doProduct.amount < (existingProduct.amount + amount))
                    throw new Exception("Not enough in stock");
                //עדכון הכמות של ה
                existingProduct.amount += amount;
            }
            else
            {
                // 2. תיקון תחביר: השלמת הפרמטרים החסרים בבנאי (רשימת מבצעים ריקה ומחיר התחלתי)
                existingProduct = new ProductInOrder(doProduct.id, doProduct.productName
                    , doProduct.price, amount, new List<SaleInProduct>(), 0);
                order.products ??= new List<ProductInOrder>();
                order.products.Add(existingProduct);
            }

            //// 3. הוספת החלק החסר: הפעלת הלוגיקה שבנינו בשלבים הקודמים!
            //SearchSaleForProduct(existingProduct, order.CustomerName != null); // עדכון מבצעים
            //CalcTotalPriceForProduct(existingProduct); // חישוב מחיר למוצר
            //CalcTotalPrice(order); // עדכון מחיר כולל להזמנה

            // 4. החזרת הערך הנדרש
            return existingProduct.saleList;
        }
        //חישוב מחיר סופי למוצר
        public void CalcTotalPriceForProduct(ProductInOrder product)
        {
            int count = product.amount;
            double totalPrice = 0;
            List<SaleInProduct> salesForProduct = new List<SaleInProduct>();
            //עבור כל מבצע ברשימה
            foreach (var s in product.saleList)
            {
                if (count < s.amount)
                    continue;

                int sumTimesGetSale = (count / s.amount);
                totalPrice = sumTimesGetSale * s.price;
                count -= sumTimesGetSale;
                product.finalPrice += sumTimesGetSale;
                salesForProduct.Add(s);
                if (count == 0)
                    break;

            }
            totalPrice += (count * product.basePrice);

            product.saleList = salesForProduct;
            product.finalPrice += totalPrice;
        }
        //חישוב מחיר סופי להזמנה
        public void CalcTotalPrice(Order order)
        {
            double sumOrderPrice = 0;
            if (order != null)
            {
                foreach (var p in order.products)
                {
                    sumOrderPrice += p.finalPrice;
                }
            }
            order.finalPrice = sumOrderPrice;
        }
        //ביצוע הזמנה
        public void DoOrder(Order order)
        {
       //האם קיימת רשימץ מוצרים
            if (order.products == null || !order.products.Any())
                throw new Exception("Cannot process an empty order.");

//עבור כל מוצר
            foreach (var p in order.products)
            {
              //שליפת המזהה של המוצר הנוכחי
                var doProduct = dal.Product.Read(p.id);

                if (doProduct != null)
                {
                    //עדכון הכמות במלאי
                    int newAmount = doProduct.amount - p.amount;

                    // יצירת אובייקט מעודכן ושליחתו לעדכון בפונקציה
                    DO.Product updatedProduct = new DO.Product(
                        doProduct.id,
                        doProduct.productName,
                        doProduct.productCategory,
                        doProduct.price,
                        newAmount
                    );

                    dal.Product.Update(updatedProduct);
                }
            }

      
        }

    }
}
