using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;
using PortfolioProject.Models;

namespace PortfolioProject.wwwroot.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelanceProjectsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FreelanceProjectsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FreelanceProjectsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FreelanceProject>>> GetFreelanceProjects()
        {
            return await _context.FreelanceProjects.ToListAsync();
        }

        // GET: api/FreelanceProjectsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FreelanceProject>> GetFreelanceProject(int id)
        {
            var freelanceProject = await _context.FreelanceProjects.FindAsync(id);

            if (freelanceProject == null)
            {
                return NotFound();
            }

            return freelanceProject;
        }

        // PUT: api/FreelanceProjectsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreelanceProject(int id, FreelanceProject freelanceProject)
        {
            if (id != freelanceProject.Id)
            {
                return BadRequest();
            }

            _context.Entry(freelanceProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreelanceProjectExists(id))
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

        // POST: api/FreelanceProjectsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FreelanceProject>> PostFreelanceProject(FreelanceProject freelanceProject)
        {
            _context.FreelanceProjects.Add(freelanceProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFreelanceProject", new { id = freelanceProject.Id }, freelanceProject);
        }

        // DELETE: api/FreelanceProjectsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelanceProject(int id)
        {
            var freelanceProject = await _context.FreelanceProjects.FindAsync(id);
            if (freelanceProject == null)
            {
                return NotFound();
            }

            _context.FreelanceProjects.Remove(freelanceProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FreelanceProjectExists(int id)
        {
            return _context.FreelanceProjects.Any(e => e.Id == id);
        }
    }
}
