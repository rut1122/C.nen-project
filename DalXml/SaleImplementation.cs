using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
       //מימוש מתדודות ICRUD

        public int Create(DO.Sale item)
        {
            // לוגיקה לשמירה ב-XML
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DO.Sale Read(int id)
        {
            throw new NotImplementedException();
        }

        public DO.Sale Read(Func<DO.Sale, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DO.Sale> ReadAll(Func<DO.Sale, bool>? filter = null)
        {
            // לוגיקה לקריאה מה-XML
            // כאן חשוב להשתמש ב-DO.Sale
            throw new NotImplementedException();
        }

        public void Update(DO.Sale item)
        {
            throw new NotImplementedException();
        }
    }
}