using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; } 
        public bool IsDeleted { get; set; } 
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}