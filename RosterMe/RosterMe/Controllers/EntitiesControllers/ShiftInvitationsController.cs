using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            var rosterMeContext = _context.ShiftInvitation
                .Include(s => s.Employee)
                .Include(s => s.Shift);
            return View(await rosterMeContext.ToListAsync());
        }

        // GET: ShiftInvitations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftInvitation = await _context.ShiftInvitation
                .Include(s => s.Employee)
                .Include(s => s.Shift)
                .FirstOrDefaultAsync(m => m.InvitationId == id);
            if (shiftInvitation == null)
            {
                return NotFound();
            }

            return View(shiftInvitation);
        }

        // GET: ShiftInvitations/Create
        public IActionResult Create()
        {
            //Store Employee & Shift Foreign Key
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId");
            return View();
        }

        // GET: ShiftInvitations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Store Shift Invitation data
            var shiftInvitation = await _context.ShiftInvitation.FindAsync(id);

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
            if (id == null)
            {
                return NotFound();
            }

            var shiftInvitation = await _context.ShiftInvitation
                .Include(s => s.Employee)
                .Include(s => s.Shift)
                .FirstOrDefaultAsync(m => m.InvitationId == id);
            if (shiftInvitation == null)
            {
                return NotFound();
            }

            return View(shiftInvitation);
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", shiftInvitation.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", shiftInvitation.ShiftId);
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
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        //[Route("~/Views/Dashboard/InviteEmployee/{empId}")]
        public async Task<IActionResult> InviteEmployee(int? employeeID)
        {
            //Check if current model is valid
            if (ModelState.IsValid)
            {
                //
                if(employeeID != null)
                {
                    //Print message
                    return Content("\n" + LOG_TAG + ": Alright !" +
                        "\nThe data have been passed" +
                        "\n- Data: " + employeeID
                    );
                }
                else
                {
                    //Print message
                    return Content(LOG_TAG + ": Wait..." +
                        "\nThe data have not been passed"
                    );
                }
            }

            //Return View
            return View("~/Views/ShiftInvitations/Edit.cshtml");
        }

        private bool ShiftInvitationExists(int id)
        {
            return _context.ShiftInvitation.Any(e => e.InvitationId == id);
        }
    }
}
