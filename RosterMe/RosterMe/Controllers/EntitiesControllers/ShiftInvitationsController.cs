using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RosterMe.Classes;
using RosterMe.Data;
using RosterMe.Models.Entities;

namespace RosterMe.Controllers.EntitiesControllers
{
    public class ShiftInvitationsController : Controller
    {
        //Class variables
        private static String LOG_TAG = "Shift Invitations Controller class message";
        private readonly RosterMeContext _context;

        public ShiftInvitationsController(RosterMeContext context)
        {
            _context = context;
        }

        /* ---------- HTTP GET Methods ---------- */
        // GET: ShiftInvitations
        public async Task<IActionResult> Index()
        {
            //Set query & store result
            var rosterMeContext = _context.ShiftInvitation
                .Include(s => s.Employee)
                .Include(s => s.Shift);

            //Return View with List
            return View(await rosterMeContext.ToListAsync());
        }

        // GET: ShiftInvitations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //Check if input is null
            if (id == null)
            {
                return NotFound();
            }

            //Set query & store result
            var shiftInvitation = await _context.ShiftInvitation
                .Include(s => s.Employee)
                .Include(s => s.Shift)
                .FirstOrDefaultAsync(m => m.InvitationId == id);

            //Check if query result is null
            if (shiftInvitation == null)
            {
                return NotFound();
            }

            //Return View with result
            return View(shiftInvitation);
        }

        // GET: ShiftInvitations/Create
        public IActionResult Create()
        {
            //Store Employee & Shift Foreign Key
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId");

            //Return View
            return View();
        }

        // GET: ShiftInvitations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //Check if input is null
            if (id == null)
            {
                return NotFound();
            }

            //Set query & store result
            var shiftInvitation = await _context.ShiftInvitation.FindAsync(id);

            //Check if query result is null
            if (shiftInvitation == null)
            {
                return NotFound();
            }

