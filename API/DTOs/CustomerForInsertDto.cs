using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CustomerForInsertDto
    {
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string FullName { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
    }
}