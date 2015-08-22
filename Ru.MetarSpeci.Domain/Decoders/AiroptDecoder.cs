using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class AiroptDecoder : Decoder<AirportData>
    {
        public override string Description => "Airport code";

        public override string RegExPattern => @"\s(?!.*METAR|.*SPECI)[A-Z]{4}";

        public override AirportData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                throw new MetarSpeciDecodingException(Description);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new AirportData(match.ToString());
        }
    }
}