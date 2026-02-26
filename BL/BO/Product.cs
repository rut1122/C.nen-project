using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Product
    {
        public int id { get; set; }
        public string productName { get; set; }
        public Category? productCategory { get; set; }
        public double price { get; set; }
        public int amount { get; set; }

        public override string ToString() => ToStringProperty();
    


    }

}
