﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitkoCRM.Models;

namespace SitkoCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly CRMContainer _context;

        public ServicesController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Services>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Services>> GetServices(int id)
        {
            var services = await _context.Services.FindAsync(id);

            if (services == null)
            {
                return NotFound();
            }

            return services;
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServices(int id, Services services)
        {
            if (id != services.ServiceId)
            {
                return BadRequest();
            }

            _context.Entry(services).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult<Services>> PostServices(Services services)
        {
            _context.Services.Add(services);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServices", new { id = services.ServiceId }, services);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Services>> DeleteServices(int id)
        {
            var services = await _context.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            _context.Services.Remove(services);
            await _context.SaveChangesAsync();

            return services;
        }

        private bool ServicesExists(int id)
        {
            return _context.Services.Any(e => e.ServiceId == id);
        }
    }
}
