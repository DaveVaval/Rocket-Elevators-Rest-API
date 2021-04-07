using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Data;

namespace Rocket_Elevators_Rest_API.Models.Controllers
{
    [Route("api/Customers")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public CustomersController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Customers>> CheckCustomer(string email)
        {
            var _customers = await _context.Customers.ToListAsync();

            foreach(Customers customers in _customers)
            {
                if(customers.CompanyContactEmail == email)
                {
                    return customers;
                }
            }
            return Ok("bruh");  
        }
    }
}