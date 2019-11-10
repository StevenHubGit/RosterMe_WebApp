using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using RosterMe.Classes;
using RosterMe.Data;
using RosterMe.Models;
using RosterMe.Models.Entities;

namespace RosterMe.Controllers
{
    public class DashboardController : Controller
    {
        //Class variables
        private static String LOG_TAG = "Dashboard Controller class message";
        private RosterMeContext _rosterMeContext;
        private const String SessionName = "_Name";
        private const String SessionAge = "_Age";

        /* ---- Constructor --- */
        public DashboardController (RosterMeContext rosterMeContext)
        {
            //Initialize variables
            _rosterMeContext = rosterMeContext;
        }

        /* ---------- HTTP GET Methods ---------- */
        /* ---- GET Method: Index ---- */
        [HttpGet]
        [Route("Dashboard/Index/{employeeID}")]
        public async Task<IActionResult> Index(int employeeID)
        {
            //Return Index View
            return View("~/Views/Dashboard/Index.cshtml");
        }

        /* ---------- Dashboards ---------- */
        /* ---- Dashboard: Manager ---- */
        [HttpGet]
        [Route("Dashboard/ManagerDashboard/{employeeID}")]
        public async Task<ActionResult> ManagerDashboard(int employeeID)
        {
            //Set & store query
            var employeeDetails = await _rosterMeContext.Employees
                .Where(emp => emp.EmployeeId == employeeID)
                .OrderBy(emp => emp.FirstName)
                .ToListAsync();
            var employeeBookedShifts = await _rosterMeContext.BookedShifts
                .Include(bS => bS.Employee)
                .Include(bS => bS.Shift)
                //.Where(bS => bS.EmployeeId == employeeID)
                .OrderBy(bS => bS.Employee.LastName)
                .Take(5)
                .ToListAsync();
            var employeeAvailabilities = await _rosterMeContext.Availability
                .Include(avail => avail.Employee)
                //.Where(avail => avail.EmployeeId == employeeID)
                .OrderBy(avail => avail.Employee.LastName)
                .Take(5)
                .ToListAsync();

            //Create String to store logged in employee details
            String details = "";

            //Create variables to store data
            String employeeName = "";
            int employeeAge = 0;

            //Loop through employee details
            for(int i = 0; i < employeeDetails.Count(); i++)
            {
                //Store details
                details += "Employee ID: " + employeeDetails[i].EmployeeId +
                    "\n- Name: " + employeeDetails[i].FirstName + " " + employeeDetails[i].LastName +
                    "\n- DOB: " + employeeDetails[i].DOB +
                    "\n- Joining Date: " + employeeDetails[i].JoiningDate +
                    "\n- Position: " + employeeDetails[i].Position +
                    "\n- Role: " + employeeDetails[i].UserRole +
                    "\n- Reporting Manager ID: " + employeeDetails[i].ReportingManagerId +
                    "\n- Department ID: " + employeeDetails[i].DepartmentId
                    + "\n";

                //Store data
                employeeName = employeeDetails[i].FirstName + " " + employeeDetails[i].LastName;
                employeeAge = DateTimeProperties.calculateYearDifferenceBetweenDateTimes
                    (
                        employeeDetails[i].DOB,
                        DateTime.Now
                    );

                //Set Session
                HttpContext.Session.SetString(SessionName, employeeName);
                HttpContext.Session.SetInt32(SessionAge, employeeAge);
            }

            //Check if employee's details are null
            if(employeeDetails == null)
            {
                /*
                //Return message
                return Content(LOG_TAG + ": The Employee details are null" +
                    "\n- Employee Details query result: " + employeeDetails.Count
                );
                */
            }
            else
            {
                /*
                //Return message
                return Content(LOG_TAG + ": The Employee details are not null" +
                    "\n- Employee Details query result: " + employeeDetails.Count +
                    "\n\nEmployee details:" +
                    "\n" + details
                );
                */
            }

            //Store employee details in View Data
            ViewData["EmployeeDetails"] = employeeDetails;
            ViewData["EmployeeBookedShifts"] = employeeBookedShifts;
            ViewData["EmployeeAvailabilities"] = employeeAvailabilities;

            //Store employee details in Model
            var model = new Dashboard
            {
                Employees = employeeDetails
            };

            //Return View
            return View(model);
        }

