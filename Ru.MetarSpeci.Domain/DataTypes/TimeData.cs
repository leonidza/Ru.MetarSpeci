using System;
using System.Text;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class TimeData
    {
        public TimeData(string match)
        {
            if (string.IsNullOrEmpty(match))
                return;

            IsTime = true;

            TimePrefix = (TimePrefix)Enum.Parse(typeof(TimePrefix), match.Substring(0, 2), true);

            var hours = Convert.ToInt32(match.Substring(2, 2));
            var minutes = Convert.ToInt32(match.Substring(4, 2));
            Time = new TimeSpan(hours, minutes, 0);
        }

        private bool IsTime { get; }

        private TimePrefix TimePrefix { get; }

        private TimeSpan Time { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsTime)
                    return result.ToString();

                result.Append(TimePrefix.GetMetarDescription() + " ");
                result.AppendFormat("{0}:{1} UTC ", Time.Hours, Time.Minutes);

                return result.ToString();
            }
        }
    }
}