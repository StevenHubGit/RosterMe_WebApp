using System;
using System.Collections.Generic;
using System.Globalization;
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
        int employeeID;

        public TimesheetsController(RosterMeContext context)
        {
            _context = context;
        }

        // GET: Timesheets
        public async Task<IActionResult> Index()
        {
            var employeeId = TempData["employeeId"];
            //Redirect to page
            var timesheet = await _context.Timesheets
                .Where(x => x.EmployeeId == Convert.ToInt32(employeeId)).ToListAsync();
            return View(timesheet);

            /*
            var rosterMeContext = _context.Timesheets.Include(t => t.Employee).Include(t => t.Shift);
            return View(await rosterMeContext.ToListAsync());
            */
        }

        //Timesheets for Admin
        public async Task<IActionResult> AdminTimesheet()
        {
            return View(await _context.Timesheets.ToListAsync());
        }

        // GET: Attendance Id
        public JsonResult GetAttendanceId()
        {
            var attendanceId = _context.Timesheets.OrderByDescending(x => x.EmployeeId).FirstOrDefault();
            return Json((attendanceId.EmployeeId) + 1);
        }

        //Add: Timesheet
        public JsonResult addTimesheet(Timesheets timesheet)
        {
            var message = "Oops!! Something went wrong!";
            using (_context)
            {
                if (timesheet != null)
                {
                    _context.Timesheets.Add(timesheet);
                    _context.SaveChanges();
                    message = "Records added successfully!";
                }
            }
            return Json(message);
        }

        //Get: Timesheet
        public JsonResult getTimesheetById(int? id)
        {
            var timesheet = _context.Timesheets.Find(id);
            string time = Convert.ToString(timesheet.TimeIn);
            DateTime datetime = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);
            var Timesheet = new Timesheets
            {
                AttendanceId = timesheet.AttendanceId,
                EmployeeId = timesheet.EmployeeId,
                ShiftId = timesheet.ShiftId,
                TimeIn = timesheet.TimeIn,
                TimeOut = timesheet.TimeOut,
                AttendanceDate = timesheet.AttendanceDate,
                ApprovalStatus = timesheet.ApprovalStatus
            };
            return Json(Timesheet);
        }

        public JsonResult deleteTimesheet(int? id)
        {
            var message = "Something Went Wrong!!";
            var timesheet = _context.Timesheets.Where(x => x.AttendanceId == id).FirstOrDefault();
            if (timesheet != null)
            {
                _context.Timesheets.Remove(timesheet);
                _context.SaveChanges();
                message = "Records deleted successfully!!";
            }
            return Json(message);
        }

        public JsonResult updateTimesheet(Timesheets timesheet)
        {
            var message = "Something went wrong!";
            using (_context)
            {
                _context.Entry(timesheet).State = EntityState.Modified;
                _context.SaveChanges();
                message = "Records updated successfully!!";
            }
            return Json(message);
        }

        public ActionResult List(string userRole, int employeeId)
        {
            employeeID = employeeId;
            TempData["employeeId"] = employeeId;
            if (userRole == "Admin")
            {
                return Json("/Timesheets/AdminTimesheet");
            }
            else if (userRole == "Employee")
            {

                return Json("/Timesheets/Index");
            }
            else if (userRole == "Manager")
            {
                return Json("/Timesheets/ManagerTimesheet");
            }
            return Json("/Timesheets/Index");
        }

        //Timesheet List for Manager
        public async Task<IActionResult> ManagerTimesheet()
        {
            return View(await _context.Timesheets.ToListAsync());
        }

        // GET: Timesheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheets = await _context.Timesheets
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

            var timesheets = await _context.Timesheets.FindAsync(id);
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

            var timesheets = await _context.Timesheets
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
            var timesheets = await _context.Timesheets.FindAsync(id);
            _context.Timesheets.Remove(timesheets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetsExists(int id)
        {
            return _context.Timesheets.Any(e => e.AttendanceId == id);
        }
    }
}
