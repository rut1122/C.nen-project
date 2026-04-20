using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class Bl : IBl
    {
        public ICustomer Customer => new CustomerImplementation();
        public IProduct Product => new ProductImplementation();
        public IOrder Order => new OrderImplementation();
        public BlApi.ISale Sale => new BlImplementation.SaleImplementation();
    }
}
