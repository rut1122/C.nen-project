using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Customer
    {
        public int id;
        public string name;
        public string? adress;
        public int phone;


        public Customer(int id,string name, string? adress,int phone)
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
            this.phone = phone;
        }
    }
   
}
