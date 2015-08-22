using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class CavokDecoder : Decoder<CavokData>
    {
        public override string Description => "Cavok";

        public override string RegExPattern => "(CAVOK)";

        public override CavokData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new CavokData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new CavokData(match.ToString());
        }
    }
}