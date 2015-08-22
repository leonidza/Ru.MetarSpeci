using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class WindShearDecoder : Decoder<WindShearData>
    {
        public override string Description => "Wind shear";

        public override string RegExPattern => @"(WS (R\d{2})?(ALL RWY)?)";

        public override WindShearData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new WindShearData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new WindShearData(match.ToString());
        }
    }
}