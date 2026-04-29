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
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }


        public override string ToString() => this.ToStringProperty();
        public Customer(int id, string name, string? address, string? email, int phone)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
        }
    }
}