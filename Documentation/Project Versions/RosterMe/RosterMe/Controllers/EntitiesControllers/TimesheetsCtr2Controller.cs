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
using RosterMe.Classes;

namespace RosterMe.Controllers.EntitiesControllers
{
    public class TimesheetsController : Controller
    {
        //Class variables
        private readonly RosterMeContext _context;
        int employeeID ;

        public TimesheetsController(RosterMeContext context)
        {
            _context = context;
        }

        public ActionResult List(string userRole,int employeeId)
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
            return View(await _context.Timesheet.ToListAsync());
        }

        //Timesheet List for Employees
        public async Task<IActionResult> Index()
        {
            var employeeId = TempData["employeeId"];
            //Redirect to page
            var timesheet =await _context.Timesheet.Where(x => x.EmployeeId == Convert.ToInt32(employeeId)).ToListAsync();
            return View(timesheet);
        }

        //Timesheets for Admin
        public async Task<IActionResult> AdminTimesheet()
        {
            return View(await _context.Timesheet.ToListAsync());
        }

        // GET: Attendance Id
        public JsonResult GetAttendanceId()
        {
            var attendanceId = _context.Timesheet.OrderByDescending(x => x.EmployeeId).FirstOrDefault();
            return Json((attendanceId.EmployeeId)+1);
        }

        //Add: Timesheet
        public JsonResult addTimesheet(Timesheets timesheet)
        {
            var message = "Oops!! Something went wrong!";
            using (_context)
            {
                if(timesheet!=null)
                {
                    _context.Timesheet.Add(timesheet);
                    _context.SaveChanges();
                    message = "Records added successfully!";
                }
            }
                return Json(message);
        }

        //Get: Timesheet
        public JsonResult getTimesheetById(int? id)
        {
            var timesheet = _context.Timesheet.Find(id);
            string time =Convert.ToString(timesheet.TimeIn);
            DateTime datetime = DateTime.ParseExact(time,"HH:mm:ss",CultureInfo.InvariantCulture);
            var Timesheet = new Timesheets
            {
                AttendanceId=timesheet.AttendanceId,
                EmployeeId=timesheet.EmployeeId,
                ShiftId=timesheet.ShiftId,
                TimeIn=timesheet.TimeIn,
                TimeOut=timesheet.TimeOut,
                AttendanceDate=timesheet.AttendanceDate,
                ApprovalStatus=timesheet.ApprovalStatus
            };
            return Json(Timesheet);
        }

        public JsonResult deleteTimesheet(int? id)
        {
            var message = "Something Went Wrong!!";
            var timesheet = _context.Timesheet.Where(x => x.AttendanceId == id).FirstOrDefault();
            if (timesheet != null)
            {
                _context.Timesheet.Remove(timesheet);
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
    }
}
