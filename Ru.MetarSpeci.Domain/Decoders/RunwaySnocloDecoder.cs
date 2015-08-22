using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class RunwaySnocloDecoder : Decoder<RunwaySnocloData>
    {
        public override string Description => "Runway snoclo";

        public override string RegExPattern => "R/SNOCLO";

        public override RunwaySnocloData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new RunwaySnocloData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new RunwaySnocloData(match.ToString());
        }
    }
}