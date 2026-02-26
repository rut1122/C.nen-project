using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Product
    {
        public int id;
        public string productName;
        public Category? productCategory;
        public double price;
        public int amount;

        public Product(int id,string productName, Category? productCategory, double price, int amount)
        { 
            this.id = id;
            this.productName = productName;
            this.productCategory = productCategory;
            this.price = price;
            this.amount = amount;
        
        }

    }

}
