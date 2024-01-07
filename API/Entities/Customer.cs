using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Entities 
{
    [Table("Customers")] 
    public class Customer :BaseEntity
    {  
        [Required]
        public string Name { get; set; }
        [Required]
        public string CustomerNumber { get; set; }
        public List<Address> Addresses { get; set; } = new();
        public List<Contact> Contacts { get; set; } = new();
    }
}