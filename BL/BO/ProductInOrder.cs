using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class ProductInOrder
    {
        public int id;
        public string name;
        public double basePrice;
        public int amount;
        public List<SaleInProduct> saleList;
        public double finalPrice;
    }
}
