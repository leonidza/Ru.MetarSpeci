using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class CloudinessDecoder : Decoder<CloudinessData>
    {
        public override string Description => "Cloudiness";

        public override string RegExPattern => @"(OVC|FEW|SCT|BKN|OVC|VV|SKC|NSC)(\d{3}|///)?(CB|TCU)?";

        public override CloudinessData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new CloudinessData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new CloudinessData(match.ToString());
        }
    }
}