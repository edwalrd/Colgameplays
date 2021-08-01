using Colgameplays.Dtos.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.UserDtos
{
   public class UserAdressDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public List<AddressDto> Address { get; set; }
     
    }
}
