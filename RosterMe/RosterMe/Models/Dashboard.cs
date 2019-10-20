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
        public IEnumerable<Employee> Employee { get; set; }
        public IEnumerable<Login> Login { get; set; }
        public IEnumerable<LoginTrail> LoginTrail { get; set; }
    }
}
