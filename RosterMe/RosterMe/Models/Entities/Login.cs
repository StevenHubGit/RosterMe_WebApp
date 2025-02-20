﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class Login
    {
        //Class variables
        private static string LOG_TAG = "Login class message";

        //Class attributes
        [Display(Name = "Login ID")]
        public int LoginId { get; set; }

        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Username { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
