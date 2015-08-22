using System;
using System.Text;
using Ru.MetarSpeci.Decoders;

namespace Ru.MetarSpeci.DataTypes
{
    public class Data
    {
        private readonly string _code;

        public Data(string code)
        {
            _code = code;
            var inputCode = code;

            var firstIndexOfBecmg = inputCode.IndexOf("BECMG", StringComparison.InvariantCultureIgnoreCase);
            var firstIndexOfTempo = inputCode.IndexOf("TEMPO", StringComparison.InvariantCultureIgnoreCase);
            var firstIndexOfNosig = inputCode.IndexOf("NOSIG", StringComparison.InvariantCultureIgnoreCase);

            var endIndexOfFirstPartOfCode = inputCode.Length;

            if (firstIndexOfBecmg == -1)
            {
                firstIndexOfBecmg = endIndexOfFirstPartOfCode;
            }
            if (firstIndexOfTempo == -1)
            {
                firstIndexOfTempo = endIndexOfFirstPartOfCode;
            }
            if (firstIndexOfNosig == -1)
            {
                firstIndexOfNosig = endIndexOfFirstPartOfCode;
            }

            if (firstIndexOfBecmg < firstIndexOfTempo && firstIndexOfBecmg < firstIndexOfNosig)
            {
                endIndexOfFirstPartOfCode = firstIndexOfBecmg;
            }
            if (firstIndexOfTempo < firstIndexOfBecmg && firstIndexOfTempo < firstIndexOfNosig)
            {
                endIndexOfFirstPartOfCode = firstIndexOfTempo;
            }
            if (firstIndexOfNosig < firstIndexOfBecmg && firstIndexOfNosig < firstIndexOfTempo)
            {
                endIndexOfFirstPartOfCode = firstIndexOfNosig;
            }

            var firstPartOfCode = Substring(inputCode, 0, endIndexOfFirstPartOfCode);
            Prefix = _prefixDecoder.Decode(firstPartOfCode);
            Airport = _metarSpeciAiroptDecoder.Decode(firstPartOfCode);
            Auto = _autoDecoder.Decode(firstPartOfCode);
            DayTime = _dayTimeDecoder.Decode(firstPartOfCode);
            Wind = _windDecoder.Decode(firstPartOfCode);
            Visibility = _visibilityDecoder.Decode(firstPartOfCode);
            Weather = _weatherDecoder.Decode(firstPartOfCode);
            Nsw = _nswDecoder.Decode(firstPartOfCode);
            Cloudiness = _cloudinessDecoder.Decode(firstPartOfCode);
            Cavok = _cavokDecoder.Decode(firstPartOfCode);
            Temperature = _temperatureDecoder.Decode(firstPartOfCode);
            Pressure = _pressureDecoder.Decode(firstPartOfCode);
            ReWeather = _reWeatherDecoder.Decode(firstPartOfCode);
            WindShear = _metarSpeciWindShearDecoder.Decode(firstPartOfCode);
            RunwayInformation = _runwayInformationDecoder.Decode(firstPartOfCode);
            RunwaySnoclo = _runwaySnocloDecoder.Decode(firstPartOfCode);

            var secondPartOfCode = Substring(inputCode, endIndexOfFirstPartOfCode, firstIndexOfNosig);
            TempoBecmgGroups = _tempoBecmgGroupsDecoder.Decode(secondPartOfCode);

            var thirdPartOfCode = inputCode;
            Nosig = _nosigDecoder.Decode(thirdPartOfCode);
            Rmk = _rmkDecoder.Decode(thirdPartOfCode);
            Qfe = _qfeDecoder.Decode(thirdPartOfCode);
        }

        public string GetCode()
        {
            return _code;
        }

