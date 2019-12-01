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
    public class PasswordRequestsController : Controller
    {
        //Class variables
        private readonly RosterMeContext _context;

        /**
         * Constructor
         * */
        public PasswordRequestsController(RosterMeContext context)
        {
            _context = context;
        }

        /* ---------- HTTP GET Methods ---------- */
        // GET: PasswordRequests
        public async Task<IActionResult> Index()
        {
            var rosterMeContext = _context.PasswordRequest.Include(p => p.Login);
            return View(await rosterMeContext.ToListAsync());
        }

        // GET: PasswordRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordRequest = await _context.PasswordRequest
                .Include(p => p.Login)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (passwordRequest == null)
            {
                return NotFound();
            }

            return View(passwordRequest);
        }

        // GET: PasswordRequests/Create
        public IActionResult Create()
        {
            ViewData["LoginId"] = new SelectList(_context.Login, "LoginId", "LoginId");
            return View();
        }

        // GET: PasswordRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordRequest = await _context.PasswordRequest.FindAsync(id);
            if (passwordRequest == null)
            {
                return NotFound();
            }
            ViewData["LoginId"] = new SelectList(_context.Login, "LoginId", "LoginId", passwordRequest.LoginId);
            return View(passwordRequest);
        }

        // GET: PasswordRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordRequest = await _context.PasswordRequest
                .Include(p => p.Login)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (passwordRequest == null)
            {
                return NotFound();
            }

            return View(passwordRequest);
        }

        /* ---------- HTTP POST Methods ---------- */
        // POST: PasswordRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,LoginId,NewPassword,RequestDate,Status")] PasswordRequest passwordRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passwordRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoginId"] = new SelectList(_context.Login, "LoginId", "LoginId", passwordRequest.LoginId);
            return View(passwordRequest);
        }

        // POST: PasswordRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,LoginId,NewPassword,RequestDate,Status")] PasswordRequest passwordRequest)
        {
            if (id != passwordRequest.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passwordRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasswordRequestExists(passwordRequest.RequestId))
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
            ViewData["LoginId"] = new SelectList(_context.Login, "LoginId", "LoginId", passwordRequest.LoginId);
            return View(passwordRequest);
        }

        // POST: PasswordRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passwordRequest = await _context.PasswordRequest.FindAsync(id);
            _context.PasswordRequest.Remove(passwordRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasswordRequestExists(int id)
        {
            return _context.PasswordRequest.Any(e => e.RequestId == id);
        }
    }
}
