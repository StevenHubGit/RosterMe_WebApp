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
        public int ShiftId { get; set; }

        [Display(Name = "Shift Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String ShiftName { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Finish Time")]
        [DataType(DataType.Time)]
        public DateTime FinishTime { get; set; }

        [Display(Name = "Shift Created Date")]
        [DataType(DataType.Date)]
        public DateTime ShiftCreatedDate { get; set; }
    }
}
