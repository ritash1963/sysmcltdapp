using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }   
    }
}