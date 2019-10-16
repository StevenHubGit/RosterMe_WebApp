using Polynesians.Models.Entities;
using RosterMe.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models
{
    public class Dashboard
    {
        //Class variables
        private static String LOG_TAG = "Dashboard Model class message";

        //Class attributes
        public Employee Employee { get; set; }
        public Login Login { get; set; }
        public LoginTrail LoginTrail { get; set; }
    }
}
