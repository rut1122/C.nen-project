using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
        private static string filePath = @"../xml/data-config.xml";
        const string INDEX_PRODUCT_ID = "productNextNum";
        const string INDEX_SALE_ID = "saleNextNum";
        //        ד.במחלקת Config הוסיפו תכונה מקבילה לכל אלמנט בקובץ.
        //בפונקציה get של כל תכונה, החזירו את הערך המתאים מתוך הקובץ וקדמו אותו למספר הרץ הבא.
        private static XElement file;

        public static int IndexProductId
        {
            get
            {
                file = XElement.Load(filePath);
                int productId = int.Parse(file.Element(INDEX_PRODUCT_ID).Value);
                file.Element(INDEX_PRODUCT_ID).SetValue(productId + 1);
                file.Save(filePath);
                return productId;
            }
        }
        public static int IndexSaleId
        {
            get
            {
                file = XElement.Load(filePath);
                int saleId = int.Parse(file.Element(INDEX_SALE_ID).Value);
                file.Element(INDEX_SALE_ID).SetValue(saleId + 1);
                file.Save(filePath);
                return saleId;
            }

        }
}
