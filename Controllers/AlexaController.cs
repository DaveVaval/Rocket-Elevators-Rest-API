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
    public class AlexaController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        //Constructor
        public AlexaController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<dynamic> GetAllData()
        {
            var elevators = 0;
            var buildings = 0;
            var customers = 0;
            var stopped = 0;
            var batteries = 0;
            var quotes = 0;
            var leads = 0;

            var elevatorList = await _context.Elevators.ToListAsync();
            var buildingList = await _context.Buildings.ToListAsync();
            var customerList = await _context.Customers.ToListAsync();
            var stoppedList =  from e in _context.Elevators where e.Status == "Stopped" select e;
            var batteryList = await _context.Batteries.ToListAsync();
            var quoteList = await _context.Quotes.ToListAsync();
            var leadList = await _context.Leads.ToListAsync();

            foreach(Elevators elevator in elevatorList){elevators++;}
            foreach(Buildings building in buildingList){buildings++;}
            foreach(Customers customer in customerList){customers++;}
            foreach(Elevators elevator in stoppedList){stopped++;}
            foreach(Batteries battery in batteryList){batteries++;}
            foreach(Quotes quote in quoteList){quotes++;}
            foreach(Leads lead in leadList){leads++;}

            var data = new 
            {
                elevators = elevators,
                buildings = buildings,
                customers = customers,
                stopped = stopped,
                batteries = batteries,
                quotes = quotes,
                leads = leads
            };

            return data;
        }
    }
}