using System;
using System.Collections.Generic;
using System.Text;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class ReWeatherData
    {
        private readonly List<WeatherPhenomenon> _weatherPhenomenon = new List<WeatherPhenomenon>();

        public ReWeatherData(string match)
        {
            if (string.IsNullOrEmpty(match))
                return;

            var reWeather = match.Trim();
            IsReWeatherData = true;
            if (reWeather.Length == 4)
            {
                _weatherPhenomenon.Add(
                    (WeatherPhenomenon)Enum.Parse(typeof(WeatherPhenomenon), reWeather.Substring(2, 2), true));
            }
            else
            {
                _weatherPhenomenon.Add(
                    (WeatherPhenomenon)Enum.Parse(typeof(WeatherPhenomenon), reWeather.Substring(2, 2), true));
                _weatherPhenomenon.Add(
                    (WeatherPhenomenon)Enum.Parse(typeof(WeatherPhenomenon), reWeather.Substring(4, 2), true));
            }
        }

        private bool IsReWeatherData { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsReWeatherData)
                    return result.ToString();

                result.Append("Недавнее явление: ");
                foreach (var phenomenon in _weatherPhenomenon)
                {
                    result.Append(phenomenon.GetMetarDescription() + " ");
                }

                return result.ToString();
            }
        }
    }
}