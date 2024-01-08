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

        [HttpPost("InsertNewCustomer")]
        public async Task<IActionResult> InsertNewCustomer(CustomerForInsertDto customerForInsertDto)
        {
           if (await _repo.CustomerExists(customerForInsertDto.CustomerNumber))
                return BadRequest("Customer already exists");

            var response = await _repo.InsertNewCustomer(customerForInsertDto);
            if (response)
              return StatusCode(201);
            else
              return StatusCode(500);  
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerForUpdateDto customerForUpdateDto)
        {
            var response = await _repo.UpdateCustomer(customerForUpdateDto);
            if (response)
              return NoContent();
            else
              return StatusCode(500);  
        }

        [HttpDelete("DeleteCustomer/{customerNumber}")]
        public async Task<IActionResult> DeleteCustomer(string customerNumber)
        {
            var response = await _repo.DeleteCustomer(customerNumber);
            if (response)
              return NoContent();
            else
              return StatusCode(500);  
        }

        [HttpGet("GetAddresses/{customerNumber}")]
        public async Task<ActionResult<CustomerDto>> GetAddresses(string customerNumber)
        {
           return Ok(await _repo.GetCustomerAddresses(customerNumber));
        }

        [HttpGet("GetContacts/{customerNumber}")]
        public async Task<ActionResult<CustomerDto>> GetContacts(string customerNumber)
        {
           return Ok(await _repo.GetCustomerContacts(customerNumber));
        }

    }
}