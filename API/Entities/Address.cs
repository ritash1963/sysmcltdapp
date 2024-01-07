using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Entities 
{
    [Table("Addresses")] 
    public class Address : BaseEntity
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 
    }
}