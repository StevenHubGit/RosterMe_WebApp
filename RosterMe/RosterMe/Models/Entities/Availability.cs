using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class Availability
    {
        //Class variables
        private static String LOG_TAG = "Availability Entity class message";

        //Class attributes
        public int AvailabilityId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime AvailableDate { get; set; }
        public DateTime AvailableFromTime { get; set; }
        public DateTime AvailableToTime { get; set; }
    }
}
