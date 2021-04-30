using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Rest_API.Models;
using Rocket_Elevators_Rest_API.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    public class MobileController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        //Constructor
        public MobileController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult> CheckEmployee(string email)
        {
            IQueryable<Users> users = from u in _context.Users where u.Email == email select u;

            var user = await users.ToListAsync();

            IQueryable<Employees> employees = from e in _context.Employees where e.UserId == user[0].Id select e;

            var employee = await employees.ToListAsync();
            
            if(employee[0].FirstName != null)
                return Ok();
            
            return NotFound();
        }
    }
}