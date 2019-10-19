using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RosterMe.Controllers
{
    public class PricingController : Controller
    {
        //Class variables
        private static String LOG_TAG = "Pricing Controller class message";

        /* ---------- HTTP GET Methods ---------- */
        /* ---- HTTP GET Method: Index ---- */
        [HttpGet]
        public IActionResult Index()
        {
            //Redirect to View
            return View();
        }
    }
}