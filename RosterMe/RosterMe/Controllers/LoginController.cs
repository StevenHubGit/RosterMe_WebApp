using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Polynesians.Models.Entities;
using RosterMe.Data;

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
        public IActionResult LoginUser()
        {
            //Check if model is valid
            if (ModelState.IsValid)
            {
                //Get & store inputs
                String inputUsername = HttpContext.Request.Form["Username"];
                String inputPassword = HttpContext.Request.Form["Password"];

                //Store connection string
                string connectionString = Configuration["ConnectionString:RosterMeDB"];

                using (SqlConnection connection = (SqlConnection)_)
                {
                    //Set query
                    String query = $"Select * From Login";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //Set command connection
                        command.Connection = connection;

                        //Check if command connection is closed
                        if(command.Connection.State == ConnectionState.Closed)
                        {
                            //Open command connection
                            command.Connection.Open();
                        }

                        //Check if command connection is open
                        if(command.Connection.State == ConnectionState.Open)
                        {
                            try
                            {
                                //Execute & store command in SQL Data Reader
                                SqlDataReader reader = command.ExecuteReader();

                                //Loop through reader
                                while (reader.Read())
                                {
                                    //Print result
                                    return Content(LOG_TAG + ": Query result" +
                                        "\n- Employee ID: " + reader["EmployeId"] +
                                        "\n- Username: " + reader["Username"] +
                                        "\n- Password: " + reader["Password"]
                                    );
                                }
                            }
                            catch (Exception e)
                            {
                                //Print error
                                return Content(LOG_TAG + ": Error" +
                                    "\nAn error occurred while trying to retrieve login" +
                                    "\n- Message: " + e.Message +
                                    "\n- Stacktrace: " + e.StackTrace
                                );
                            }
                            finally
                            {
                                //Check if command connection is open
                                if(command.Connection.State == ConnectionState.Open)
                                {
                                    //Close command connection
                                    command.Connection.Close();
                                }
                            }
                        }
                    }
                }

                //Redirect to page
                //return View("../Home/Home");
                return Content(LOG_TAG + ": Input values for Login" +
                    "\n- Username: " + inputUsername +
                    "\n- Password: " + inputPassword
                );
            }

            //Return to current Index
            return View();
        }
    }
}