            //Store Employee & Shift Foreign Key
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", shiftInvitation.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", shiftInvitation.ShiftId);
            
            //Return View with Collection of Shift Invitation
            return View(shiftInvitation);
        }

        // GET: ShiftInvitations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //Check if input is null
            if (id == null)
            {
                return NotFound();
            }

            //Set query & store result
            var shiftInvitation = await _context.ShiftInvitation
                .Include(s => s.Employee)
                .Include(s => s.Shift)
                .FirstOrDefaultAsync(m => m.InvitationId == id);

            //Check if query result is null
            if (shiftInvitation == null)
            {
                return NotFound();
            }

            //Return View with result
            return View(shiftInvitation);
        }

        [HttpGet]
        //[Route("~/Views/Dashboard/InviteEmployee?employeeID=empId")]
        public async Task<ActionResult> EmployeeInvitation(int? empID)
        {
            //Check if input is not null
            if (empID != null)
            {
                //Set query to retrieve all employee information & store result
                //Employee Invitation Information
                var employeeInvitationInfo = await _context.ShiftInvitation
                    .Include(sI => sI.Employee)
                    .Include(sI => sI.Shift)
                    .Where(sI => sI.EmployeeId == empID)
                    .FirstOrDefaultAsync();
                //Existing Shifts
                var existingShifts = await _context.Shift
                    //.Include(sI => sI.Shift)
                    //.Where(sI => sI.EmployeeId == empID)
                    .ToListAsync();
                //Existing Employees
                var existingEmployees = await _context.Employees
                    .Where(emp => emp.EmployeeId == empID)
                    .ToListAsync();
                //Shift invitations
                var shiftInvitations = await _context.ShiftInvitation
                    .Include(sI => sI.Employee)
                    .Include(sI => sI.Shift)
                    .ToListAsync();

                //Store query result in View Data
                ViewData["EmployeeInvitationInfo"] = employeeInvitationInfo;
                ViewData["ExistingShifts"] = existingShifts;
                ViewData["ExistingEmployees"] = existingEmployees;
                ViewData["ShiftInvitations"] = shiftInvitations;

                //Redirect to View
                return View("~/Views/ShiftInvitations/InviteEmployee.cshtml");

                /*
                //Print message
                return Content(LOG_TAG + ": Okay !" +
                    "\nThe Invite Employee function is reached" +
                    "\nThe input data is not null" +
                    "\n- Data: " + empID
                );
                */
            }
            else
            {
                //Print message
                return Content(LOG_TAG + ": Okay !" +
                    "\nThe Invite Employee function is reached" +
                    "\nThe input data is null"
                );
            }
        }

        /* ---------- HTTP POST Methods ---------- */
        // POST: ShiftInvitations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvitationId,EmployeeId,ShiftId,InvitationStatus,InvitationDate,NotificationStatus")] ShiftInvitation shiftInvitation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftInvitation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", shiftInvitation.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", shiftInvitation.ShiftId);
            return View(shiftInvitation);
        }

        // POST: ShiftInvitations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvitationId,EmployeeId,ShiftId,InvitationStatus,InvitationDate,NotificationStatus")] ShiftInvitation shiftInvitation)
        {
            if (id != shiftInvitation.InvitationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftInvitation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftInvitationExists(shiftInvitation.InvitationId))
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

            //Set View Datas
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", shiftInvitation.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", shiftInvitation.ShiftId);
            
            //Return to View
            return View(shiftInvitation);
        }

        // POST: ShiftInvitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shiftInvitation = await _context.ShiftInvitation.FindAsync(id);
            _context.ShiftInvitation.Remove(shiftInvitation);
            await _context.SaveChangesAsync();

            //Return View
            return RedirectToAction(nameof(Index));
        }

        /**
         * Invite Employee function:
         * This function takes the employee ID as a parameter.
         * The purpose of this function is to:
         * - Update the Shift Invitations table for the specified employee
         * - Insert a new row in the Booked Shifts table for the specified employee
         * 
         * To do so, the inputs retrieved from the form are stored and 
         * SQL queries are performed on both these tables using the employee ID.
         * */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InviteEmployee(int empID)
        {
            //Get & store inputs
            String employeeToInvite = HttpContext.Request.Form["employeeName"].ToString();
            String shiftToInvite = HttpContext.Request.Form["shiftName"].ToString();
            String invitationStatus = HttpContext.Request.Form["InvitationStatus"].ToString();
            DateTime invitationDate = DateTimeProperties.convertStringToDate(
                HttpContext.Request.Form["InvitationDate"].ToString());
            String notificationStatus = HttpContext.Request.Form["NotificationStatus"].ToString();

            //Check if inputs are not null
            if(employeeToInvite != null && shiftToInvite != null && invitationStatus != null &&
                invitationDate != null && notificationStatus != null)
            {
                //Retrieve data for CRUD operation
                String employeeIDAsString = StringProperties.splitStringByCharacter(
                    employeeToInvite, " - ", 0);
                String shiftIDAsString = StringProperties.splitStringByCharacter(
                    shiftToInvite, " - ", 0);

                //Declare integers to store IDs
                int employeeIDAsInt = 0;
                int shiftIDAsInt = 0;

                //Check if Strings contains numbers
                if(StringProperties.checkIfContainNumbers(employeeIDAsString) == true &&
                    StringProperties.checkIfContainNumbers(shiftIDAsString) == true)
                {
                    //Store number after check
                    employeeIDAsInt = Int32.Parse(StringProperties.splitStringByCharacter(
                        employeeIDAsString, " ", 0));
                    shiftIDAsInt = Int32.Parse(StringProperties.splitStringByCharacter(
                        shiftIDAsString, " ", 0));
                }

                //Query & store invitation ID
                int invitationID = _context.ShiftInvitation
                    .Where(sI => sI.EmployeeId == employeeIDAsInt)
                    //.Where(sI => sI.ShiftId == shiftIDAsInt)
                    .Select(sI => sI.InvitationId)
                    .FirstOrDefault();

                //Check if current Model is valid
                if (ModelState.IsValid)
                {
                    try
                    {
                        //Check input invitation status
                        if(invitationStatus == "Invited")
                        {
                            //Set SQL queries for tables
                            //Shift Invitations
                            _context.Database.ExecuteSqlCommand(@"Update dbo.ShiftInvitation " +
                                "Set ShiftId = {0}, " +
                                "InvitationStatus = {1}, " +
                                "InvitationDate = {2}, " +
                                "NotificationStatus = {3} " +
                                "Where EmployeeId = {4} " +
                                "And InvitationId = {5};",
                                shiftIDAsInt,
                                invitationStatus,
                                invitationDate,
                                notificationStatus,
                                employeeIDAsInt,
                                invitationID
                            );
                            //Booked Shifts
                            _context.Database.ExecuteSqlCommand(@"Insert Into dbo.BookedShifts " +
                                "(ShiftId, EmployeeId, BookedTime) " +
                                "Values ({0}, {1}, CURRENT_TIMESTAMP);",
                                shiftIDAsInt,
                                employeeIDAsInt
                            );

                            /*
                            //Print message
                            return Content(LOG_TAG + ": Data for queries" +
                                "\n- Shift ID: " + shiftIDAsInt +
                                "\n- Invitation Status: " + invitationStatus + 
                                "\n- Invitation Date: " + invitationDate +
                                "\n- Notification Status: " + notificationStatus +
                                "\n- Employee ID: " + employeeIDAsInt +
                                "\n- Invitation ID: " + invitationID
                            );
                            */
                        }
                        else
                        {
                            //Create instance of Shift Invitation
                            ShiftInvitation shiftInvitation = new ShiftInvitation
                            {
                                EmployeeId = employeeIDAsInt,
                                ShiftId = shiftIDAsInt,
                                InvitationDate = invitationDate,
                                InvitationStatus = invitationStatus,
                                NotificationStatus = notificationStatus
                            };

                            //Update row
                            _context.Update(shiftInvitation);

                            //Save changes made
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException dbe)
                    {
                        //Print error
                        return Content(LOG_TAG + ": Error !" +
                            "\nAn error occurred while trying to update employe shift invitation" +
                            "\n- Message: " + dbe.Message
                        );
                    }

                    //Return View
                    return RedirectToAction(nameof(Index));
                }

                //Return message
                return Content(LOG_TAG + ": Okay !" +
                    "\nThe inputs are not null" +
                    "\n- Employee: " + employeeIDAsInt +
                    "\n- Shift: " + shiftIDAsInt +
                    "\n- Invitation Status: " + invitationStatus +
                    "\n- Invitation Date: " + invitationDate +
                    "\n- Notification Status: " + notificationStatus
                );
            }
            else
            {
                //Return message
                return Content(LOG_TAG + ": Well..." +
                    "\n Some inputs are null"
                );
            }
        }

        private bool ShiftInvitationExists(int id)
        {
            return _context.ShiftInvitation.Any(e => e.InvitationId == id);
        }
    }
}
