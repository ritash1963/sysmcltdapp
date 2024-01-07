using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDto>> GetCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(string customerNUmber);
    }
}