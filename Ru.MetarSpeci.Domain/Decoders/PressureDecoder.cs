using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class PressureDecoder : Decoder<PressureData>
    {
        public override string Description => "Pressure";

        public override string RegExPattern => @"(Q|A)\d{4}";

        public override PressureData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new PressureData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new PressureData(match.ToString());
        }
    }
}