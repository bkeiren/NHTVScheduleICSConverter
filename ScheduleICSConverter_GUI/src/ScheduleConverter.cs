using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SchoolScheduleICSConverter_GUI
{
    public class ScheduleConverter
    {
        private static List<Appointment> ExtractAppointments(string _HTML)
        {
            List<Appointment> appointments = new List<Appointment>();

            // This regex pattern matches a string containing the weekday and all appointments for that day.
            //string regexStringDay = "(?:<span.*?>(?'Day'Monday|Tuesday|Wednesday|Thursday|Friday)</span.*?>.*?<table cellspacing=\"0\" cellpadding=\"2%\" border=\"1\">).*?(?:<tr>[\\s\\n](?:<td>.*?</td>)+?[\\s\\n]</tr>)*?.*?</table>";
            string regexStringDay = "(?:<span.*?>(?'Day'Monday|Tuesday|Wednesday|Thursday|Friday)</span.*?>.*?<table[\\s\\n]+?cellspacing=['\"].*?['\"] cellpadding=['\"].*?['\"] border=['\"].*?['\"]>).*?(?:<tr[\\s]*?>[\\s\\n](?:<td>.*?</td>)+?[\\s\\n]</tr>)*?.*?</table>";
            //string regexStringAppointment = "<tr[\\s]*?>[\\s\\n](<td>(?!Begin)(?'timeStart'\\d+?:\\d+?)</td>)[\\s\\n]??(<td>(?!Eind)(?'timeEnd'\\d+?:\\d+?)</td>)[\\s\\n]??(<td>(?!Activiteit)(?'activity'.*?)</td>)[\\s\\n]??(<td>(?!Plaats)(?'location'.*?)</td>)[\\s\\n]??(<td>(?!Docent\\(en\\))(?'lecturer'.*?)</td>)[\\s\\n]??(<td>(?!Kalenderweken)(?'weeks'.*?)</td>)[\\s\\n]??</tr>"; 
            string regexStringAppointment = "<tr[\\s]*?>[\\s\\n]*?(<td>(?!Begin)(?'timeStart'\\d+?:\\d+?)</td>)[\\s\\n]*?(<td>(?!Eind)(?'timeEnd'\\d+?:\\d+?)</td>)[\\s\\n]*?(<td>(?!Activiteit)(?'activity'.*?)</td>)[\\s\\n]*?(<td>(?!Plaats)(?'location'.*?)</td>)[\\s\\n]*?(<td>(?!Docent\\(en\\))(?'lecturer'.*?)</td>)[\\s\\n]*?(<td>(?!Kalenderweken)(?'weeks'.*?)</td>)[\\s\\n]*?</tr>";
            //regexStringAppointment = "<tr[\\s]*?>[\\s\\n]*?<td>.*?</td>[\\s\\n]*?</tr>";

            System.Text.RegularExpressions.Regex regexObjectDay = new System.Text.RegularExpressions.Regex(regexStringDay, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
            System.Text.RegularExpressions.Regex regexObjectAppointment = new System.Text.RegularExpressions.Regex(regexStringAppointment, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);

            System.Text.RegularExpressions.MatchCollection regexDayMatchCollection = regexObjectDay.Matches(_HTML);
            foreach (System.Text.RegularExpressions.Match regexDayMatch in regexDayMatchCollection)
            {
                string weekDay = regexDayMatch.Groups["Day"].Value;
                System.Text.RegularExpressions.MatchCollection regexAppointmentMatchCollection = regexObjectAppointment.Matches(regexDayMatch.Value);
                foreach (System.Text.RegularExpressions.Match regexAppointmentMatch in regexAppointmentMatchCollection)
                {
                    string timeStart = regexAppointmentMatch.Groups["timeStart"].Value;
                    string timeEnd = regexAppointmentMatch.Groups["timeEnd"].Value;
                    string activity = regexAppointmentMatch.Groups["activity"].Value;
                    string location = regexAppointmentMatch.Groups["location"].Value;
                    string lecturer = regexAppointmentMatch.Groups["lecturer"].Value;
                    string weeks = regexAppointmentMatch.Groups["weeks"].Value;

                    appointments.Add(new Appointment(timeStart, timeEnd, weekDay, activity, location, lecturer, weeks));
                }
            }

            Log.Info("Finished extracting appointments. Found: " + appointments.Count);

            return appointments;
        }

        private static string ConstructICALString(List<Appointment> _Appointments, int _StartYear, string _ClassCode)
        {
            string iCal = "BEGIN:VCALENDAR\n" +
                          "VERSION:2.0\n" +
                          "PRODID:-//Bryan Keiren//NHTV Schedule ICS Converter V1.0//EN\n" +
                          "X-WR-CALNAME:" + _ClassCode + " Schedule\n" +
                          "X-PUBLISHED-TTL:PT6H\n" +
                          "CALSCALE:GREGORIAN\n";

            foreach (Appointment appointment in _Appointments)
            {
                if (appointment.weeks.Count <= 0)
                {
                    Log.Error("Appointment has no scheduled weeks (" + appointment.activity + " / " + appointment.location + " / " + appointment.lecturer + " / " + appointment.timeStart + " / " + appointment.timeEnd + ")");
                    continue;
                }
                foreach (int week in appointment.weeks)
                {
                    int year = week > 32 ? _StartYear : _StartYear + 1;

                    DateTime date = FirstDateOfWeek(year, week, System.Globalization.CalendarWeekRule.FirstFourDayWeek);
                    date = date.AddDays(-7 + (int)appointment.weekDay); // -7 because we need to subtract 1 week because FirstDateOfWeek is not correct otherwise.

                    string monthString = (date.Month).ToString("00");
                    string monthDayString = (date.Day).ToString("00");
                    string timeStartString = appointment.timeStart;
                    string timeEndString = appointment.timeEnd;

                    timeStartString = (timeStartString.Length < 5 ? "0" : string.Empty) + timeStartString.Replace(":", "");
                    timeEndString = (timeEndString.Length < 5 ? "0" : string.Empty) + timeEndString.Replace(":", "");

                    iCal += "BEGIN:VEVENT\n" +
                            "UID:" + year + week + ((int)appointment.weekDay).ToString() + timeStartString + timeEndString + "\n" +
                            "SUMMARY;ENCODING=QUOTED-PRINTABLE:" + appointment.activity + "\n" +
                            "DESCRIPTION;ENCODING=QUOTED-PRINTABLE:" + appointment.location + "\n" +
                            "LOCATION;ENCODING=QUOTED-PRINTABLE:" + appointment.location + "\n" +
                            "DTSTART;TZID=\"Europe/Amsterdam\":" + year + monthString + monthDayString + "T" + timeStartString + "00" + "\n" +
                            "DTEND;TZID=\"Europe/Amsterdam\":" + year + monthString + monthDayString + "T" + timeEndString + "00" + "\n" +
                            "END:VEVENT\n";
                }
            }

            iCal += "END:VCALENDAR\n";

            Log.Info("Finished constructing iCal string");

            return iCal;
        }

        private static System.DateTime FirstDateOfWeek(int year, int weekNum, System.Globalization.CalendarWeekRule rule)
        {
            Debug.Assert(weekNum >= 1);

            DateTime jan1 = new DateTime(year, 1, 1);

            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(daysOffset);
            Debug.Assert(firstMonday.DayOfWeek == DayOfWeek.Monday);

            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstMonday, rule, DayOfWeek.Monday);

            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            DateTime result = firstMonday.AddDays(weekNum * 7);

            return result;
        }

        private static string DownloadSchedulePage(string _ClassCode, string _StartWeek, string _EndWeek)
        {
            // Format classcode to make it URL-safe.
            string ClassCodeFormatted = _ClassCode.Replace(" ", "%20");

            //http://194.171.178.25:8080
            string ScheduleURL = "http://roosters.nhtv.nl:8080/Reporting/Textspreadsheet;Student%20Sets;name;" + ClassCodeFormatted + "?&weeks=" + _StartWeek + "-" + _EndWeek + "&days=1-5&width=0&height=0";
            //string HTMLOutput = "output\\htmloutput_" + _ClassCode + "_" + _StartWeek + "-" + _EndWeek + ".html";

            System.Net.WebClient client = new System.Net.WebClient();

            try
            {
                return client.DownloadString(ScheduleURL);
            }
            catch (System.Net.WebException ex)
            {
                Log.Warning("WebClient.DownloadString failed: " + ex.Message + " (" + ex.Status + ")");
            }
            catch (System.NotSupportedException ex)
            {
                Log.Error("WebClient.DownloadString has been called simultaneously on multiple threads");
            }
            return string.Empty;
        }

        public static void ProcessClassSchedule(string _ClassCode, string _StartYear, string _StartWeek, string _EndWeek)
        {
            Log.Info("Starting to process class schedule (" + _ClassCode + ")...");

            // 1) Download the webpage.
            string HTMLString = DownloadSchedulePage(_ClassCode, _StartWeek, _EndWeek);

            if (HTMLString == string.Empty)
            {
                Log.Info("Stopped processing schedule for class '" + _ClassCode + "' because of an error while downloading the webpage");
                return;
            }

            // Extract appointments from the webpage using regex, store ina convenient format.
            List<Appointment> appointments = ExtractAppointments(HTMLString);

            // Construct an iCal string from the appointments.
            string iCalString = ConstructICALString(appointments, System.Int32.Parse(_StartYear), _ClassCode);

            string OutputFile = "output\\" + _ClassCode + ".ics";
            OutputFile = OutputFile.Replace(" ", "_");  // For backwards-compatibility with previous versions of the converter.

            // Store the iCal string as a .ics file.
            System.IO.File.WriteAllText(OutputFile, iCalString);

            Log.Info("Finished processing class schedule");
        }
    }
}
