using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class HorizontalVisibilityDecoder : Decoder<HorizontalVisibilityData>
    {
        public override string Description => "Horizontal visibility";

        public override string RegExPattern => @"(\s\d{4}(\s|$))";

        public override HorizontalVisibilityData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return null;

            var visibilityMatch = Regex.Match(code, RegExPattern, RegexOptions);
            return new HorizontalVisibilityData(visibilityMatch.ToString());
        }
    }
}