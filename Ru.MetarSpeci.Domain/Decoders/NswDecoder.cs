using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class NswDecoder : Decoder<NswData>
    {
        public override string Description => "Nsw";

        public override string RegExPattern => "\\sNsw";

        public override NswData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new NswData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new NswData(match.ToString());
        }
    }
}