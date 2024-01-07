using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
        // public List<AddressDto> Addresses { get; set; }
        // public List<ContactDto> Contacts { get; set; } 
    }
}