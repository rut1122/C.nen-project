using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
        // נתיב לקובץ ה-XML
        readonly string filePath = @"..\xml\sales.xml";
        private XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sale>));

        // פונקציית עזר לשמירה לקובץ
        private void SaveAll(List<Sale> sales)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(sw, sales);
            }
        }

        public int Create(Sale item)
        {
            // קבלת מספר רץ אוטומטי מתוך הקונפיגורציה
            int index = Config.IndexSaleId;
            List<Sale> sales = ReadAll().ToList();

            // יצירת אובייקט חדש עם ה-ID שנוצר
            sales.Add(new Sale
            {
                id = index,
                productId = item.productId,
                RequiredAmount = item.RequiredAmount,
                salePrice = item.salePrice,
                onlyClub = item.onlyClub,
                beginSale = item.beginSale,
                endSale = item.endSale
            });

            SaveAll(sales);
            return index;
        }

        public void Delete(int id)
        {
            List<Sale> sales = ReadAll().ToList();
            Sale saleToDelete = sales.FirstOrDefault(s => s.id == id)
                ?? throw new Exceptions.DalIDExists("id is not found");

            sales.Remove(saleToDelete);
            SaveAll(sales);
        }

        public Sale? Read(int id)
        {
            var sales = ReadAll().ToList();
            Sale? sale = sales.FirstOrDefault(s => s.id == id);
            if (sale == null)
                throw new Exceptions.DalIDExists("id is not found");

            return sale;
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            var sales = ReadAll().ToList();
            Sale? sale = sales.FirstOrDefault(filter);
            if (sale == null)
                throw new Exceptions.DalIDExists("sale is not found");

            return sale;
        }

        public IEnumerable<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            if (!File.Exists(filePath)) return new List<Sale>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                var sales = xmlSerializer.Deserialize(sr) as List<Sale>;
                if (sales == null) return new List<Sale>();

                if (filter == null) return sales;
                return sales.Where(filter);
            }
        }

        public void Update(Sale item)
        {
            List<Sale> sales = ReadAll().ToList();

            // מציאת הפריט הקיים והסרתו
            Sale oldSale = sales.FirstOrDefault(s => s.id == item.id)
                ?? throw new Exceptions.DalIDExists("id is not found");

            sales.Remove(oldSale);

            // הוספת הפריט המעודכן
            sales.Add(item);

            // שמירה מחדש
            SaveAll(sales);
        }
    }
}