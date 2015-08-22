using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class RunwayInformationDecoder : Decoder<RunwayInformationData>
    {
        public override string Description => "Runway information";

        public override string RegExPattern => @"(((R)?(\d{2})(/)?(\d|/)(\d|/)(\d{2}|//)(\d{2}|//))" + "|" +
                                               @"((R)?(\d{2})(/)?(CLRD\d{2})))";

        public override RunwayInformationData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new RunwayInformationData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new RunwayInformationData(match.ToString());
        }
    }
}