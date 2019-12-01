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
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public String ApprovalStatus { get; set; }
    }
}
