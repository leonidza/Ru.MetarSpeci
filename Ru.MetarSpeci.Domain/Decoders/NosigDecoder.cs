using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class NosigDecoder : Decoder<NosigData>
    {
        public override string Description => "Nosig";

        public override string RegExPattern => "NOSIG";

        public override NosigData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new NosigData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new NosigData(match.ToString());
        }
    }
}