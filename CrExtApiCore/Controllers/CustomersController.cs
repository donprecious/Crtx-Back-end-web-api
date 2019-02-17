using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CrExtApiCore.Models;
using CrExtApiCore.Repositories;
using AutoMapper;
using Entities;

namespace CrExtApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    [EnableCors("AllowOrigin")]
    public class CustomerController : Controller
    {
        private ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> Get(string id)
        {
            if (!await _customer.Find(id)) return NotFound("Customer not Found");
            var customer = await _customer.Get(id);
            return Ok(customer);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto customerDto)
        {
            if (customerDto == null) return NotFound();
            if (ModelState.IsValid)
            {
                var mapped = Mapper.Map<Customers>(customerDto);

                await _customer.Create(mapped);
                //
                if (!await _customer.Save())
                {
                    return StatusCode(500, "Server Error, Something went wrong with our server");
                }
                var created = Mapper.Map<Customers>(mapped);
                return CreatedAtRoute("GetCustomer", new { id = created.Id }, created);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}