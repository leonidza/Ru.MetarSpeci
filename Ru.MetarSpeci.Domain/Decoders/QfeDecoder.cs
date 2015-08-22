using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class QfeDecoder : Decoder<QfeData>
    {
        public override string Description => "Qfe";

        public override string RegExPattern => @"(QFE\d{3})";

        public override QfeData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new QfeData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new QfeData(match.ToString());
        }
    }
}