using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Rest_API.Models;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Data;

using Pomelo.EntityFrameworkCore.MySql;



namespace Rocket_Elevators_Rest_API.Models.Controllers
{   [ApiController]
    [Route("api/[controller]")]
   
    public class BatteriesController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public BatteriesController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        // GET number of battery and building
        [HttpGet("numbers")]
        public async Task<dynamic> GetAllBatteries()
        {
            var buildings = await _context.Buildings.ToListAsync();
            var batteries = await _context.Batteries.ToListAsync();
            var i = 0;
            var j = 0;
            var numbers = new List<Int64>(){};

            foreach(Batteries battery in batteries)
            {
                i++;
            }
            numbers.Add(i);
            foreach(Buildings building in buildings)
            {
                j++;
            }
            numbers.Add(j);
            return numbers;
        }

        // GET: api/Batteries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Batteries>> GetBattery(long id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery;
        }

        
     [HttpPut("{id}")]
        public async Task<IActionResult> PutmodifyBatterisStatus(long id, [FromBody] Batteries body)
        {



            if (body.Status == null)
                return BadRequest();

            var battery = await _context.Batteries.FindAsync(id);
            battery.Status = body.Status;          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteriesExists(id))
                    return NotFound();
                else
                    throw;
            }

            return new OkObjectResult("success");
        }


        // GET: api/Batteries/{id}/status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetBatteryStatus( long id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery.Status;
        }

       // POST: api/Batteries/{id}/status
       [HttpPost]
        public async Task<ActionResult<Batteries>> PostBattery(Batteries battery)
        {
            _context.Batteries.Add(battery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattery", new { id = battery.Id }, battery);
        }

     
      // DELETE: Batteries
        [HttpDelete("{id}")]
        public async Task<ActionResult<Batteries>> DeleteBattery(int id)
        {
            var battery = await _context.Batteries.FindAsync(id);
            if (battery == null)
            {
                return NotFound();
            }

            _context.Batteries.Remove(battery);
            await _context.SaveChangesAsync();

            return battery;
        }

        private bool BatteriesExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }


        // Get all the batteries belonging to a specified building id
        [HttpGet("getbat/{buildingId}")]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetCustomerBuildins(string buildingId)
        {
            var _batteries = await _context.Batteries.ToListAsync();
            var batteryList = new List<Batteries>(){};

            foreach(Batteries battery in _batteries)
            {
                if(battery.BuildingId.ToString() == buildingId)
                {
                    batteryList.Add(battery);
                }
            }
            return batteryList;
        }


    }




    
}