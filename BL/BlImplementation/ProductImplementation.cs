using System;
using System.Collections.Generic;
using System.Linq;
using BL.BO;
using BlApi;
using BO;

namespace BlImplementation
{
    public class ProductImplementation : IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Product item)
        {
            if (item.Id < 0) throw new BlNotValidInputException("ID must be positive");
            if (item.Price <= 0) throw new BlNotValidInputException("Price must be positive");

            try
            {
                return _dal.Product.Create(Tools.ConvertProductToDO(item));
            }
            catch (DO.Exceptions.DalIDExists ex)
            {
                throw new BlExistsException($"Product {item.Id} already exists", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Product.Delete(id);
            }
            catch (DO.DalNotFound ex)
            {
                throw new BlNotExistsException($"Product {id} not found for deletion", ex);
            }
        }

        public BO.Product? Read(int id)
        {
            try
            {
                return Tools.ConvertProductToBO(_dal.Product.Read(id));
            }
            catch (DO.DalNotFound ex)
            {
                throw new BlNotExistsException($"Product {id} not found", ex);
            }
        }

        public BO.Product? Read(Func<BO.Product, bool> filter)
        {
            return ReadAll().FirstOrDefault(filter!);
        }

        public IEnumerable<BO.Product> ReadAll(Func<BO.Product, bool>? filter = null)
        {
            var products = _dal.Product.ReadAll()
                           .Select(doProd => Tools.ConvertProductToBO(doProd));

            return filter == null ? products : products.Where(filter);
        }

        public void Update(BO.Product item)
        {
            if (item.Id <= 0) throw new BlNotValidInputException("Invalid ID for update");
            try
            {
                _dal.Product.Update(Tools.ConvertProductToDO(item));
            }
            catch (DO.DalNotFound ex)
            {
                throw new BlNotExistsException($"Product {item.Id} not found", ex);
            }
        }

        public void IsValid(ProductInOrder product, bool favorite)
        {
            var doProduct = _dal.Product.Read(product.Id);
            if (doProduct.amount < product.Amount)
                throw new BlNotValidInputException($"Not enough stock for {product.Name}");
        }
    }
}