using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Customer : EntityBase
    {
        public Customer() { }
        public Customer(string _email, string _name, string _phoneNumber) {
            EMail = _email;
            Name = _name;
            PhoneNumber = _phoneNumber;
        }
        public string EMail { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
