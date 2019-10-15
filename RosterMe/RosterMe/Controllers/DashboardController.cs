using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RosterMe.Data;
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
        public async Task<ActionResult> Index(int? employeeID)
        {
            //Set & store query
            var employeeDetails = await _rosterMeContext.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == employeeID);

            //Check if employee's details are null
            if (employeeDetails == null)
            {
                //Return message
                return Content(LOG_TAG + ": The Employee details are null"
                );
            }
            else
            {
                //Return message
                return Content(LOG_TAG + ": The Employee details are not null" +
                    "\n- Employee Details query result: " + employeeDetails.EmployeeId
                );
            }

            //Return Index View
            //return View();
        }

        /* ---- GET Method: Employee Details List ---- */
        [HttpGet]
        public async Task<ActionResult> EmployeeList(int? employeeID)
        {
            //Set & store query
            var employeeDetails = await _rosterMeContext.Employees
                .Where(emp => emp.EmployeeId == employeeID)
                .OrderBy(emp => emp.FirstName)
                .Select(emp => new SelectListItem 
                {
                    Value = emp.EmployeeId.ToString(),
                    Text = emp.FirstName
                })
                .ToListAsync();

            //Check if employee's details are null
            if(employeeDetails == null)
            {
                //Return message
                return Content(LOG_TAG + ": The Employee details are null" +
                    "\n- Employee Details query result: " + employeeDetails.Count
                );
            }
            else
            {
                //Return message
                return Content(LOG_TAG + ": The Employee details are not null" +
                    "\n- Employee Details query result: " + employeeDetails.Count
                );
            }
        }
    }
}