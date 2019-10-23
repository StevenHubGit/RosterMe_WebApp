using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Models.Entities
{
    public class Shift
    {
        //Class variables
        private static String LOG_TAG = "Shift Model class message";

        //Class attributes
        [Display(Name = "ID")]
        public int ShiftId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Shift Name")]

        public String ShiftName { get; set; }

        
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]

        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Finish Time")]

        public DateTime FinishTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]

        public DateTime ShftCreatedDate { get; set; }
    }
}
