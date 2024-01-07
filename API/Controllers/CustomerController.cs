using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Interfaces;
using API.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
         private readonly ICustomerRepository _repo;

         public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
        {
           return await _repo.GetCustomersAsync();
        }

        [HttpGet("{customerNumber}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(string customerNumber)
        {
           return await _repo.GetCustomerByIdAsync(customerNumber);
        }
    }
}