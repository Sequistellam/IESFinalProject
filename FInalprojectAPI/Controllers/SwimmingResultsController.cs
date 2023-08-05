using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FInalprojectAPI.Data;
using FInalprojectAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace FInalprojectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmingResultsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SwimmingResultsController> _logger;

        public SwimmingResultsController(ApplicationDbContext context, ILogger<SwimmingResultsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.User + "," + UserRoles.Manager + "," + UserRoles.Admin)]
        public async Task<ActionResult<IEnumerable<SwimmingResult>>> GetSwimmingResults()
        {
            var results = await _context.SwimmingResults.ToListAsync();
            _logger.LogInformation($"Fetched {results.Count} swimming results.");
            return results;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.User + "," + UserRoles.Manager + "," + UserRoles.Admin)]
        public async Task<ActionResult<SwimmingResult>> GetSwimmingResult(int id)
        {
            var swimmingResult = await _context.SwimmingResults.FindAsync(id);
            if (swimmingResult == null)
            {
                return NotFound();
            }
            return swimmingResult;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> PutSwimmingResult(int id, SwimmingResult swimmingResult)
        {
            if (id != swimmingResult.Id)
            {
                return BadRequest();
            }

            _context.Entry(swimmingResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SwimmingResultExists(id))
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

        [HttpPost]
        [Authorize(Roles = UserRoles.Manager + "," + UserRoles.Admin)]
        public async Task<ActionResult<SwimmingResult>> PostSwimmingResult(SwimmingResult swimmingResult)
        {
            _context.SwimmingResults.Add(swimmingResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSwimmingResult", new { id = swimmingResult.Id }, swimmingResult);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteSwimmingResult(int id)
        {
            var swimmingResult = await _context.SwimmingResults.FindAsync(id);
            if (swimmingResult == null)
            {
                return NotFound();
            }

            _context.SwimmingResults.Remove(swimmingResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SwimmingResultExists(int id)
        {
            return _context.SwimmingResults.Any(e => e.Id == id);
        }
    }
}
