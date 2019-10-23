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
    public class BookedShiftsController : Controller
    {
        //Class variables
        private readonly RosterMeContext _context;

        public BookedShiftsController(RosterMeContext context)
        {
            _context = context;
        }

        // GET: BookedShifts
        public async Task<IActionResult> Index()
        {
            var rosterMeContext = _context.BookedShifts.Include(b => b.Employee).Include(b => b.Shift);
            return View(await rosterMeContext.ToListAsync());
        }

        // GET: BookedShifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedShifts = await _context.BookedShifts
                .Include(b => b.Employee)
                .Include(b => b.Shift)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookedShifts == null)
            {
                return NotFound();
            }

            return View(bookedShifts);
        }

        // GET: BookedShifts/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId");
            return View();
        }

        // POST: BookedShifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,ShiftId,EmployeeId,BookedTime")] BookedShifts bookedShifts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookedShifts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", bookedShifts.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", bookedShifts.ShiftId);
            return View(bookedShifts);
        }

        // GET: BookedShifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedShifts = await _context.BookedShifts.FindAsync(id);
            if (bookedShifts == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", bookedShifts.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", bookedShifts.ShiftId);
            return View(bookedShifts);
        }

        // POST: BookedShifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,ShiftId,EmployeeId,BookedTime")] BookedShifts bookedShifts)
        {
            if (id != bookedShifts.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookedShifts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookedShiftsExists(bookedShifts.BookingId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", bookedShifts.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", bookedShifts.ShiftId);
            return View(bookedShifts);
        }

        // GET: BookedShifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedShifts = await _context.BookedShifts
                .Include(b => b.Employee)
                .Include(b => b.Shift)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookedShifts == null)
            {
                return NotFound();
            }

            return View(bookedShifts);
        }

        // POST: BookedShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookedShifts = await _context.BookedShifts.FindAsync(id);
            _context.BookedShifts.Remove(bookedShifts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookedShiftsExists(int id)
        {
            return _context.BookedShifts.Any(e => e.BookingId == id);
        }
    }
}
