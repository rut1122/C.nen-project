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

    }
}
