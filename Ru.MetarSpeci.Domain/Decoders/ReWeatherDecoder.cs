using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class ReWeatherDecoder : Decoder<ReWeatherData>
    {
        public override string Description => "Re weather phenomenon";

        public override string RegExPattern => @"\sRE(TS|SH|FZ|BL|DR|DZ|RA|SN|GS|PL|IC|GR|SG|FG|BR|SA|DU|HZ|FU|VA|PO|SQ|FC|DS|SS|VC)?(TS|SH|FZ|BL|DR|DZ|RA|SN|GS|PL|IC|GR|SG|FG|BR|SA|DU|HZ|FU|VA|PO|SQ|FC|DS|SS|VC)";

        public override ReWeatherData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new ReWeatherData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new ReWeatherData(match.ToString());
        }
    }
}