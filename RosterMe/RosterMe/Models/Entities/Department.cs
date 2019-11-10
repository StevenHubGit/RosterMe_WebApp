using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class Department
    {
        //Class variables
        private static String LOG_TAG = "Department Entity class message";

        //Class attributes
        [Key]
        [Display(Name = "Department ID")]
        public int DeptId { get; set; }

        [Display(Name = "Department Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String DeptName { get; set; }
    }
}
