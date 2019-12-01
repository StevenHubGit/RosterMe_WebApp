using RosterMe.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models
{
    public class Home
    {
        //Class variables
        private static String LOG_TAG = "Home Model class message";

        //Class attributes
        public Employee Employees { get; set; }
        public Login Logins { get; set; }
        public LoginTrail LoginTrails { get; set; }
        public BookedShifts BookedShifts { get; set; }
        public Availability Availabilities { get; set; }
    }
}
