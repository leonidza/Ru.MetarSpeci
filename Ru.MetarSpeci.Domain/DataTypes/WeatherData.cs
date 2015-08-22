using System;
using System.Collections.Generic;
using System.Text;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class WeatherData
    {
        private readonly List<WeatherPhenomenon> _metarWeatherPhenomenon = new List<WeatherPhenomenon>();

        public WeatherData(string metarWeather)
        {
            if (string.IsNullOrEmpty(metarWeather))
                return;

            var weather = metarWeather.Trim();
            IsWeatherPhenomenon = true;

            if (weather[0] == '-' || weather[0] == '+')
            {
                IsWeakOrStrong = true;
                MetarWeakOrStrong = weather[0] == '-' ? WeakOrStrong.Minus : WeakOrStrong.Plus;

                if ((weather.Length - 1) == 4)
                    switch (weather.Substring(1, 4))
                    {
                        case "MIFG":
                            _metarWeatherPhenomenon.Add(WeatherPhenomenon.MIFG);
                            break;
                        case "BCFG":
                            _metarWeatherPhenomenon.Add(WeatherPhenomenon.BCFG);
                            break;
                        default:
                            _metarWeatherPhenomenon.Add(
                                (WeatherPhenomenon)
                                    Enum.Parse(typeof(WeatherPhenomenon), weather.Substring(1, 2), true));
                            _metarWeatherPhenomenon.Add(
                                (WeatherPhenomenon)
                                    Enum.Parse(typeof(WeatherPhenomenon), weather.Substring(3, 2), true));
                            break;
                    }
                else
                    _metarWeatherPhenomenon.Add(
                        (WeatherPhenomenon)Enum.Parse(typeof(WeatherPhenomenon), weather.Substring(1, 2), true));
            }
            else
            {
                if ((weather.Length) == 4)
                    switch (weather.Substring(0, 4))
                    {
                        case "MIFG":
                            _metarWeatherPhenomenon.Add(WeatherPhenomenon.MIFG);
                            break;
                        case "BCFG":
                            _metarWeatherPhenomenon.Add(WeatherPhenomenon.BCFG);
                            break;
                        default:
                            _metarWeatherPhenomenon.Add(
                                (WeatherPhenomenon)
                                    Enum.Parse(typeof(WeatherPhenomenon), weather.Substring(0, 2), true));
                            _metarWeatherPhenomenon.Add(
                                (WeatherPhenomenon)
                                    Enum.Parse(typeof(WeatherPhenomenon), weather.Substring(2, 2), true));
                            break;
                    }
                else
                    _metarWeatherPhenomenon.Add(
                        (WeatherPhenomenon)Enum.Parse(typeof(WeatherPhenomenon), weather.Substring(0, 2), true));
            }
        }

        private bool IsWeakOrStrong { get; }

        private WeakOrStrong MetarWeakOrStrong { get; }

        private bool IsWeatherPhenomenon { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsWeatherPhenomenon)
                    return result.ToString();

                result.Append("Погодное явление: ");
                if (IsWeakOrStrong)
                    result.Append(MetarWeakOrStrong.GetMetarDescription() + " ");

                foreach (var phenomenon in _metarWeatherPhenomenon)
                    result.Append(phenomenon.GetMetarDescription() + " ");

                return result.ToString();
            }
        }
    }
}