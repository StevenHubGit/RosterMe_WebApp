using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Polynesians.Models.Entities
{
    public class Login
    {
        //Class variables
        private static string LOG_TAG = "Login class message";

        //Class attributes
        public int EmployeeID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Username { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
