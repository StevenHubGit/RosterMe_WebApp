using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RosterMe.Data;
using RosterMe.Models;
using RosterMe.Models.Entities;

namespace RosterMe.Controllers.EntitiesControllers
{
    public class LoginsController : Controller
    {
        //Class variables
        private static String LOG_TAG = "Login Controller class message";
        private readonly RosterMeContext _context;
        private static readonly HttpClient httpClient = new HttpClient();

        public LoginsController(RosterMeContext context)
        {
            _context = context;
        }

        /* ---------- HTTP GET Methods ---------- */
        /* ---- HTTP GET Method: Index ---- */
        public IActionResult Index()
        {
            //Return View
            return View("~/Views/Logins/Index.cshtml");
        }

        // GET: Logins
        public async Task<IActionResult> LoginsManagement()
        {
            return View(await _context.Login.ToListAsync());
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.LoginId == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.LoginId == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        /* ---------- HTTP POST Methods ---------- */
        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginId,EmployeeId,Username,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoginId,EmployeeId,Username,Password")] Login login)
        {
            if (id != login.LoginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.LoginId))
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
            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login = await _context.Login.FindAsync(id);
            _context.Login.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Login User
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(Dashboard dashboard)
        {
            //Check if model is valid
            if(ModelState.IsValid)
            {
                //Get & store inputs
                String inputUsername = HttpContext.Request.Form["Username"];
                String inputPassword = HttpContext.Request.Form["Password"];

                //Create String to store List of logins
                String loginList = "";

                //Create variables to store data
                int employeeID = 0;
                int loginID = 0;
                DateTime loginDate = DateTime.Now;

                //Store List of existing Login details
                var loginDetails = from lD in _context.Login
                                   select lD;

                //Loop through List of existing login details
                foreach(var login in loginDetails)
                {
                    //Compare inputs
                    if(login.Username.ToString().Equals(inputUsername) &&
                        login.Password.ToString().Equals(inputPassword))
                    {
                        //Store data
                        employeeID = login.EmployeeId;
                        loginID = login.LoginId;

                        /*
                        //Print message
                        return Content(LOG_TAG + ": Alright !" +
                            "\nThe inputs and login details are equal" +
                            "\nInputs" +
                            "\n- Username: " + inputUsername +
                            "\n- Password: " + inputPassword +
                            "\nLogin Details" +
                            "\n- Username: " + login.Username +
                            "\n- Password: " + login.Password +
                            "\n- Employee ID: " + login.EmployeeId +
                            "\n- Login ID: " + login.LoginId
                        );
                        */
                    }

                    /*
                    //Store logins
                    loginList += "Employee ID: " + login.EmployeeId + ": " +
                        "\n- Login ID: " + login.LoginId +
                        "\n- Username: " + login.Username +
                        "\n- Password: " + login.Password +
                        "\n\n";
                    */
                }

                //Set new values for login trails
                var employeLoginTrail = new LoginTrail
                {
                    LogInId = loginID,
                    LogInTime = loginDate
                };

                //Use context to add recored in login trails
                _context.LoginTrail.Add(employeLoginTrail);
                _context.SaveChanges();

                //Redirect to dashboard & pass employee ID
                return RedirectToAction("EmployeeList", "Dashboard", new { id = employeeID });

                /*
                //Print message
                return Content(LOG_TAG + ": List of existing Login Details content" +
                    "\n" + loginList
                );
                */
            }

            //Redirect to view
            return View(dashboard);
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.LoginId == id);
        }
    }
}
