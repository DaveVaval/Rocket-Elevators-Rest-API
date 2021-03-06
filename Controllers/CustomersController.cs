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
        public async Task<ActionResult<dynamic>> CheckCustomer(string email, string spec)
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

        // This enpoint will return a customer object with the specified email
        [HttpGet("{email}/object")]
        public async Task<ActionResult<Customers>> GetCustomer(string email)
        {
            var customers = await _context.Customers.ToListAsync();

            foreach(Customers customer  in customers)
            {
                if(customer.CompanyContactEmail == email)
                {
                    return customer;
                }
            }
            
            return Ok("Invalid email!");
        }
        
        // This will update the customer info
        [HttpPut("update")]
        public async Task<dynamic> Update([FromBody] Customers body)
        {
            var customer = await _context.Customers.FindAsync(body.Id);

            customer.CompanyName = body.CompanyName;
            customer.FullNameServiceTechnicalAuthority = body.FullNameServiceTechnicalAuthority;
            customer.TechnicalAuthorityEmail = body.TechnicalAuthorityEmail;
            customer.CompanyAddress = body.CompanyAddress;
            customer.CompanyContactPhone = body.CompanyContactPhone;
            customer.TechnicalAuthorityPhone = body.TechnicalAuthorityPhone;

            await _context.SaveChangesAsync();
            
            
            return new OkObjectResult("success");
        }
    }
}