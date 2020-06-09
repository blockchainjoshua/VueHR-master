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
    public class AttendanceConfigurationsController : Controller
    {
        private readonly VueHrContext _context;

        public AttendanceConfigurationsController(VueHrContext context)
        {
            _context = context;
        }

        // GET: AttendanceConfigurations
        public async Task<IActionResult> Index()
        {
            var vueHrContext = _context.AttendanceConfiguration.Include(a => a.Employee);
            return View(await vueHrContext.ToListAsync());
        }

        // GET: AttendanceConfigurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceConfiguration = await _context.AttendanceConfiguration
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceConfiguration == null)
            {
                return NotFound();
            }

            return View(attendanceConfiguration);
        }

        // GET: AttendanceConfigurations/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id");
            return View();
        }

        // POST: AttendanceConfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LateGracePeriod,NoLatesOrUndertime,RoundOffLates,TardinessMultiplier,UseTardinessBrackets,MaximumBreakTime,RequireLunchBreakAfter,EmployeeHasNoAbsent,RequiredWorkingHours,HalfDayIfTardinessReached,AbsentIfTardinessReached,AllowOffsettingOfOt,OvertimeMultiplier,AdditionalMinutesBeforeOt,AllowedTimeInEarlyOffset,StartOfScheduleOffset,EmployeeId")] AttendanceConfiguration attendanceConfiguration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendanceConfiguration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", attendanceConfiguration.EmployeeId);
            return View(attendanceConfiguration);
        }

        // GET: AttendanceConfigurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceConfiguration = await _context.AttendanceConfiguration.FindAsync(id);
            if (attendanceConfiguration == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", attendanceConfiguration.EmployeeId);
            return View(attendanceConfiguration);
        }

        // POST: AttendanceConfigurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LateGracePeriod,NoLatesOrUndertime,RoundOffLates,TardinessMultiplier,UseTardinessBrackets,MaximumBreakTime,RequireLunchBreakAfter,EmployeeHasNoAbsent,RequiredWorkingHours,HalfDayIfTardinessReached,AbsentIfTardinessReached,AllowOffsettingOfOt,OvertimeMultiplier,AdditionalMinutesBeforeOt,AllowedTimeInEarlyOffset,StartOfScheduleOffset,EmployeeId")] AttendanceConfiguration attendanceConfiguration)
        {
            if (id != attendanceConfiguration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendanceConfiguration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceConfigurationExists(attendanceConfiguration.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", attendanceConfiguration.EmployeeId);
            return View(attendanceConfiguration);
        }

        // GET: AttendanceConfigurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceConfiguration = await _context.AttendanceConfiguration
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceConfiguration == null)
            {
                return NotFound();
            }

            return View(attendanceConfiguration);
        }

        // POST: AttendanceConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendanceConfiguration = await _context.AttendanceConfiguration.FindAsync(id);
            _context.AttendanceConfiguration.Remove(attendanceConfiguration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceConfigurationExists(int id)
        {
            return _context.AttendanceConfiguration.Any(e => e.Id == id);
        }
    }
}
