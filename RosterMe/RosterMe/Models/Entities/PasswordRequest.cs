using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class PasswordRequest
    {
        //Class variables
        private static String LOG_TAG = "Password Request Entity class message";

        //Class attributes
        [Key]
        [Display(Name = "Request ID")]
        public int RequestId { get; set; }

        [Display(Name = "Login ID")]
        public int LoginId { get; set; }
        public Login Login { get; set; }

        [Display(Name = "New Password")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String NewPassword { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Status")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String Status { get; set; }
    }
}
