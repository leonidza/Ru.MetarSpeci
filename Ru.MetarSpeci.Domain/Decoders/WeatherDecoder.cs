using System.Text;
using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class WeatherDecoder : Decoder<WeatherData>
    {
        public override string Description => "Weather phenomenon";

        public override string RegExPattern
        {
            get
            {
                var pattern = new StringBuilder();
                pattern.Append("(");
                pattern.Append(@"(\s(\-|\+)?(MIFG|BCFG))");
                pattern.Append("|");
                pattern.Append(
                    @"(\s(\-|\+)?(TS|SH|FZ|BL|DR|DZ|RA|SN|GS|PL|IC|GR|SG|FG|BR|SA|DU|HZ|FU|VA|PO|SQ|FC|DS|SS|VC)?(TS|SH|FZ|BL|DR|DZ|RA|SN|GS|PL|IC|GR|SG|FG|BR|SA|DU|HZ|FU|VA|PO|SQ|FC|DS|SS|VC))");
                pattern.Append(")");
                return pattern.ToString();
            }
        }

        public override WeatherData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new WeatherData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new WeatherData(match.ToString());
        }
    }
}