using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;

using BlApi;
using BO; // מוודא שזה מכיר את ProductInOrder

namespace BlImplementation;

internal class ProductImplementation : IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Product item)
    {
        if (item.Id <= 0)
            throw new BO.BlNotValidInputException("product id must be positive");
        try
        {
            return _dal.Product.Create(BO.Tools.ConvertProductToDO(item));
        }
        catch (DO.Exceptions.DalIDExists ex)
        {
            throw new BO.BlExistsException($"product with id {item.Id} is already exist", ex);
        }
    }

    public BO.Product? Read(int id)
    {
        try
        {
            return BO.Tools.ConvertProductToBO(_dal.Product.Read(id));
        }
        catch (DO.DalNotFound ex)
        {
            throw new BO.BlNotExistsException($"product with id {id} does not exist", ex);
        }
    }

    public BO.Product? Read(Func<BO.Product, bool> filter)
    {
        try
        {
            return BO.Tools.ConvertProductToBO(_dal.Product.Read(doProd => filter(BO.Tools.ConvertProductToBO(doProd)!)));
        }
        catch (DO.DalNotFound ex)
        {
            throw new BO.BlNotExistsException("the product not found", ex);
        }
    }

    // שונה ל-BO.Product? כדי להתאים לממשק שלך
    public IEnumerable<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        var products = _dal.Product.ReadAll()
                        .Select(doProd => BO.Tools.ConvertProductToBO(doProd));

        return filter == null ? products : products.Where(p => p != null && filter(p));
    }

    public void Update(BO.Product item)
    {
        if (item.Id <= 0)
            throw new BO.BlNotValidInputException("product id must be positive");
        try
        {
            _dal.Product.Update(BO.Tools.ConvertProductToDO(item));
        }
        catch (DO.DalNotFound ex)
        {
            throw new BO.BlNotExistsException($"product with id {item.Id} does not exist", ex);
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
            throw new BO.BlNotExistsException("the product is not exist", ex);
        }
    }

    // מימוש מדויק לפי הממשק שלך: void ושם פרמטר favorite
    public void IsValid(ProductInOrder product, bool favorite)
    {
        if (product.Id <= 0)
            throw new BO.BlNotValidInputException("Invalid product id");
    }
}