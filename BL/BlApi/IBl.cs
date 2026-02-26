using BL.BlApi;
using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {
        public IProduct Product {  get; }
        public ICustomer Customer { get; }
        public ISale Sale { get; }
        public IOrder Order { get; } 

            
    }
}
