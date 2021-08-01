using Colgameplays.Model.Entities;
using Colgameplays.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Entities
{
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Address = new HashSet<Address>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Roles Role { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ShoppingSeccion ShoppingSeccion { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
