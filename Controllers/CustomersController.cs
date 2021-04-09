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
        // Get Request that will return the customer email or customer id with the specified endpoint and argument
        [HttpGet("{email}/{spec}")]
        public async Task<ActionResult<string>> CheckCustomer(string email, string spec)
        {
            var _customers = await _context.Customers.ToListAsync();

            foreach(Customers customers in _customers)
            {
                if(customers.CompanyContactEmail == email)
                {
                    if(spec == "user")
                    {
                        return customers.CompanyContactEmail;
                    }
                    else if(spec == "id")
                    {
                        return customers.Id.ToString();
                    }
                }
            }
            return Ok("bruh");  
        }

    }
}