using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class SaleImplementation : ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Sale item)
        {
            // בדיקת תקינות בסיסית
            if (item.SalePrice <= 0) throw new BlNotValidInputException("Sale price must be positive");
            if (item.BeginSale > item.EndSale) throw new BlNotValidInputException("Start date cannot be after end date");

            try
            {
                return _dal.Sale.Create(Tools.ConvertSaleToDO(item));
            }
            catch (DO.Exceptions.DalIDExists ex)
            {
                throw new BlExistsException($"Sale with ID {item.Id} already exists", ex);
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
                throw new BlNotExistsException($"Sale {id} not found", ex);
            }
        }

        public BO.Sale? Read(int id)
        {
            try
            {
                var doSale = _dal.Sale.Read(id);
                return Tools.ConvertSaleToBO(doSale);
            }
            catch (DO.DalNotFound ex)
            {
                throw new BlNotExistsException($"Sale {id} not found", ex);
            }
        }

        public BO.Sale? Read(Func<BO.Sale, bool> filter)
        {
            // שימוש ב-ReadAll כדי להחיל את הפילטר על אובייקטים מסוג BO
            return ReadAll().FirstOrDefault(filter!);
        }

        public IEnumerable<BO.Sale> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            var sales = _dal.Sale.ReadAll()
                        .Select(doSale => Tools.ConvertSaleToBO(doSale));

            return filter == null ? sales : sales.Where(filter);
        }

        public void Update(BO.Sale item)
        {
            try
            {
                _dal.Sale.Update(Tools.ConvertSaleToDO(item));
            }
            catch (DO.DalNotFound ex)
            {
                throw new BlNotExistsException($"Sale {item.Id} not found for update", ex);
            }
        }
    }
}