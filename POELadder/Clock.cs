using System;

namespace PoELadder
{
    class Clock
    {

        //Convert Time from JSON document and returns a DateTime. Can be null. Returned as MinValue
        public static DateTime FormatPOEDate(String POEDate)
        {
            //Null happens for perm Leagues
            if (string.IsNullOrEmpty(POEDate))
            {
                return DateTime.MinValue;
            }

            else
            {
                //Year:
                int POEYear = Int32.Parse(POEDate.Substring(0, 4));

                //Month:
                int POEMonth = Int32.Parse(POEDate.Substring(5, 2));

                //Day:
                int POEDay = Int32.Parse(POEDate.Substring(8, 2));

                //Hour:
                int POEHour = Int32.Parse(POEDate.Substring(11, 2));

                //Minute:
                int POEMinute = Int32.Parse(POEDate.Substring(14, 2));

                //Second:
                int POESecond = Int32.Parse(POEDate.Substring(17, 2));

                //Combine to create the DateTime Object
                DateTime result = new DateTime(POEYear, POEMonth, POEDay, POEHour, POEMinute, POESecond);

                return result;

            }
        }

    }
}
