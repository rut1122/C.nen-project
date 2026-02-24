namespace Dal;

using DalApi;
using DO;


//יצירת רשימות
internal static class DataSource
{
    internal static List<Product?> Products = new List<Product?>();
    internal static List<Sale?> Sales = new List<Sale?>();
    internal static List<Customer?> Customers = new List<Customer?>();
    //מאתחל את המספרים אוטומטי
    internal static class Config
    {
        internal const int ProductMinValue = 10;
        internal const int SaleMinValue = 20;

        private static int ProductIndex = ProductMinValue;
        private static int SaleIndex = SaleMinValue;

        public static int ProductCode
        {
            get
            {
              return  ProductIndex += 10;
            }
        }
        public static int SaleCode
        {
            get
            {
                return SaleIndex += 20;
            }
        }

    }


}
