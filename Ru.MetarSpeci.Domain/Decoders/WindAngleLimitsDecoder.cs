using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class WindAngleLimitsDecoder : Decoder<WindAngleLimitsData>
    {
        public override string Description => "Wind angle limits";

        public override string RegExPattern => @"(\d{3})V(\d{3})";

        public override WindAngleLimitsData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return null;

            var windAngleLimits = Regex.Match(code, RegExPattern, RegexOptions);
            return new WindAngleLimitsData(windAngleLimits.ToString());
        }
    }
}