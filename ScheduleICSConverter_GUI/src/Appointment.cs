using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolScheduleICSConverter_GUI
{
    public class Appointment
    {
        public enum WeekDay
        {
            MONDAY = 0,
            TUESDAY,
            WEDNESDAY,
            THURSDAY,
            FRIDAY
        }

        public Appointment( string _timeStart,
                            string _timeEnd, 
                            string _weekDay,
                            string _activity,
                            string _location,
                            string _lecturer,
                            string _weeks )
        {
            timeStart = _timeStart;
            timeEnd = _timeEnd;
            weekDayString = _weekDay;
            activity = _activity;
            location = _location;
            lecturer = _lecturer;

            if (weekDayString.Equals("Monday", StringComparison.InvariantCultureIgnoreCase))
            {
                weekDay = WeekDay.MONDAY;
            }
            else if (weekDayString.Equals("Tuesday", StringComparison.InvariantCultureIgnoreCase))
            {
                weekDay = WeekDay.TUESDAY;
            }
            else if (weekDayString.Equals("Wednesday", StringComparison.InvariantCultureIgnoreCase))
            {
                weekDay = WeekDay.WEDNESDAY;
            }
            else if (weekDayString.Equals("Thursday", StringComparison.InvariantCultureIgnoreCase))
            {
                weekDay = WeekDay.THURSDAY;
            }
            else if (weekDayString.Equals("Friday", StringComparison.InvariantCultureIgnoreCase))
            {
                weekDay = WeekDay.FRIDAY;
            }
            else
            {
                throw new Exception("Unhandled weekday: " + weekDayString);
            }

            weeks = new List<int>();
            string regexWeekNumbers = "((?'n0'\\d+)(?:\\s*-\\s*(?'n1'\\d+))?)";
            System.Text.RegularExpressions.Regex regexWeekNumbersObject = new System.Text.RegularExpressions.Regex(regexWeekNumbers);
            System.Text.RegularExpressions.MatchCollection regexWeekNumbersMatchCollection = regexWeekNumbersObject.Matches(_weeks);
            foreach (System.Text.RegularExpressions.Match regexWeekNumbersMatch in regexWeekNumbersMatchCollection)
            {
                string n0 = regexWeekNumbersMatch.Groups["n0"].Value;
                string n1 = regexWeekNumbersMatch.Groups["n1"].Value;

                int n0int = System.Int32.Parse(n0);
                weeks.Add(n0int);

                if (n1 != string.Empty)
                {
                    // n1 is not empty, so we have two numbers which denote a range.
                    int n1int = System.Int32.Parse(n1);
                    for (int i = n0int + 1; i <= n1int; ++i)
                    {
                        if (i > 52)
                        {
                            i = 1;
                            continue;
                        }
                        weeks.Add(i);
                    }
                }
            }
        }

        public string timeStart;
        public string timeEnd;
        public string weekDayString;
        public WeekDay weekDay;
        public string activity;
        public string location;
        public string lecturer;
        public List<int> weeks;
    }
}
