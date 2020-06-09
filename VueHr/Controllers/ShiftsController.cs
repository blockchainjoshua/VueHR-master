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
    public class ShiftsController : Controller
    {
        private readonly VueHrContext _context;

        public ShiftsController(VueHrContext context)
        {
            _context = context;
        }

        // GET: Shifts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shifts.ToListAsync());
        }

        // GET: Shifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shifts = await _context.Shifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shifts == null)
            {
                return NotFound();
            }

            return View(shifts);
        }

        // GET: Shifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,WorkDays,StartTime,EndTime,RestDay")] Shifts shifts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shifts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shifts);
        }

        // GET: Shifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shifts = await _context.Shifts.FindAsync(id);
            if (shifts == null)
            {
                return NotFound();
            }
            return View(shifts);
        }

        // POST: Shifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,WorkDays,StartTime,EndTime,RestDay")] Shifts shifts)
        {
            if (id != shifts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shifts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftsExists(shifts.Id))
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
            return View(shifts);
        }

        // GET: Shifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shifts = await _context.Shifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shifts == null)
            {
                return NotFound();
            }

            return View(shifts);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shifts = await _context.Shifts.FindAsync(id);
            _context.Shifts.Remove(shifts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftsExists(int id)
        {
            return _context.Shifts.Any(e => e.Id == id);
        }
    }
}
