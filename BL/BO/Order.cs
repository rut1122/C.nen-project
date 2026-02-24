using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Order
    {
        public bool favorite;
        public List<ProductInOrder> products;
        public double finalPrice;


        public Order(bool favorite, List<ProductInOrder> products, double finalPrice)
        {
            this.favorite = favorite;
            this.products = products;
            this.finalPrice = finalPrice;
        }
    }
}
