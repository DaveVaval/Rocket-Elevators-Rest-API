using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Data;
using System.Linq;
using System.IO;


namespace Rocket_Elevators_Rest_API.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public InterventionsController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        // GET Request for all Interventions that do not have a start Date and the status is Pending
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            var _intervention = await _context.interventions.ToListAsync();
            var interventionsList = new List<Interventions>(){};

            foreach(Interventions interventions in _intervention)
            {
                if(interventions.start_of_intervention == null && interventions.status == "Pending")
                {
                    interventionsList.Add(interventions);
                }
            }
            
            return interventionsList;
        }

        // PUT Request to change specified intervention status to In Progess or Completed
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<Interventions>> StartIntervention(long id, string status)
        {
            var intervention = await _context.interventions.FindAsync(id);
            intervention.status = status;

            if(status == "InProgress")
            {
                intervention.start_of_intervention = DateTime.Now;
                await _context.SaveChangesAsync();
                return intervention;
            }
            else if(status == "Completed")
            {
                intervention.end_of_intervention = DateTime.Now;
                await _context.SaveChangesAsync();
                return intervention;
            }

            return Ok("Invalid Endpoint!");
        }
        
        // This method will create an intervention
        [HttpPost("create")]
        public async Task<ActionResult<Interventions>> PostIntervention(Interventions intervention)
        {
            intervention.created_at = DateTime.Now;
            intervention.updated_at = DateTime.Now;
            _context.interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterventions", new { id = intervention.Id }, intervention);
        }

    }
}