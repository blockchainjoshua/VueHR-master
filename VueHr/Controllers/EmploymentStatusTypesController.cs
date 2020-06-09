using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VueHr.Models;

namespace VueHr.Controllers
{
    public class EmploymentStatusTypesController : Controller
    {
        private readonly VueHrContext _context;

        public EmploymentStatusTypesController(VueHrContext context)
        {
            _context = context;
        }

        // GET: EmploymentStatusTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmploymentStatusTypes.ToListAsync());
        }

        // GET: EmploymentStatusTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentStatusTypes = await _context.EmploymentStatusTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employmentStatusTypes == null)
            {
                return NotFound();
            }

            return View(employmentStatusTypes);
        }

        // GET: EmploymentStatusTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmploymentStatusTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] EmploymentStatusTypes employmentStatusTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employmentStatusTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employmentStatusTypes);
        }

        // GET: EmploymentStatusTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentStatusTypes = await _context.EmploymentStatusTypes.FindAsync(id);
            if (employmentStatusTypes == null)
            {
                return NotFound();
            }
            return View(employmentStatusTypes);
        }

        // POST: EmploymentStatusTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] EmploymentStatusTypes employmentStatusTypes)
        {
            if (id != employmentStatusTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employmentStatusTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmploymentStatusTypesExists(employmentStatusTypes.Id))
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
            return View(employmentStatusTypes);
        }

        // GET: EmploymentStatusTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentStatusTypes = await _context.EmploymentStatusTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employmentStatusTypes == null)
            {
                return NotFound();
            }

            return View(employmentStatusTypes);
        }

        // POST: EmploymentStatusTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employmentStatusTypes = await _context.EmploymentStatusTypes.FindAsync(id);
            _context.EmploymentStatusTypes.Remove(employmentStatusTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmploymentStatusTypesExists(int id)
        {
            return _context.EmploymentStatusTypes.Any(e => e.Id == id);
        }
    }
}
