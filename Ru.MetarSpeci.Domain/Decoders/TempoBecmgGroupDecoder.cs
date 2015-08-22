using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class TempoBecmgGroupDecoder : Decoder<TempoBecmgGroupData>
    {
        private readonly CavokDecoder _cavokDecoder = new CavokDecoder();
        private readonly CloudinessDecoder _cloudinessDecoder = new CloudinessDecoder();
        private readonly NswDecoder _nswDecoder = new NswDecoder();
        private readonly PressureDecoder _pressureDecoder = new PressureDecoder();
        private readonly TemperatureDecoder _temperatureDecoder = new TemperatureDecoder();
        private readonly TimeDecoder _timeDecoder = new TimeDecoder();
        private readonly VisibilityDecoder _visibilityDecoder = new VisibilityDecoder();
        private readonly WeatherDecoder _weatherDecoder = new WeatherDecoder();
        private readonly WindDecoder _windDecoder = new WindDecoder();

        public override string Description => "Tempo Becmg group";

        public override string RegExPattern => "(BECMG|TEMPO)";

        public override TempoBecmgGroupData Decode(string code)
        {
            var match = Regex.Match(code, RegExPattern, RegexOptions);
            var time = _timeDecoder.Decode(code);
            var wind = _windDecoder.Decode(code);
            var visibility = _visibilityDecoder.Decode(code);
            var weather = _weatherDecoder.Decode(code);
            var nsw = _nswDecoder.Decode(code);
            var cloudiness = _cloudinessDecoder.Decode(code);
            var cavok = _cavokDecoder.Decode(code);
            var temperature = _temperatureDecoder.Decode(code);
            var pressure = _pressureDecoder.Decode(code);

            return new TempoBecmgGroupData(match.ToString(), time, wind, visibility, weather, nsw, cloudiness, cavok,
                temperature, pressure);
        }
    }
}