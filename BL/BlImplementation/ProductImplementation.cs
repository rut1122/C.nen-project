using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DO;
using BL.BlApi;

using System.Threading.Tasks;

namespace BlImplementation
{
    public class ProductImplementation :IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

    }
}