        public string GetHumanReadableRepresentation()
        {
            var result = new StringBuilder();

            AppendIfNotEmpty(result, Prefix.Description);
            AppendIfNotEmpty(result, Airport.Description);
            AppendIfNotEmpty(result, Auto.Description);
            AppendIfNotEmpty(result, DayTime.Description);
            AppendIfNotEmpty(result, Wind.Description);
            AppendIfNotEmpty(result, Visibility.Description);
            AppendIfNotEmpty(result, Weather.Description);
            AppendIfNotEmpty(result, Nsw.Description);
            AppendIfNotEmpty(result, Cloudiness.Description);
            AppendIfNotEmpty(result, Cavok.Description);
            AppendIfNotEmpty(result, Temperature.Description);
            AppendIfNotEmpty(result, Pressure.Description);
            AppendIfNotEmpty(result, ReWeather.Description);
            AppendIfNotEmpty(result, WindShear.Description);
            AppendIfNotEmpty(result, RunwayInformation.Description);
            AppendIfNotEmpty(result, RunwaySnoclo.Description);
            AppendIfNotEmpty(result, TempoBecmgGroups.Description);
            AppendIfNotEmpty(result, Nosig.Description);
            AppendIfNotEmpty(result, Rmk.Description);
            AppendIfNotEmpty(result, Qfe.Description);

            return result.ToString();
        }

        private static string Substring(string str, int startIndex, int endIndex)
        {
            var result = new char[endIndex - startIndex];
            for (int i = startIndex, k = 0; i < endIndex; i++, k++)
            {
                result[k] = str[i];
            }
            return new string(result);
        }

        private static void AppendIfNotEmpty(StringBuilder builder, string text)
        {
            if (text == "")
            {
                return;
            }
            builder.AppendLine(text);
        }

        #region Data

        public PrefixData Prefix { get; }
        public AirportData Airport { get; }
        public AutoData Auto { get; }
        public DayTimeData DayTime { get; }
        public WindData Wind { get; }
        public VisibilityData Visibility { get; }
        public WeatherData Weather { get; }
        public NswData Nsw { get; }
        public CloudinessData Cloudiness { get; }
        public CavokData Cavok { get; }
        public TemperatureData Temperature { get; }
        public PressureData Pressure { get; }
        public ReWeatherData ReWeather { get; }
        public WindShearData WindShear { get; }
        public RunwayInformationData RunwayInformation { get; }
        public RunwaySnocloData RunwaySnoclo { get; }
        public TempoBecmgGroupsData TempoBecmgGroups { get; }
        public NosigData Nosig { get; }
        public RmkData Rmk { get; }
        public QfeData Qfe { get; }

        #endregion

        #region Decoders

        private readonly PrefixDecoder _prefixDecoder = new PrefixDecoder();
        private readonly AiroptDecoder _metarSpeciAiroptDecoder = new AiroptDecoder();
        private readonly AutoDecoder _autoDecoder = new AutoDecoder();
        private readonly DayTimeDecoder _dayTimeDecoder = new DayTimeDecoder();
        private readonly WindDecoder _windDecoder = new WindDecoder();
        private readonly VisibilityDecoder _visibilityDecoder = new VisibilityDecoder();
        private readonly WeatherDecoder _weatherDecoder = new WeatherDecoder();
        private readonly NswDecoder _nswDecoder = new NswDecoder();
        private readonly CloudinessDecoder _cloudinessDecoder = new CloudinessDecoder();
        private readonly CavokDecoder _cavokDecoder = new CavokDecoder();
        private readonly TemperatureDecoder _temperatureDecoder = new TemperatureDecoder();
        private readonly PressureDecoder _pressureDecoder = new PressureDecoder();
        private readonly ReWeatherDecoder _reWeatherDecoder = new ReWeatherDecoder();
        private readonly WindShearDecoder _metarSpeciWindShearDecoder = new WindShearDecoder();
        private readonly RunwayInformationDecoder _runwayInformationDecoder = new RunwayInformationDecoder();
        private readonly RunwaySnocloDecoder _runwaySnocloDecoder = new RunwaySnocloDecoder();
        private readonly TempoBecmgGroupsDecoder _tempoBecmgGroupsDecoder = new TempoBecmgGroupsDecoder();
        private readonly NosigDecoder _nosigDecoder = new NosigDecoder();
        private readonly RmkDecoder _rmkDecoder = new RmkDecoder();
        private readonly QfeDecoder _qfeDecoder = new QfeDecoder();

        #endregion
    }
}