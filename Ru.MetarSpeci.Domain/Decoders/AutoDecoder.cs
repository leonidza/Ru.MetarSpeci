using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class AutoDecoder : Decoder<AutoData>
    {
        public override string Description => "Auto prefix";

        public override string RegExPattern => "(\\sAUTO)";

        public override AutoData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new AutoData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new AutoData(match.ToString());
        }
    }
}