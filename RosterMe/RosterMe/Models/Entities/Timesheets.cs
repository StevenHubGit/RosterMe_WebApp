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
        [Display(Name = "Attendance ID")]
        public int AttendanceId { get; set; }
        
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Time In")]
        public TimeSpan TimeIn { get; set; }

        [Display(Name = "Time Out")]
        public TimeSpan TimeOut { get; set; }

        [Display(Name = "Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [Display(Name = "Shift ID")]
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        [Display(Name = "Approval Status")]
        public String ApprovalStatus { get; set; }
    }
}
