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
        public int BookingId { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime BookedTime { get; set; }
    }
}
