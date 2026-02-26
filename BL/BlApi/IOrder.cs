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
        public List<SaleInProduct> AddPoductToOrder(int id, int amount,BO.Order order);
        public void CalcTotalPriceForProduct(ProductInOrder product);
        public void CalcTotalPrice(BO.Order order);
        public void DoOrder(BO.Order order);
        public void SearchSaleForProduct(ProductInOrder product,bool favorite);
    }
}
