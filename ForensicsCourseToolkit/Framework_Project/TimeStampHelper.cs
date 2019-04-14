using System;
using System.Globalization;

namespace ForensicsCourseToolkit.Framework_Project
{
    public static class TimeStampHelper
    {
        public static string TimeStampFormat = "yyyyMMdd-HHmmss";
        public static string GetTimeStamp(DateTime value)
        {            
            return value.ToString(TimeStampFormat);            
        }

        public static DateTime ConvertTimestampToDatetime(string timestamp)
        {
            return DateTime.ParseExact(timestamp, TimeStampFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);
          
        }

        public static bool IsWithinNSeconds(string timeStamp, int numberOfSeconds)
        {
            var dateTime = ConvertTimestampToDatetime(timeStamp);
            return IsWithinNSeconds(dateTime, numberOfSeconds);
        }
        public static bool IsWithinNSeconds(DateTime originalTime, int numberOfSeconds)
        {
            var totalSeconds = (DateTime.Now - originalTime).TotalSeconds;
            return totalSeconds <= numberOfSeconds;
        }
    }
}