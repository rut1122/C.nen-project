using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlApi
{
    public interface IOrder
    {
        public List<SaleInProduct> AddPoductToOrder(int id, int amount);
        public void CalcTotalPriceForProduct(ProductInOrder product);
        public void CalcTotalPrice(ProductInOrder product);
        public void DoOrder(IOrder order);
        public void SearchSaleForProduct(ProductInOrder product,bool favorite);
    }
}
