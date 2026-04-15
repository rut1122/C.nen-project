using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BlApi;

namespace BlImplementation
{
    internal class SaleImplementation:ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BL.BO.Sale item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BL.BO.Sale? Read(int id)
        {
            throw new NotImplementedException();
        }

        public BL.BO.Sale? Read(Func<BL.BO.Sale, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BL.BO.Sale?> ReadAll(Func<BL.BO.Product, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(BL.BO.Sale item)
        {
            throw new NotImplementedException();
        }
    }
}
