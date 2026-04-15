using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class ProductInOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public int Amount { get; set; }
        public List<SaleInProduct> SaleList { get; set; }
        public double FinalPrice { get; set; }
        public override string ToString() => this.ToStringProperty();
        public ProductInOrder(int id, string name, double basePrice, int amount, List<SaleInProduct> saleList, double finalPrice)
        {
            this.Id = id;
            this.Name = name;
            this.BasePrice = basePrice;
            this.Amount = amount;
            this.SaleList = saleList;
            this.FinalPrice = finalPrice;
        }
    }
}
