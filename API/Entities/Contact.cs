using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Entities 
{
    [Table("Contacts")] 
    public class Contact : BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}