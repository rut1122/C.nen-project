using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Category? ProductCategory { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public override string ToString() => this.ToStringProperty();
    
        public Product(int id, string productName, Category? productCategory, double price, int amount)
        {
            this.Id = id;
            this.ProductName = productName;
            this.ProductCategory = productCategory;
            this.Price = price;
            this.Amount = amount;
        }
        public Product() { }
    }

}
