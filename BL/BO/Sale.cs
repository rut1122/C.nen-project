using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Sale
    {
        public int id;
        public int productId;
        public int RequiredAmount;
        public double salePrice;
        public bool onlyClub;
        public DateTime beginSale;
        public DateTime? endSale;

        public Sale(int id,int productId, int RequiredAmount, double salePrice, bool onlyClub
           DateTime beginSale, DateTime? endSale)
        {
            this.id = id;
            this.productId = productId;
            this.RequiredAmount = RequiredAmount;
            this.salePrice = salePrice;
            this.onlyClub = onlyClub;
            this.beginSale = beginSale;
            this.endSale = endSale;
        }
    }
}
