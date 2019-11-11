using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Classes
{
    public class StringProperties
    {
        //Class variables
        private static String LOG_TAG = "String Properties Class message";

        /* ---- Split String by specific character ---- */
        public static String splitStringByCharacter(String stringToSplit, String characterToSplitOn, int partToGet)
        {
            //Create String to return
            String splitedString = "";

            //Split input String by input character
            String[] splitInputString = stringToSplit.Split(characterToSplitOn);

            //Store splited String array
            splitedString = splitInputString[partToGet];

            //Return String
            return splitedString;
        }

        /* ---- Check if input String contains numbers ---- */
        public static bool checkIfContainNumbers(String stringToCheck)
        {
            //Create boolean to return
            bool hasNumbers = false;

            //Check if input String contains numbers
            if(stringToCheck.Any(c => char.IsDigit(c)) == true)
            {
                //Set boolean
                hasNumbers = true;
            }

            //Return boolean
            return hasNumbers;
        }
    }
}
