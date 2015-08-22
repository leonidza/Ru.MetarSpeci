using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class HorizontalVisibilityWithDirectionDecoder : Decoder<VisibilityWithDirectionData>
    {
        public override string Description => "Horizontal visibility with direction";

        public override string RegExPattern => @"((\d{4})(NE|SW|NW|SE|N|E|S|W))";

        public override VisibilityWithDirectionData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return null;

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new VisibilityWithDirectionData(match.ToString());
        }
    }
}