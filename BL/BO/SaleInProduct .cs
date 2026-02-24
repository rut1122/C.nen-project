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
        public int amount;
        public double price;
        public bool forAllCustomers;

        public SaleInProduct(int id,int amount, double price, bool forAllCustomers)

        {
            this.id = id;
            this.amount = amount;
            this.price = price;
            this.forAllCustomers = forAllCustomers;
        }

    }
}
