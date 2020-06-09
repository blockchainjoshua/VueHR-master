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
    public class JobRolesController : Controller
    {
        private readonly VueHrContext _context;

        public JobRolesController(VueHrContext context)
        {
            _context = context;
        }

        // GET: JobRoles
        public async Task<IActionResult> Index()
        {
            var vueHrContext = _context.JobRole.Include(j => j.Org);
            return View(await vueHrContext.ToListAsync());
        }

        // GET: JobRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobRole = await _context.JobRole
                .Include(j => j.Org)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobRole == null)
            {
                return NotFound();
            }

            return View(jobRole);
        }

        // GET: JobRoles/Create
        public IActionResult Create()
        {
            ViewData["OrgId"] = new SelectList(_context.Organization, "Id", "Name");
            return View();
        }

        // POST: JobRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrgId,Title,Description")] JobRole jobRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrgId"] = new SelectList(_context.Organization, "Id", "Name", jobRole.OrgId);
            return View(jobRole);
        }

        // GET: JobRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobRole = await _context.JobRole.FindAsync(id);
            if (jobRole == null)
            {
                return NotFound();
            }
            ViewData["OrgId"] = new SelectList(_context.Organization, "Id", "Name", jobRole.OrgId);
            return View(jobRole);
        }

        // POST: JobRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrgId,Title,Description")] JobRole jobRole)
        {
            if (id != jobRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobRoleExists(jobRole.Id))
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
            ViewData["OrgId"] = new SelectList(_context.Organization, "Id", "Name", jobRole.OrgId);
            return View(jobRole);
        }

        // GET: JobRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobRole = await _context.JobRole
                .Include(j => j.Org)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobRole == null)
            {
                return NotFound();
            }

            return View(jobRole);
        }

        // POST: JobRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobRole = await _context.JobRole.FindAsync(id);
            _context.JobRole.Remove(jobRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobRoleExists(int id)
        {
            return _context.JobRole.Any(e => e.Id == id);
        }
    }
}
