using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Classes
{
    public class DateTimeProperties
    {
        //Class variables
        private static String LOG_TAG = "Date Time Properties class message";

        /* ---- Calculate years difference ---- */
        public static int calculateYearDifferenceBetweenDateTimes(DateTime dateTimeBefore, DateTime dateTimeAfter)
        {
            //Create integer to return
            int yearDifference = 0;

            //Calculate & store years difference
            yearDifference = (dateTimeAfter.Year - dateTimeBefore.Year);

            //Return integer
            return yearDifference;
        }

        /* ---------- Conversions ---------- */
        /* ---- Convert: From String to Date ---- */
        public static DateTime convertStringToDate(String dateString)
        {
            //Create Date Time to return
            DateTime convertedDate = DateTime.Parse(dateString);

            //Return Date Time
            return convertedDate;
        }

        /* ---- Convert: From Date to String ---- */
        public static String convertDateToString(DateTime dateToConvert, String format)
        {
            //Create String to return
            String convertedDate = dateToConvert.ToString(format);

            //Return String
            return convertedDate;
        }
    }
}
