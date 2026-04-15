using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Adress { get; set; }
        public int Phone { get; set; }


        public override string ToString() => this.ToStringProperty();
        public Customer(int id, string name, string? adress, int phone)
        {
            this.Id = id;
            this.Name = name;
            this.Adress = adress;
            this.Phone = phone;
        }
    }
}