        /* ---- Dashboard: Admin ---- */
        [HttpGet]
        [Route("Dashboard/AdminDashboard/{employeeID}")]
        public async Task<IActionResult> AdminDashboard(int employeeID)
        {
            //Set & store query
            var employeeDetails = await _rosterMeContext.Employees
                .Where(emp => emp.EmployeeId == employeeID)
                .OrderBy(emp => emp.FirstName)
                .ToListAsync();
            var employeeBookedShifts = await _rosterMeContext.BookedShifts
                .Include(bS => bS.Employee)
                .Include(bS => bS.Shift)
                .OrderBy(bS => bS.Employee.LastName)
                .Take(5)
                .ToListAsync();
            var employeeAvailabilities = await _rosterMeContext.Availability
                .Include(avail => avail.Employee)
                .OrderBy(avail => avail.Employee.LastName)
                .Take(5)
                .ToListAsync();
            var loggedInEmployees = await _rosterMeContext.LoginTrail
                .Include(lT => lT.LogIn)
                .OrderBy(lT => lT.LogIn.Username)
                .Take(5)
                .ToListAsync();
            var passwordRequests = await _rosterMeContext.PasswordRequest
                .Include(pR => pR.Login)
                .Include(pR => pR.Login.Employee)
                .OrderBy(pR => pR.Login.Username)
                .Take(5)
                .ToListAsync();

            //Create String to store logged in employee details
            String details = "";

            //Create variables to store data
            String employeeName = "";
            int employeeAge = 0;

            //Loop through employee details
            for (int i = 0; i < employeeDetails.Count(); i++)
            {
                //Store details
                details += "Employee ID: " + employeeDetails[i].EmployeeId +
                    "\n- Name: " + employeeDetails[i].FirstName + " " + employeeDetails[i].LastName +
                    "\n- DOB: " + employeeDetails[i].DOB +
                    "\n- Joining Date: " + employeeDetails[i].JoiningDate +
                    "\n- Position: " + employeeDetails[i].Position +
                    "\n- Role: " + employeeDetails[i].UserRole +
                    "\n- Reporting Manager ID: " + employeeDetails[i].ReportingManagerId +
                    "\n- Department ID: " + employeeDetails[i].DepartmentId
                    + "\n";

                //Store data
                employeeName = employeeDetails[i].FirstName + " " + employeeDetails[i].LastName;
                employeeAge = DateTimeProperties.calculateYearDifferenceBetweenDateTimes
                    (
                        employeeDetails[i].DOB,
                        DateTime.Now
                    );

                //Set Session
                HttpContext.Session.SetString(SessionName, employeeName);
                HttpContext.Session.SetInt32(SessionAge, employeeAge);
            }

            //Check if employee's details are null
            if (employeeDetails == null)
            {
                /*
                //Return message
                return Content(LOG_TAG + ": The Employee details are null" +
                    "\n- Employee Details query result: " + employeeDetails.Count
                );
                */
            }
            else
            {
                /*
                //Return message
                return Content(LOG_TAG + ": The Employee details are not null" +
                    "\n- Employee Details query result: " + employeeDetails.Count +
                    "\n\nEmployee details:" +
                    "\n" + details
                );
                */
            }

            //Store employee details in View Data
            ViewData["EmployeeDetails"] = employeeDetails;
            ViewData["EmployeeBookedShifts"] = employeeBookedShifts;
            ViewData["EmployeeAvailabilities"] = employeeAvailabilities;
            ViewData["LoggedInEmployees"] = loggedInEmployees;
            ViewData["PasswordRequests"] = passwordRequests;

            //Return View
            return View();
        }

