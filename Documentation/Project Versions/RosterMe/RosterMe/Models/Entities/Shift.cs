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

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String ShiftName { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime FinishTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShftCreatedDate { get; set; }
    }
}
