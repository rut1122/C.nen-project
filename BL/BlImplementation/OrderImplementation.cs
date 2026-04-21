using BlApi;
using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private readonly DalApi.IDal _dal = DalApi.Factory.Get;

        // --- 1. חיפוש מבצעים למוצר ---
        public void SearchSaleForProduct(ProductInOrder product, bool isFavorite)
        {
            var now = DateTime.Now;

            // 1. שלפי את כל המבצעים שבתוקף עבור המוצר (בלי לבדוק כמות עדיין!)
            var salesQuery = from s in _dal.Sale.ReadAll()
                             where s.productId == product.Id
                             && s.beginSale <= now
                             && (s.endSale == null || s.endSale >= now)
                             select s;

            // 2. סינון מועדון
            if (!isFavorite)
            {
                salesQuery = salesQuery.Where(s => !s.onlyClub);
            }

            // 3. עדכון ה-DEBUG (עכשיו הוא ימצא את המבצע!)
            // במקום שורת ה-DEBUG הקודמת
            var allSales = _dal.Sale.ReadAll().ToList();
            Console.WriteLine($"--- DEBUG DAL CHECK ---");
            Console.WriteLine($"Looking for Product ID: {product.Id}");
            foreach (var s in allSales)
            {
                Console.WriteLine($"Sale in DAL: ID={s.id}, ProductId={s.productId}, Begin={s.beginSale}, End={s.endSale}");
            }
            Console.WriteLine($"Found {salesQuery.Count()} matches after filtering.");
            Console.WriteLine($"------------------------");
            // 4. המרה ושמירה במוצר
            product.SaleList = salesQuery
                .OrderBy(s => s.salePrice)
                .Select(s => BO.Tools.ConvertSaleToProductInsale(s))
                .ToList();
        }

        // --- 2. חישוב מחיר סופי למוצר (כולל כפל מבצעים) ---
        public void CalcTotalPriceForProduct(ProductInOrder product)
        {
            int remainingCount = product.Amount;
            double totalPrice = 0;
            List<SaleInProduct> appliedSales = new List<SaleInProduct>();

            // מעבר על המבצעים הממויינים מהזול ליקר
            foreach (var sale in product.SaleList)
            {
                if (remainingCount < sale.Amount) continue;

                int timesToApply = remainingCount / sale.Amount;
                totalPrice += timesToApply * (sale.Price*sale.Amount);
                remainingCount -= (timesToApply * sale.Amount);

                appliedSales.Add(sale);

                if (remainingCount == 0) break;
            }

            // הוספת היתרה לפי מחיר בסיס
            totalPrice += (remainingCount * product.BasePrice);

            product.SaleList = appliedSales;
            product.FinalPrice = totalPrice;
        }

        // --- 3. חישוב מחיר כולל להזמנה ---
        public void CalcTotalPrice(BO.Order order)
        {
            if (order?.Products != null)
            {
                order.FinalPrice = order.Products.Sum(p => p.FinalPrice);
            }
        }

        // --- 4. הוספת מוצר לסל (הזמנה) ---
        public List<SaleInProduct> AddPoductToOrder(int productId, int amount, BO.Order order)
        {
            try
            {
                // שליפה מהדאל לבדיקת מלאי ומחיר
                var doProduct = _dal.Product.Read(productId)
                    ?? throw new BO.BlNotExistsException($"Product {productId} not found");

                order.Products ??= new List<ProductInOrder>();
                var existingProduct = order.Products.FirstOrDefault(p => p.Id == productId);

                if (existingProduct != null)
                {
                    // בדיקה מול המלאי ב-DAL (כמות קיימת בסל + כמות חדשה)
                    if (doProduct.amount < (existingProduct.Amount + amount))
                        throw new BO.BlNotValidInputException($"Not enough in stock. You already have {existingProduct.Amount} in cart, and there are only {doProduct.amount} total.");
                    existingProduct.Amount += amount;
                }
                else
                {
                    if (doProduct.amount < amount)
                        throw new BO.BlNotValidInputException($"Not enough in stock. Only {doProduct.amount} available.");

                    existingProduct = new ProductInOrder(doProduct.id, doProduct.productName,
                        doProduct.price, amount, new List<SaleInProduct>(), 0);
                    order.Products.Add(existingProduct);
                }

                // עדכון לוגיקה פנימית של המוצר וההזמנה
                SearchSaleForProduct(existingProduct, order.Favorite);
                CalcTotalPriceForProduct(existingProduct);
                CalcTotalPrice(order);

                return existingProduct.SaleList;
            }
            catch (DO.DalNotFound ex)
            {
                throw new BO.BlNotExistsException("DAL Error", ex);
            }
        }

        // --- 5. ביצוע הזמנה סופי (עדכון המדפים ב-DAL) ---
        public void DoOrder(BO.Order order)
        {
            if (order == null) throw new BO.BlNotValidInputException("Order cannot be null");

            if (order.Products == null || !order.Products.Any())
                throw new BO.BlNotValidInputException("Cannot process an empty order.");

            // מעבר על כל המוצרים שנבחרו והפחתתם מהמלאי האמיתי
            foreach (var item in order.Products)
            {
                try
                {
                    var doProduct = _dal.Product.Read(item.Id);
                    int newStock = doProduct.amount - item.Amount;

                    if (newStock < 0)
                        throw new BO.BlNotValidInputException($"Insufficient stock for: {doProduct.productName}");

                    // יצירת אובייקט DAL חדש עם המלאי המעודכן
                    DO.Product updatedProduct = new DO.Product(
                        doProduct.id,
                        doProduct.productName,
                        doProduct.productCategory,
                        doProduct.price,
                        newStock
                    );

                    // עדכון ה-DAL
                    _dal.Product.Update(updatedProduct);
                }
                catch (DO.DalNotFound ex)
                {
                    throw new BO.BlNotExistsException($"Product {item.Id} not found in database during final checkout", ex);
                }
            }
            // הערה: כאן כדאי להוסיף קריאה ל-_dal.Order.Create(order) כדי לשמור את היסטוריית ההזמנה
        }
    }
}