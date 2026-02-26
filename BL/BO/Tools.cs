using System.Reflection;

namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>()
        {
            
        }
        //המרה 

        public static BO.Customer ConvertCustomerToBO(DO.Customer customer)
        {
            return new BO.Customer(customer.id, customer.name, customer.address, customer.phone);
        }

        public static DO.Customer ConvertToCustomerDO(BO.Customer customer)
        {
            return new DO.Customer(customer.id, customer.name, customer.address, customer.phone);
        }
        public static BO.Sale ConvertSaleToBO(DO.Sale sale)
        {
            return new BO.Sale(sale.id, sale.productId, sale.RequiredAmount, sale.salePrice, sale.onlyClub, sale.beginSale, sale.endSale);
        }
        public static DO.Sale ConvertSaleToDO(BO.Sale sale)
        {
            return new DO.Sale(sale.id, sale.productId, sale.RequiredAmount, sale.salePrice, sale.onlyClub, sale.beginSale, sale.endSale);
        }
        public static BO.Product ConvertProductToBO(DO.Product product)
        {
            return new BO.Product(product.id, product.productName, product.productCategory, product.price, product.amount, (BO.Category)product.category);
        }
        public static DO.Product ConvertProductToDO(BO.Product product)
        {
            return new DO.Product(product.id, product.product_name, (DO.Category)product.category, product.price, product.amount);
        }
    }
}
