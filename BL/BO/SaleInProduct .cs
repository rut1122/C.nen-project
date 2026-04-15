using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class SaleInProduct
    {
        public int Id {  get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public bool ForAllCustomers { get; set; }

        public override string ToString() => this.ToStringProperty();
        public SaleInProduct(int id, int amount, double price, bool forAllCustomers)
        {
            this.Id = id;
            this.Amount = amount;
            this.Price = price;
            this.ForAllCustomers = forAllCustomers;
        }
    }
}
