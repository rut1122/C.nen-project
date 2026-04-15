using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DO;
using BL.BlApi;
using BlApi;

namespace BlImplementation
{
    internal class CustomerImplementation:ICustomer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

    }
}