        /* ---- Dashboard: Employee ---- */
        [HttpGet]
        [Route("Dashboard/EmployeeDashboard/{employeeID}")]
        public async Task<IActionResult> EmployeeDashboard(int employeeID)
        {
            //Set & store query
            var employeeDetails = await _rosterMeContext.Employees
                .Where(emp => emp.EmployeeId == employeeID)
                .OrderBy(emp => emp.FirstName)
                .ToListAsync();
            var employeeBookedShifts = await _rosterMeContext.BookedShifts
                .Include(bS => bS.Employee)
                .Include(bS => bS.Shift)
                //.Where(bS => bS.EmployeeId == employeeID)
                .OrderBy(bS => bS.Employee.LastName)
                .Take(5)
                .ToListAsync();
            var employeeAvailabilities = await _rosterMeContext.Availability
                .Include(avail => avail.Employee)
                //.Where(avail => avail.EmployeeId == employeeID)
                .OrderBy(avail => avail.AvailableDate)
                .Take(5)
                .ToListAsync();
            var loggedInEmployees = await _rosterMeContext.LoginTrail
                .Include(lT => lT.LogIn)
                .Where(lT => lT.LogIn.EmployeeId == employeeID)
                .OrderBy(lT => lT.LogIn.Username)
                .Take(5)
                .ToListAsync();
            var employeeLogin = await _rosterMeContext.Login
                .Include(log => log.Employee)
                .Where(log => log.Employee.EmployeeId == employeeID)
                .OrderBy(log => log.Employee.LastName)
                .Take(5)
                .ToListAsync();

            //Create String to store logged in employee details
            String details = "";

            //Create variables to store data
            String employeeName = "";
            int employeeAge = 0;

            //Loop through employee details
            for (int i = 0; i < employeeDetails.Count(); i++)
            {
                //Store details
                details += "Employee ID: " + employeeDetails[i].EmployeeId +
                    "\n- Name: " + employeeDetails[i].FirstName + " " + employeeDetails[i].LastName +
                    "\n- DOB: " + employeeDetails[i].DOB +
                    "\n- Joining Date: " + employeeDetails[i].JoiningDate +
                    "\n- Position: " + employeeDetails[i].Position +
                    "\n- Role: " + employeeDetails[i].UserRole +
                    "\n- Reporting Manager ID: " + employeeDetails[i].ReportingManagerId +
                    "\n- Department ID: " + employeeDetails[i].DepartmentId
                    + "\n";

                //Store data
                employeeName = employeeDetails[i].FirstName + " " + employeeDetails[i].LastName;
                employeeAge = DateTimeProperties.calculateYearDifferenceBetweenDateTimes
                    (
                        employeeDetails[i].DOB,
                        DateTime.Now
                    );

                //Set Session
                HttpContext.Session.SetString(SessionName, employeeName);
                HttpContext.Session.SetInt32(SessionAge, employeeAge);
            }

            //Check if employee's details are null
            if (employeeDetails == null)
            {
                /*
                //Return message
                return Content(LOG_TAG + ": The Employee details are null" +
                    "\n- Employee Details query result: " + employeeDetails.Count
                );
                */
            }
            else
            {
                /*
                //Return message
                return Content(LOG_TAG + ": The Employee details are not null" +
                    "\n- Employee Details query result: " + employeeDetails.Count +
                    "\n\nEmployee details:" +
                    "\n" + details
                );
                */
            }

            //Store employee details in View Data
            ViewData["EmployeeDetails"] = employeeDetails;
            ViewData["EmployeeBookedShifts"] = employeeBookedShifts;
            ViewData["EmployeeAvailabilities"] = employeeAvailabilities;
            ViewData["LoggedInEmployees"] = loggedInEmployees;
            ViewData["EmployeesLogin"] = employeeLogin;

            //Return View
            return View();
        }

        /* ---------- Redirections ---------- */
        /* ---- Redirect: Shift Invitations ---- */
        [HttpPost]
        public ActionResult InviteEmployeeToShift(int? employeeID)
        {
            //Check if input is not null
            if(employeeID != null)
            {
                //Redirect using Json
                return Json(new 
                { 
                    result = "Redirect", 
                    url = Url.Action("InviteEmployee", "ShiftInvitations", new { empID = employeeID}) 
                });

                /*
                //Print message
                return Json(LOG_TAG + ": Alright !" +
                    "\nThe Invite Employee To Shift function is reached" +
                    "\nThe data passed by Ajax is not null" +
                    "\n- Data: " + employeeID
                );
                */
            }
            else
            {
                //Print message
                return Json(LOG_TAG + ": Alright !" +
                    "\nThe Invite Employee To Shift function is reached" +
                    "\nThe data passed by Ajax is null"
                );
            }
        }
    }
}