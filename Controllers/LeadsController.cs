using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Data;
using Rocket_Elevators_Rest_API.Models;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        //Create context attribute
        private readonly rocketelevators_developmentContext _context;
        //constructor 
        public LeadsController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        // Get list of leads                                    
        // GET: api/leads           
        [HttpGet]
        public async Task<dynamic> GetLeads()
        {
          
          return await _context.Leads.ToListAsync();

        }
        //Retrieving a list of Leads created in the last 30 days who have not yet become customers.
        [HttpGet("30daysnotcustomers")]
         public IEnumerable<Leads> GetLead()
         {
            //Set the date 
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(-30);
            //Prepare the query 
            IQueryable<Leads> day30snotcustomers =
            from l in _context.Leads
            where l.ContactRequestDate  >= answer
            select l;
            return day30snotcustomers.ToList();
         }               
    }
}