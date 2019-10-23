using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class Timesheets
    {
        //Class variables
        private static String LOG_TAg = "Timesheets Entity class message";

        //Class attributes
        [Key]
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public String ApprovalStatus { get; set; }
    }
}
