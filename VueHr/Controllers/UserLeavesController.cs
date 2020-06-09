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
    public class UserLeavesController : Controller
    {
        private readonly VueHrContext _context;

        public UserLeavesController(VueHrContext context)
        {
            _context = context;
        }

        // GET: UserLeaves
        public async Task<IActionResult> Index()
        {
            var vueHrContext = _context.UserLeaves.Include(u => u.Employee).Include(u => u.LeaveType);
            return View(await vueHrContext.ToListAsync());
        }

        // GET: UserLeaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeaves = await _context.UserLeaves
                .Include(u => u.Employee)
                .Include(u => u.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLeaves == null)
            {
                return NotFound();
            }

            return View(userLeaves);
        }

        // GET: UserLeaves/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Lastname");
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Title");
            return View();
        }

        // POST: UserLeaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,LeaveTypeId,IsPaid,IsApproved,DateFiled,Start,End,Hours,Remarks,Attachment,ApprovedBy")] UserLeaves userLeaves)
        {
            if (ModelState.IsValid)
            {
                userLeaves.DateFiled = DateTime.Now;

                TimeSpan? ts = userLeaves.End - userLeaves.Start;
                userLeaves.Hours = (decimal)ts.Value.TotalHours;
                userLeaves.IsApproved = false;


                _context.Add(userLeaves);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Lastname", userLeaves.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Title", userLeaves.LeaveTypeId);
            return View(userLeaves);
        }

        // GET: UserLeaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeaves = await _context.UserLeaves.FindAsync(id);
            if (userLeaves == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Lastname", userLeaves.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Title", userLeaves.LeaveTypeId);
            return View(userLeaves);
        }

        // POST: UserLeaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,LeaveTypeId,IsPaid,IsApproved,DateFiled,Start,End,Hours,Remarks,Attachment,ApprovedBy")] UserLeaves userLeaves)
        {
            if (id != userLeaves.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLeaves);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLeavesExists(userLeaves.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Lastname", userLeaves.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Title", userLeaves.LeaveTypeId);
            return View(userLeaves);
        }

        // GET: UserLeaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeaves = await _context.UserLeaves
                .Include(u => u.Employee)
                .Include(u => u.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLeaves == null)
            {
                return NotFound();
            }

            return View(userLeaves);
        }

        // POST: UserLeaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userLeaves = await _context.UserLeaves.FindAsync(id);
            _context.UserLeaves.Remove(userLeaves);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLeavesExists(int id)
        {
            return _context.UserLeaves.Any(e => e.Id == id);
        }
    }
}
