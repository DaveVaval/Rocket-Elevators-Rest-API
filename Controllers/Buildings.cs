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
{
    [Route("api/Buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public BuildingsController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        // GET: api/buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        // GET number of Buildings
        [HttpGet("number")]
        public async Task<dynamic> GetBuildingNumber()
        {
            var buildings = await _context.Buildings.ToListAsync();
            var i = 0;
            foreach(Buildings building in buildings){i++;}
            return i;
        }
        
        // Retrieving a list of Buildings requiring intervention 
       [HttpGet("Intervention")]
        public ActionResult<List<Buildings>> GetToFixBuildings()
        {
            IQueryable<Buildings> ToFixBuildingsList = from bat in _context.Buildings
            join Batteries in _context.Batteries on bat.Id equals Batteries.BuildingId 
            join Columns in _context.Columns on Batteries.Id equals Columns.BatteryId
            join Elevators in _context.Elevators on Columns.Id equals Elevators.ColumnId
            where (Batteries.Status == "Intervention") || (Columns.Status == "Intervention") || (Elevators.Status == "Intervention")
            select bat;
            return ToFixBuildingsList.Distinct().ToList();
        }

        // Get all the building belonging to a specified customer id
        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetCustomerBuildins(string customerId)
        {
            var _buildings = await _context.Buildings.ToListAsync();
            var buildingList = new List<Buildings>(){};

            foreach(Buildings buildings in _buildings)
            {
                if(buildings.CustomerId.ToString() == customerId)
                {
                    buildingList.Add(buildings);
                }
            }
            return buildingList;
        }
       
    }
}