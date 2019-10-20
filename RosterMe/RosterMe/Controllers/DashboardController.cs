using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }

        /* ---- GET Method: Employee Details List ---- */
        [HttpGet]
        [Route("Dashboard/EmployeeList/{employeeID}")]
        public async Task<ActionResult> EmployeeList(int employeeID)
        {
            //Set & store query
            var employeeDetails = await _rosterMeContext.Employees
                .Where(emp => emp.EmployeeId == employeeID)
                .OrderBy(emp => emp.FirstName)
                .ToListAsync();

            //Create String to store logged in employee details
            String details = "";

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
            var model = new Dashboard
            {
                Employee = employeeDetails
            };

            //Return View
            return View(model);
        }
    }
}