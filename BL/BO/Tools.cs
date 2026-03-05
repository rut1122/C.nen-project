using System.Reflection;
using System.Text;
using BL.BO;

namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>(this T obj)
        {
            StringBuilder sb = new StringBuilder();
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(obj);
                if (value != null)//בודק שהאובייקט קיים
                {//בודק שזה באמת אוסף של אובייקטים
                    if (value is IEnumerable<object> enumerableValue)
                    {
                        sb.AppendLine($"{property.Name}: [{string.Join(", ", enumerableValue)}]");
                    }
                    else//מדפיס את הערך
                    {
                        sb.AppendLine($"{property.Name}: {value}");
                    }
                }
                else//אם הערך ריק
                {
                    sb.AppendLine($"{property.Name}: null");
                }
            }
            return sb.ToString();
        }
        //המרה 

        public static Customer ConvertCustomerToBO(DO.Customer customer)
        {
            return new Customer(customer.id, customer.name, customer.adress, customer.phone);
        }
        public static DO.Customer ConvertToCustomerDO(Customer customer)
        {
            return new DO.Customer(customer.id, customer.name, customer.adress, customer.phone);
        }
        public static Sale ConvertSaleToBO(DO.Sale sale)
        {
            return new Sale(sale.id, sale.productId, sale.RequiredAmount, sale.salePrice, sale.onlyClub, sale.beginSale, sale.endSale);
        }
        public static DO.Sale ConvertSaleToDO(Sale sale)
        {
            return new DO.Sale(sale.id, sale.productId, sale.requiredAmount, sale.salePrice, sale.onlyClub, sale.beginSale, sale.endSale);
        }
        public static Product ConvertProductToBO(DO.Product product)
        {
            return new Product(product.id, product.productName, (Category)product.productCategory, product.price, product.amount);
        }
        public static DO.Product ConvertProductToDO(Product product)
        {
            return new DO.Product(product.id, product.productName, (DO.Category)product.productCategory, product.price, product.amount);
        }
        public static SaleInProduct ConvertSaleToProductInsale(DO.Sale sale)
        {
            return new SaleInProduct(sale.id,sale.RequiredAmount,sale.salePrice,sale.onlyClub);
        }
    }
}
