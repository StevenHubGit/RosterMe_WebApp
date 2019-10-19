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
        public int DeptId { get; set; }
        public String DeptName { get; set; }
    }
}
