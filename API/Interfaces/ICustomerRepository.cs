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
        Task<CustomerDto> GetCustomerByIdAsync(string customerNumber);
        Task<bool> InsertNewCustomer (CustomerForInsertDto customerForInsertDto);
        Task<bool> CustomerExists (string customerNumber);
        Task<bool> UpdateCustomer(CustomerForUpdateDto customerForUpdateDto);
        Task<bool> DeleteCustomer (string customerNumber);
        Task<List<AddressDto>> GetCustomerAddresses(string customerNumber);
        Task<List<ContactDto>> GetCustomerContacts(string customerNumber);
    }
}