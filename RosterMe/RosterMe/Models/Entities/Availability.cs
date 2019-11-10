using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Availability ID")]
        public int AvailabilityId { get; set; }

        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Available Date")]
        [DataType(DataType.Date)]
        public DateTime AvailableDate { get; set; }

        [Display(Name = "Available From Time")]
        [DataType(DataType.Time)]
        public DateTime AvailableFromTime { get; set; }

        [Display(Name = "Available To Time")]
        [DataType(DataType.Time)]
        public DateTime AvailableToTime { get; set; }
    }
}
