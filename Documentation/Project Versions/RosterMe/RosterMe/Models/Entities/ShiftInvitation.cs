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
        public int InvitationId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public String InvitationStatus { get; set; }
        public DateTime InvitationDate { get; set; }
        public String NotificationStatus { get; set; }
    }
}
