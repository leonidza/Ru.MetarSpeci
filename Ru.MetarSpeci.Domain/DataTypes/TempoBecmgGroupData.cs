using System;
using System.Text;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class TempoBecmgGroupData
    {
        public TempoBecmgGroupData(string match, TimeData time, WindData wind,
            VisibilityData visibility, WeatherData weather,
            NswData nsw, CloudinessData cloudiness, CavokData cavok,
            TemperatureData temperature, PressureData pressure)
        {
            if (string.IsNullOrEmpty(match))
                return;

            IsGroup = true;
            MetarSpeciBecmgTempo = (BecmgTempo)Enum.Parse(typeof(BecmgTempo), match, true);
            Time = time;
            Wind = wind;
            Visibility = visibility;
            Weather = weather;
            Nsw = nsw;
            Cloudiness = cloudiness;
            Cavok = cavok;
            Temperature = temperature;
            Pressure = pressure;
        }

        private bool IsGroup { get; }

        private BecmgTempo MetarSpeciBecmgTempo { get; }

        private TimeData Time { get; }

        private WindData Wind { get; }

        private VisibilityData Visibility { get; }

        private WeatherData Weather { get; }

        private NswData Nsw { get; }

        private CloudinessData Cloudiness { get; }

        private CavokData Cavok { get; }

        private TemperatureData Temperature { get; }

        private PressureData Pressure { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsGroup)
                    return result.ToString();

                result.AppendLine(MetarSpeciBecmgTempo.GetMetarDescription() + ": ");
                AppendWithTabIfNotEmpty(result, Time.Description);
                AppendWithTabIfNotEmpty(result, Wind.Description);
                AppendWithTabIfNotEmpty(result, Visibility.Description);
                AppendWithTabIfNotEmpty(result, Weather.Description);
                AppendWithTabIfNotEmpty(result, Nsw.Description);
                AppendWithTabIfNotEmpty(result, Cloudiness.Description);
                AppendWithTabIfNotEmpty(result, Cavok.Description);
                AppendWithTabIfNotEmpty(result, Temperature.Description);
                AppendWithTabIfNotEmpty(result, Pressure.Description);

                return result.ToString();
            }
        }

        private static void AppendWithTabIfNotEmpty(StringBuilder builder, string text)
        {
            if (!string.IsNullOrEmpty(text))
                builder.AppendLine("\t" + text);
        }
    }
}