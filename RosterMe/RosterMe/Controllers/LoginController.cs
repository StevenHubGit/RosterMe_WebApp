using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Polynesians.Models.Entities;
using RosterMe.Data;
using RosterMe.Models.Entities;

namespace RosterMe.Controllers
{
    public class LoginController : Controller
    {
        //Class variables
        private static String LOG_TAG = "Account Controller class message";
        private IConfiguration Configuration { get; }
        private RosterMeContext _rosterMeContext;

        /* ---- Constructor ---- */
        public LoginController(IConfiguration configuration, RosterMeContext rosterMeContext)
        {
            //Initialize variables
            Configuration = configuration;
            _rosterMeContext = rosterMeContext;
        }

        /* ---------- GET methods ---------- */
        /* ---- Action: /Login/ ---- */
        //Default method to be called by the controller
        [HttpGet]
        public IActionResult Index()
        {
            //Return Razor View
            return View();
        }

        /* ---- Action: /Login/Welcome/ ---- */
        public IActionResult Welcome(String name, int numTimes = 1)
        {
            //Set View Data
            ViewData["Message"] = "Welcome " + name;
            ViewData["NumTimes"] = numTimes;

            //Return View
            return View();
        }

        /* ---------- Login User ---------- */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser([FromQuery] int empID)
        {
            //Check if model is valid
            if (ModelState.IsValid)
            {
                //Get & store inputs
                String inputUsername = HttpContext.Request.Form["Username"];
                String inputPassword = HttpContext.Request.Form["Password"];

                //Set query
                var loginDetails = _rosterMeContext.Login
                    .ToList();

                //
                String login = "";

                //Loop through List of login details
                for(int i = 0; i < loginDetails.Count; i++)
                {
                    //Store data in String
                    login += loginDetails[i].EmployeeId + 
                        "\n- Username: " + loginDetails[i].Username +
                        "\n- Password: " + loginDetails[i].Password + "\n";

                    //Compare inputs with login details in database
                    if(loginDetails[i].Username.Equals(inputUsername) &&
                        loginDetails[i].Password.Equals(inputPassword))
                    {
                        //Create Login Trail
                        LoginTrail loginTrail = new LoginTrail();

                        //Set values
                        loginTrail.LogInTime = DateTime.Now;
                        //loginTrail.LogInId = loginDetails[i].LoginId;

                        //
                        //_rosterMeContext.LoginTrail.Add(loginTrail);

                        //Save changes
                        //_rosterMeContext.SaveChanges();

                        //Redirect to action in controller without route
                        //return View("../Dashboard/Index");
                        //return RedirectToAction("Index", "Dashboard", null);
                        return RedirectToAction("Index", "Dashboard", loginDetails[i].EmployeeId);

                        /*
                        //Print message
                        return Content(LOG_TAG + ": Alright !" +
                            "\nThe inputs matches the login details in database" +
                            "\nInputs" +
                            "\n- Username: " + inputUsername +
                            "\n- Password: " + inputPassword +
                            "\nLogin Database" +
                            "\n- Username: " + loginDetails[i].Username +
                            "\n- Password: " + loginDetails[i].Password
                        );
                        */
                    }
                }

                //Print message
                /*
                return Content(LOG_TAG + ": Input values for Login" +
                    "\n- Username: " + inputUsername +
                    "\n- Password: " + inputPassword +
                    "\n\nList of Login Details content" +
                    "\n- Size: " + loginDetails.Count +
                    "\n\nEmployee Login Details" +
                    "\n" + login
                );
                */
            }

            //Return to current Index
            return View("~/Views/Login/Index.cshtml");
        }
    }
}