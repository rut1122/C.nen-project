using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class SaleImplementation : ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(Sale item)
        {
            if (item.Id <= 0)
                throw new BO.BlNotValidInputException("Sale ID must be positive");
            try
            {
                return _dal.Sale.Create(BO.Tools.ConvertSaleToDO(item));
            }
            catch (DO.Exceptions.DalIDExists ex)
            {
                throw new BO.BlExistsException($"Sale with id {item.Id} already exists", ex);
            }
        }


        public void Delete(int id)
        {
            try
            {
                _dal.Sale.Delete(id);
            }
            catch (DO.DalNotFound ex)
            {
                throw new BO.BlNotExistsException("The sale does not exist", ex);
            }

        }

        public Sale? Read(int id)
        {
            try
            {
                return BO.Tools.ConvertSaleToBO(_dal.Sale.Read(id));
            }
            catch (DO.DalNotFound ex)
            {
                throw new BO.BlNotExistsException($"Sale with id {id} does not exist", ex);
            }
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            try
            {
                // המרה של ה-filter מ-BO ל-DO כדי שה-DAL יבין אותו
                return BO.Tools.ConvertSaleToBO(_dal.Sale.Read(doSale => filter(BO.Tools.ConvertSaleToBO(doSale)!)));
            }
            catch (DO.DalNotFound ex)
            {
                throw new BO.BlNotExistsException("Sale not found", ex);
            }
        }

        public IEnumerable<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            var sales = _dal.Sale.ReadAll()
                        .Select(doSale => (BO.Sale?)BO.Tools.ConvertSaleToBO(doSale));

            return filter == null ? sales : sales.Where(s => s != null && filter(s));
        }

        public void Update(Sale item)
        {
            if (item.Id <= 0)
                throw new BO.BlNotValidInputException("Sale ID must be positive");

            try
            {
                _dal.Sale.Update(BO.Tools.ConvertSaleToDO(item));
            }
            catch (DO.DalNotFound ex)
            {
                throw new BO.BlNotExistsException($"Sale with id {item.Id} does not exist", ex);
            }
        }
    }
}