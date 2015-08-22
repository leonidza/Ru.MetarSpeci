using System;

namespace Ru.MetarSpeci.DataTypes
{
    public class DayTimeData
    {
        public DayTimeData(string dayTime)
        {
            if (string.IsNullOrEmpty(dayTime))
                return;

            IsDayTime = true;
            if (dayTime.Length != 7)
                throw new MetarSpeciDecodingException("Cannot convert day time to Metar day time format");

            var dayString = dayTime.Substring(0, 2);
            Day = Convert.ToInt32(dayString);

            var hourString = dayTime.Substring(2, 2);
            var hours = Convert.ToInt32(hourString);

            var minutesString = dayTime.Substring(4, 2);
            var minutes = Convert.ToInt32(minutesString);

            Time = new TimeSpan(hours, minutes, 0);
        }

        private bool IsDayTime { get; }
        private int Day { get; }
        private TimeSpan Time { get; }

        public string Description =>
            IsDayTime ? $"{Day} числа текущего месяца за {Time.Hours:00}.{Time.Minutes:00} UTC" : "";
    }
}