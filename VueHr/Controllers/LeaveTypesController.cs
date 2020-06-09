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
    public class LeaveTypesController : Controller
    {
        private readonly VueHrContext _context;

        public LeaveTypesController(VueHrContext context)
        {
            _context = context;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var vueHrContext = _context.LeaveTypes.Include(l => l.JobRole);
            return View(await vueHrContext.ToListAsync());
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes
                .Include(l => l.JobRole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveTypes == null)
            {
                return NotFound();
            }

            return View(leaveTypes);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            ViewData["JobRoleId"] = new SelectList(_context.JobRole, "Id", "Title");
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobRoleId,Title,Description,TotalCredits,Id")] LeaveTypes leaveTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobRoleId"] = new SelectList(_context.JobRole, "Id", "Title", leaveTypes.JobRoleId);
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes.FindAsync(id);
            if (leaveTypes == null)
            {
                return NotFound();
            }
            ViewData["JobRoleId"] = new SelectList(_context.JobRole, "Id", "Title", leaveTypes.JobRoleId);
            return View(leaveTypes);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("JobRoleId,Title,Description,TotalCredits,Id")] LeaveTypes leaveTypes)
        {
            if (id != leaveTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypesExists(leaveTypes.Id))
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
            ViewData["JobRoleId"] = new SelectList(_context.JobRole, "Id", "Title", leaveTypes.JobRoleId);
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes
                .Include(l => l.JobRole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveTypes == null)
            {
                return NotFound();
            }

            return View(leaveTypes);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var leaveTypes = await _context.LeaveTypes.FindAsync(id);
            _context.LeaveTypes.Remove(leaveTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypesExists(short id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }
    }
}
