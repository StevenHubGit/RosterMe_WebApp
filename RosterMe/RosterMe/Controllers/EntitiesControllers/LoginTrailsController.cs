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
    public class LoginTrailsController : Controller
    {
        //Class variables
        private readonly RosterMeContext _context;

        public LoginTrailsController(RosterMeContext context)
        {
            _context = context;
        }

        // GET: LoginTrails
        public async Task<IActionResult> Index()
        {
            var rosterMeContext = _context.LoginTrail.Include(l => l.LogIn);
            return View(await rosterMeContext.ToListAsync());
        }

        // GET: LoginTrails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginTrail = await _context.LoginTrail
                .Include(l => l.LogIn)
                .FirstOrDefaultAsync(m => m.LoginTrailId == id);
            if (loginTrail == null)
            {
                return NotFound();
            }

            return View(loginTrail);
        }

        // GET: LoginTrails/Create
        public IActionResult Create()
        {
            ViewData["LogInId"] = new SelectList(_context.Login, "LoginId", "LoginId");
            return View();
        }

        // POST: LoginTrails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginTrailId,LogInId,LogInTime,LogOutTime")] LoginTrail loginTrail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginTrail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LogInId"] = new SelectList(_context.Login, "LoginId", "LoginId", loginTrail.LogInId);
            return View(loginTrail);
        }

        // GET: LoginTrails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginTrail = await _context.LoginTrail.FindAsync(id);
            if (loginTrail == null)
            {
                return NotFound();
            }
            ViewData["LogInId"] = new SelectList(_context.Login, "LoginId", "LoginId", loginTrail.LogInId);
            return View(loginTrail);
        }

        // POST: LoginTrails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoginTrailId,LogInId,LogInTime,LogOutTime")] LoginTrail loginTrail)
        {
            if (id != loginTrail.LoginTrailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginTrail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginTrailExists(loginTrail.LoginTrailId))
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
            ViewData["LogInId"] = new SelectList(_context.Login, "LoginId", "LoginId", loginTrail.LogInId);
            return View(loginTrail);
        }

        // GET: LoginTrails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginTrail = await _context.LoginTrail
                .Include(l => l.LogIn)
                .FirstOrDefaultAsync(m => m.LoginTrailId == id);
            if (loginTrail == null)
            {
                return NotFound();
            }

            return View(loginTrail);
        }

        // POST: LoginTrails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginTrail = await _context.LoginTrail.FindAsync(id);
            _context.LoginTrail.Remove(loginTrail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginTrailExists(int id)
        {
            return _context.LoginTrail.Any(e => e.LoginTrailId == id);
        }
    }
}
