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
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Login> Logins { get; set; }
        public IEnumerable<LoginTrail> LoginTrails { get; set; }
        public IEnumerable<BookedShifts> BookedShifts { get; set; }
        public IEnumerable<Availability> Availabilities { get; set; }
    }
}
