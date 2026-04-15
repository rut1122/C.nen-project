using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool Favorite { get; set; }
        public List<ProductInOrder> Products { get; set; }
        public double FinalPrice { get; set; }


        public override string ToString() => this.ToStringProperty();
     
        public Order(bool favorite, List<ProductInOrder> products, double finalPrice)
        {
            this.Favorite = favorite;
            this.Products = products;
            this.FinalPrice = finalPrice;
        }
    }
}
