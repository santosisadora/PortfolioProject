using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class FreelanceProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FreelanceProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FreelanceProjects
        public async Task<IActionResult> Index()
        {
            
            return View("Index",await _context.FreelanceProjects.ToListAsync());
        }

        // GET: FreelanceProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelanceProject = await _context.FreelanceProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freelanceProject == null)
            {
                return NotFound();
            }

            return View(freelanceProject);
        }

        // GET: FreelanceProjects/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: FreelanceProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Theme,ProjectDespription,ExpectedDate,FirstName,LastName,Email,PhoneNumber")] FreelanceProject freelanceProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freelanceProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            _context.Add(freelanceProject);
            await _context.SaveChangesAsync();
            return View(freelanceProject);
        }

        // GET: FreelanceProjects/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelanceProject = await _context.FreelanceProjects.FindAsync(id);
            if (freelanceProject == null)
            {
                return NotFound();
            }
            return View(freelanceProject);
        }

        // POST: FreelanceProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Theme,ProjectDespription,ExpectedDate,FirstName,LastName,Email,PhoneNumber")] FreelanceProject freelanceProject)
        {
            if (id != freelanceProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freelanceProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreelanceProjectExists(freelanceProject.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(freelanceProject);
        }

        // GET: FreelanceProjects/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelanceProject = await _context.FreelanceProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freelanceProject == null)
            {
                return NotFound();
            }

            return View(freelanceProject);
        }

        // POST: FreelanceProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freelanceProject = await _context.FreelanceProjects.FindAsync(id);
            _context.FreelanceProjects.Remove(freelanceProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreelanceProjectExists(int id)
        {
            return _context.FreelanceProjects.Any(e => e.Id == id);
        }
    }
}
