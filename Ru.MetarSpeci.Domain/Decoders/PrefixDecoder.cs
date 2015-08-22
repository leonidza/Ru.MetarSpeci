using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class PrefixDecoder : Decoder<PrefixData>
    {
        public override string Description => "METAR/SPECI prefix";

        public override string RegExPattern => "(^METAR)|(^SPECI)";

        public override PrefixData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                throw new MetarSpeciDecodingException(Description);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new PrefixData(match.ToString());
        }
    }
}