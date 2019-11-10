using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class ShiftInvitation
    {
        //Class variables
        private static String LOG_TAG = "Shift Invitation Entity class message";

        //Class attributes
        [Key]
        [Display(Name = "Invitation ID")]
        public int InvitationId { get; set; }

        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Shift ID")]
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        [Display(Name = "Invitation Status")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String InvitationStatus { get; set; }

        [Display(Name = "Invitation Date")]
        [DataType(DataType.Date)]
        public DateTime InvitationDate { get; set; }

        [Display(Name = "Notification Status")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String NotificationStatus { get; set; }
    }
}
