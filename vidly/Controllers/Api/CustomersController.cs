using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using vidly.Data;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> Get()
        {
            var customers = await _context.Customers.ToListAsync();
            var customerDtos = customers.Select(_mapper.Map<Customer, CustomerDto>);
            return customerDtos;
        }

        // GET: api/Customers/5
        [HttpGet("{id:int}", Name = "Get")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                return NotFound();

            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            customerDto.Id = customer.Id;

            return CreatedAtAction(nameof(GetCustomer), new {id = customerDto.Id}, customerDto);
        }

        // PUT: api/Customers/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _mapper.Map(customerDto, customerInDb);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();


            _context.Customers.Remove(customerInDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
