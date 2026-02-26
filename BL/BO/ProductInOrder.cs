using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class ProductInOrder
    {
        public int id{ get; set; }
        public string name { get; set; }
        public double basePrice { get; set; }
        public int amount { get; set; }
        public List<SaleInProduct> saleList { get; set; }
        public double finalPrice { get; set; }
    public override string ToString() => this.ToStringProperty();
    }
}
