using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    sealed internal class DalXml : IDal
    {
        private static readonly DalXml instance = new DalXml();

        public static DalXml Instance => instance;
        //בנאי
        private DalXml() { }

        public IProduct Product => new ProductImplementation();

        public ICustomer Customer => new CustomerImplementation();

        public ISale Sale => new SaleImplementation();
    }
}
