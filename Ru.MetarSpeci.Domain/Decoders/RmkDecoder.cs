using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class RmkDecoder : Decoder<RmkData>
    {
        public override string Description => "RMK";

        public override string RegExPattern => "RMK";

        public override RmkData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new RmkData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new RmkData(match.ToString());
        }
    }
}