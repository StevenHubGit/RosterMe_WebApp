using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class BookedShifts
    {
        //Class variables
        private static String LOG_TAG = "Booked Shifts Entity class message";

        //Class attributes
        [Key]
        [Display(Name = "Booking ID")]
        public int BookingId { get; set; }

        [Display(Name = "Shift ID")]
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Booked Time")]
        [DataType(DataType.Time)]
        public DateTime BookedTime { get; set; }
    }
}
