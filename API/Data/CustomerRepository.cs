using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CustomerRepository : ICustomerRepository
    { 
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CustomerExists(string customerNumber)
        {
            if (await _context.Customers.AnyAsync(x => x.CustomerNumber == customerNumber && !x.IsDeleted))
                return true;

            return false;
        }

        public async Task<bool> DeleteCustomer(string customerNumber)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(p => p.CustomerNumber == customerNumber && !p.IsDeleted);
            if (customer == null) return false;
            customer.IsDeleted = true;
            if (await _context.SaveChangesAsync() > 0)
              return true;
            else
              return false; 
        }

        public async Task<List<AddressDto>> GetCustomerAddresses(string customerNumber)
        {
            List<AddressDto> addresses = new();
            var customer = await _context.Customers.Include(p => p.Addresses)
               .FirstOrDefaultAsync(p => p.CustomerNumber == customerNumber && !p.IsDeleted);
              foreach (var rec in customer.Addresses)
              {
                AddressDto address = new();
                address.City = rec.City;
                address.Street = rec.Street;
                address.Id = rec.Id;
                address.CustomerId = rec.CustomerId;
                addresses.Add(address);
              }
            return addresses;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(string customerNumber)
        {
             var customer = await _context.Customers.Include(p => p.Addresses).Include(p => p.Contacts)
               .FirstOrDefaultAsync(p => p.CustomerNumber == customerNumber && !p.IsDeleted);
             var customerToReturn = _mapper.Map<CustomerDto>(customer);
             return customerToReturn;
        }

        public async Task<List<ContactDto>> GetCustomerContacts(string customerNumber)
        {
            List<ContactDto> contacts = new();
            var customer = await _context.Customers.Include(p => p.Contacts)
               .FirstOrDefaultAsync(p => p.CustomerNumber == customerNumber && !p.IsDeleted);
              foreach (var rec in customer.Contacts)
              {
                ContactDto contact = new();
                contact.FullName = rec.FullName;
                contact.OfficeNumber = rec.OfficeNumber;
                contact.Email = rec.Email;
                contact.Id = rec.Id;
                contact.CustomerId = rec.CustomerId;
                contacts.Add(contact);
              }
            return contacts;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
             var customers = await _context.Customers.Where(p => !p.IsDeleted).Include(p => p.Addresses).Include(p => p.Contacts).ToListAsync();
             var customersToReturn = _mapper.Map<List<CustomerDto>>(customers);
             return customersToReturn;
        }

        public async Task<bool> InsertNewCustomer(CustomerForInsertDto customerForInsertDto)
        {
            var customerForInsert = new Customer
            {
                Name = customerForInsertDto.Name,
                CustomerNumber = customerForInsertDto.CustomerNumber,
            };
            var customerAddress = new Address
            {
                City = customerForInsertDto.City,
                Street = customerForInsertDto.Street
            };
            var customerContact = new Contact
            {
                 FullName = customerForInsertDto.FullName,
                 Email = customerForInsertDto.Email,
                 OfficeNumber = customerForInsertDto.OfficeNumber
            }; 
            customerForInsert.Addresses.Add(customerAddress);
            customerForInsert.Contacts.Add(customerContact);

            await _context.Customers.AddAsync(customerForInsert);
            if (await _context.SaveChangesAsync() > 0)
              return true;
            else
              return false;  
        }

        public async Task<bool> UpdateCustomer(CustomerForUpdateDto customerForUpdateDto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(p => p.CustomerNumber == customerForUpdateDto.CustomerNumber && !p.IsDeleted);
            if (customer == null) return false;
            customer.Name = customerForUpdateDto.Name;
            if (await _context.SaveChangesAsync() > 0)
              return true;
            else
              return false;     
        }
    }
}