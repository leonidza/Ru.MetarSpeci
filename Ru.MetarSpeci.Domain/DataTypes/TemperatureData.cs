using System;
using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class TemperatureData
    {
        public TemperatureData(string match)
        {
            if (string.IsNullOrEmpty(match))
                return;

            var temperatureMatch = match.Trim();

            IsTemperature = true;

            if (temperatureMatch[0] == 'M')
            {
                IsTemperatureMinus = true;
                Temperature = Convert.ToInt32(temperatureMatch.Substring(1, 2));
            }
            else
                Temperature = Convert.ToInt32(temperatureMatch.Substring(0, 2));

            var slashIndex = temperatureMatch.IndexOf('/');
            if (temperatureMatch[slashIndex + 1] == 'M')
            {
                IsDewPointMinus = true;
                DewPoint = Convert.ToInt32(temperatureMatch.Substring(slashIndex + 2, 2));
            }
            else
                DewPoint = Convert.ToInt32(temperatureMatch.Substring(slashIndex + 1, 2));
        }

        private bool IsTemperature { get; }

        private bool IsTemperatureMinus { get; }

        private int Temperature { get; }

        private bool IsDewPointMinus { get; }

        private int DewPoint { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsTemperature)
                    return result.ToString();

                result.Append("Температура ");
                if (IsTemperatureMinus)
                    result.Append("-");

                result.Append(Temperature + "°C");
                result.Append(", точка росы ");

                if (IsDewPointMinus)
                    result.Append("-");

                result.Append(DewPoint + "°C");

                return result.ToString();
            }
        }
    }
}