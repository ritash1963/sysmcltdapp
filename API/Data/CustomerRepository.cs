using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
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

        public async Task<CustomerDto> GetCustomerByIdAsync(string customerNumber)
        {
             var customer = await _context.Customers.Include(p => p.Addresses).Include(p => p.Contacts).FirstOrDefaultAsync(p => p.CustomerNumber == customerNumber);
             var customerToReturn = _mapper.Map<CustomerDto>(customer);
             return customerToReturn;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
             var customers = await _context.Customers.Include(p => p.Addresses).Include(p => p.Contacts).ToListAsync();
             var customersToReturn = _mapper.Map<List<CustomerDto>>(customers);
             return customersToReturn;
        }
    }
}