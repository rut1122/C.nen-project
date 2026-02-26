using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Sale
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int RequiredAmount { get; set; }
        public double salePrice { get; set; }
        public bool onlyClub { get; set; }
        public DateTime beginSale { get; set; }
        public DateTime? endSale { get; set; }

        public override string ToString() => ToStringProperty();

    }
}
