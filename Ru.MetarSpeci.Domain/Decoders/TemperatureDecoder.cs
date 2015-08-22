using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class TemperatureDecoder : Decoder<TemperatureData>
    {
        public override string Description => "Temperature";

        public override string RegExPattern => @"((M)?[^R]\d{2}/(M)?\d{2})";

        public override TemperatureData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new TemperatureData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new TemperatureData(match.ToString());
        }
    }
}