using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RosterMe.Models;

namespace RosterMe.Controllers
{
    public class HomeController : Controller
    {
        //Class variables
        private readonly ILogger<HomeController> _logger;

        /**
         * Constructor
         * */
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /* ---------- HTTP GET Methods ---------- */
        /* ---- HTTP GET Method: Index ---- */
        public IActionResult Index()
        {
            //Redirect to View
            return View();
        }

        public IActionResult Privacy()
        {
            //Redirect to View
            return View();
        }

        public IActionResult ContactUs()
        {
            //Redirect to View
            return View("/Views/ContactUs/Index.cshtml");
        }

        public IActionResult SendEmailFromContactUs(string email,string message,string name)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("poojajadhav315@gmail.com", "poojapari14");
            client.Port = 587;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("poojajadhav315@gmail.com");
            mailMessage.To.Add("poojajadhav315@gmail.com");
            mailMessage.Body = message;
            mailMessage.Subject = name;
            client.EnableSsl = true;
            client.Send(mailMessage);
            return View();
        }

        public IActionResult About()
        {
            //Redirect to View
            return View("~/Views/About/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
