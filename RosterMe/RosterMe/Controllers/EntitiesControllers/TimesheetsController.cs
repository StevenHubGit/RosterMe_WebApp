using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RosterMe.Data;
using RosterMe.Models.Entities;

namespace RosterMe.Controllers.EntitiesControllers
{
    public class TimesheetsController : Controller
    {
        //Class variables
        private readonly RosterMeContext _context;

        public TimesheetsController(RosterMeContext context)
        {
            _context = context;
        }

        //
        public IActionResult Index()
        {
            //Redirect to page
            return View();
        }

        // GET: Timesheets
        public async Task<IActionResult> TimesheetsManagement()
        {
            var rosterMeContext = _context.Timesheet.Include(t => t.Employee).Include(t => t.Shift);
            return View(await rosterMeContext.ToListAsync());
        }

        // GET: Timesheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheets = await _context.Timesheet
                .Include(t => t.Employee)
                .Include(t => t.Shift)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (timesheets == null)
            {
                return NotFound();
            }

            return View(timesheets);
        }

        // GET: Timesheets/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId");
            return View();
        }

        // POST: Timesheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceId,EmployeeId,TimeIn,TimeOut,AttendanceDate,ShiftId,ApprovalStatus")] Timesheets timesheets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timesheets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", timesheets.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", timesheets.ShiftId);
            return View(timesheets);
        }

        // GET: Timesheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheets = await _context.Timesheet.FindAsync(id);
            if (timesheets == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", timesheets.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", timesheets.ShiftId);
            return View(timesheets);
        }

        // POST: Timesheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceId,EmployeeId,TimeIn,TimeOut,AttendanceDate,ShiftId,ApprovalStatus")] Timesheets timesheets)
        {
            if (id != timesheets.AttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timesheets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimesheetsExists(timesheets.AttendanceId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", timesheets.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", timesheets.ShiftId);
            return View(timesheets);
        }

        // GET: Timesheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheets = await _context.Timesheet
                .Include(t => t.Employee)
                .Include(t => t.Shift)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (timesheets == null)
            {
                return NotFound();
            }

            return View(timesheets);
        }

        // POST: Timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timesheets = await _context.Timesheet.FindAsync(id);
            _context.Timesheet.Remove(timesheets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetsExists(int id)
        {
            return _context.Timesheet.Any(e => e.AttendanceId == id);
        }
    }
}
