using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class SaleInProduct
    {
        public int id {  get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public bool forAllCustomers { get; set; }

        public override string ToString() => this.ToStringProperty();
        public SaleInProduct(int id, int amount, double price, bool forAllCustomers)
        {
            this.id = id;
            this.amount = amount;
            this.price = price;
            this.forAllCustomers = forAllCustomers;
        }
    }
}
