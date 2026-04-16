using BlApi;
using BL.BO;
using System.Linq;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private readonly DalApi.IDal _dal = DalApi.Factory.Get;

        //עדכון המבצעים המתאימים למוצר בהזמנה

        public void SearchSaleForProduct(ProductInOrder product, bool existsCustomer)
        {
            var now = DateTime.Now;
            //שאילתה האם עונה על כל התנאים
            var salesQuery = from s in _dal.Sale.ReadAll()
                             where s.productId == product.Id
                             && s.beginSale <= now
                             && (s.endSale == null || s.endSale >= now)
                             && s.RequiredAmount <= product.Amount
                             select s;

            if (!existsCustomer)
            {
                salesQuery = salesQuery.Where(s => s.onlyClub == false);
            }
            //יצירת רשימה ממויינת לפי הדרישה
            product.SaleList = salesQuery
                .OrderBy(s => s.salePrice)
               .Select(s => BO.Tools.ConvertSaleToProductInsale(s))
               .ToList();

        }
        //הוספת מוצר להזמנה
        public List<SaleInProduct> AddPoductToOrder(int productId, int amount, BO.Order order)
        {
            try
            {
                //שליפה מהדאל
                var doProduct = _dal.Product.Read(productId) ?? throw new BO.BlNotExistsException("Product not found");
                //אם יש מספיק במלאי
                if (doProduct.amount < amount)
                    throw new BO.BlNotValidInputException("Not enough in stock");

                order.Products ??= new List<ProductInOrder>();
                //שליפת המזהה של המוצר המבוקש
                var existingProduct = order.Products?.FirstOrDefault(p => p.Id == productId);

                if (existingProduct != null)
                {
                    //אם יש מספיק במלאי
                    if (doProduct.amount < (existingProduct.Amount + amount))
                        throw new BO.BlNotValidInputException("Not enough in stock");

                    //עדכון הכמות של ה
                    existingProduct.Amount += amount;
                }
                else
                {
                    existingProduct = new ProductInOrder(doProduct.id, doProduct.productName
                        , doProduct.price, amount, new List<SaleInProduct>(), 0);
                    order.Products ??= new List<ProductInOrder>();
                    order.Products.Add(existingProduct);
                }

                SearchSaleForProduct(existingProduct, order.Favorite); // עדכון מבצעים
                CalcTotalPriceForProduct(existingProduct); // חישוב מחיר למוצר
                CalcTotalPrice(order); // עדכון מחיר כולל להזמנה

                // 4. החזרת הערך הנדרש
                return existingProduct.SaleList;
            }
            catch (DO.DalNotFound ex)
            {
                throw new BO.BlNotExistsException("product error in dal", ex);
            }
        }
        //חישוב מחיר סופי למוצר
        public void CalcTotalPriceForProduct(ProductInOrder product)
        {
            int count = product.Amount;
            double totalPrice = 0;
            product.FinalPrice = 0;
            List<SaleInProduct> salesForProduct = new List<SaleInProduct>();
            //עבור כל מבצע ברשימה
            foreach (var s in product.SaleList)
            {
                if (count < s.Amount)
                    continue;

                int sumTimesGetSale = (count / s.Amount);//כמה פעמים נכנס המבצע
                totalPrice += sumTimesGetSale * s.Price;//צבירת מחיר
                count -= (sumTimesGetSale * s.Amount);
                salesForProduct.Add(s);
                if (count == 0)
                    break;

            }
            totalPrice += (count * product.BasePrice);

            product.SaleList = salesForProduct;
            product.FinalPrice = totalPrice;//עדכון סופי
        }
        //חישוב מחיר סופי להזמנה
        public void CalcTotalPrice(BO.Order order)
        {
            double sumOrderPrice = 0;

            if (order?.Products != null)
                order.FinalPrice = order.Products.Sum(p => p.FinalPrice);

        }
        //ביצוע הזמנה
        public void DoOrder(BO.Order order)
        {
            if (order == null) throw new BO.BlNotValidInputException("order cannot be null");
            //האם קיימת רשימץ מוצרים
            bool hasProducts = (from p in order.Products select p).Any();
            if (!hasProducts)
                throw new BO.BlNotValidInputException("Cannot process an empty order.");
            //עבור כל מוצר
            foreach (var p in order.Products)
            {
                try
                {
                    //שליפת המזהה של המוצר הנוכחי
                    var doProduct = _dal.Product.Read(p.Id);

                    if (doProduct != null)
                    {
                        //עדכון הכמות במלאי
                        int newAmount = doProduct.amount - p.Amount;

                        if (newAmount < 0)
                            throw new BO.BlNotValidInputException($"Not enough stock for product: {doProduct.productName}");

                        // יצירת אובייקט מעודכן ושליחתו לעדכון בפונקציה
                        DO.Product updatedProduct = new DO.Product(
                            doProduct.id,
                            doProduct.productName,
                            doProduct.productCategory,
                            doProduct.price,
                            newAmount
                        );

                        _dal.Product.Update(updatedProduct);
                    }
                }
                catch (DO.DalNotFound ex)
                {
                    throw new BO.BlNotExistsException($"product with ID {p.Id} was not found", ex);
                }
            }


        }

    }
}
