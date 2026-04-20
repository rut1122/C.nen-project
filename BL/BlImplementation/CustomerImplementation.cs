using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation;

internal class CustomerImplementation : ICustomer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;


    public int Create(BO.Customer item)
    {
        if (item.Id <= 0)
            throw new BO.BlNotValidInputException("customer id must be positive");

        try
        {
            return _dal.Customer.Create(BO.Tools.ConvertCustomerToDO(item));
        }
        catch (DO.Exceptions.DalIDExists ex)
        {
            throw new BO.BlExistsException($"customer with id {item.Id} is already exist",ex);
        }

    }

    public void Delete(int id)
    {
        try
        {
            _dal.Customer.Delete(id);
        }
        catch (DO.DalNotFound ex)
        {
            throw new BO.BlNotExistsException("the customer is not exist", ex);
        }
    }
    public BO.Customer? Read(int id)
    {
        try
        {
            return BO.Tools.ConvertCustomerToBO(_dal.Customer.Read(id));
        }
        catch (DO.DalNotFound ex)
        {
            throw new BO.BlNotExistsException($"customer with id {id} does not exist", ex);
        }
    }


    public BO.Customer? Read(Func<BO.Customer, bool> filter)
    {
        try
        {
            return BO.Tools.ConvertCustomerToBO(_dal.Customer.Read(doCustomer => filter(BO.Tools.ConvertCustomerToBO(doCustomer)!)));
        }
        catch (DO.DalNotFound ex)
        { throw new BO.BlNotExistsException("the customer not found", ex); }
    }


    public IEnumerable<BO.Customer> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        

            var customers = _dal.Customer.ReadAll()
                            .Select(doCust => BO.Tools.ConvertCustomerToBO(doCust)!);

            //return filter==null?customers:customers.Where(filter);
        return filter == null ? customers : customers.Where(p => p != null && filter(p));
    }

    public void Update(BO.Customer item)
    {
        if (item.Id <= 0)
            throw new BO.BlNotValidInputException("customer id must be positive");
        try
        {

            _dal.Customer.Update(BO.Tools.ConvertCustomerToDO(item));

        }
        catch (DO.DalNotFound ex)
        {
            throw new BO.BlNotExistsException($"customer with id {item.Id} does not exist", ex);
        }
    }

    public bool IsCustomerExist(int id)
    {
        try
        {

            return _dal.Customer.Read(id) != null;

        }
        catch (DO.DalNotFound ex)
        {
            return false;
        }

    }
}
