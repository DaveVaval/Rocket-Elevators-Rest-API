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
    public class QuotesController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public QuotesController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        // GET all quotes
        [HttpGet]
        public async Task<dynamic> GetQuotes()
        {
            var quotes = await _context.Quotes.ToListAsync();
            return quotes;
        }
    }
}