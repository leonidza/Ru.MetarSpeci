using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class RunwayVisibilityDecoder : Decoder<RunwayVisibilityData>
    {
        public override string Description => "Runway visibility";

        public override string RegExPattern => @"((R\d{2})(R|C|L|RR|LL)?/(M|P)?(\d{4})(V\d{4})?(U|D|N)?)\s";

        public override RunwayVisibilityData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return null;

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new RunwayVisibilityData(match.ToString());
        }
    }
}