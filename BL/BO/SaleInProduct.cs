using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class SaleInProduct
    {
        public int id;
        public int amountToSale;
        public double price;
        public bool forAllCustomers;
        
        public SaleInProduct(int id ,int amount, double price, bool forAllCustomers)
        {
            this.id = id;
            this.amountToSale = amount;
            this.price = price;
            this.forAllCustomers = forAllCustomers;
        }



}                            