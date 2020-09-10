using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class StringValidator
    {
        // Public Methods
        public static bool isStringDigitsOnly(string i_String)
        {
            bool isDigitsOnly = true;
            foreach (char character in i_String)
            {
                if (!char.IsDigit(character))
                {
                    isDigitsOnly = false;
                }
            }

            return isDigitsOnly;
        }

        public static bool isStringYesOrNo(string i_String)
        {
            string stringInLowercase = i_String.ToLower();

            return stringInLowercase == "yes" || stringInLowercase == "no";
        }

        public static bool isStringANumber(string i_String)
        {
            bool isANumber = float.TryParse(i_String, out _);

            return isANumber;
        }

        public static bool isStringNumberInRange(string i_String, float? i_MinValue, float? i_MaxValue)
        {
            bool isInRange = true;
            float stringAsNumber = float.Parse(i_String);
            if (stringAsNumber < i_MinValue || stringAsNumber > i_MaxValue)
            {
                isInRange = false;
            }

            return isInRange;
        }
    }
}
