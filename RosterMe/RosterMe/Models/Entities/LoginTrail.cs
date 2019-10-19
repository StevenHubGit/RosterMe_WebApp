using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class LoginTrail
    {
        //Class variables
        private static String LOG_TAG = "Login Trail Entity class message";

        //Class attributes
        [Display(Name = "Login Trail ID")]
        public int LoginTrailId { get; set; }

        [Display(Name = "Login ID")]
        [ForeignKey("LoginId")]
        public int LogInId { get; set; }
        public Login LogIn { get; set; }

        [Display(Name = "Login Time")]
        [DataType(DataType.Time)]
        public DateTime LogInTime { get; set; }

        [Display(Name = "Logout Time")]
        [DataType(DataType.Time)]
        public DateTime LogOutTime { get; set; }
    }
}
