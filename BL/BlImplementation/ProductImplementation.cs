using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.BlApi;

using System.Threading.Tasks;
namespace BlImplementation
{
    public class ProductImplementation :IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Product item)
        {
           
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void IsValid(ProductInOrder product, bool favorite)
        {
            throw new NotImplementedException();
        }

        public BO.Customer? Read(Func<BO.Customer, bool> filter)
        {
            try
            {
                return BO.Tools.ConvertCustomerToBO(_dal.Customer.Read(doSale => filter(BO.Tools.ConvertCustomerToBO(doSale))));
            }
            catch (DO.DalNotFound ex)
            { throw new BO.BlNotExistsException("the order not found", ex); }
        }

public BO.Product? Read(int id)
        {
            try
            {
                return BO.Tools.ConvertProductToBO(_dal.Product.Read(doSale => filter(BO.Tools.ConvertProductToBO(doSale))));
            }
            catch (DO.DalNotFound ex)
            { throw new BO.BlNotExistsException("the order not found", ex); }
        }

        public BL.BO.Product? Read(Func<BL.BO.Product, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BL.BO.Product?> ReadAll(Func<BL.BO.Product, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(BL.BO.Product item)
        {
            throw new NotImplementedException();
        }
    }
}
