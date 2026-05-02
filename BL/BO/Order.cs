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
        public bool IsClubMember { get; set; }
        public List<ProductInOrder> Products { get; set; }
        public double FinalPrice { get; set; }


        public override string ToString() => this.ToStringProperty();
     
        public Order(bool IsClubMember, List<ProductInOrder> products, double finalPrice)
        {
            this.IsClubMember = IsClubMember;
            this.Products = products;
            this.FinalPrice = finalPrice;
        }
        public Order() { Products = new List<ProductInOrder>(); }
    }
}
