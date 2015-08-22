using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class WindDecoder : Decoder<WindData>
    {
        private readonly WindAngleLimitsDecoder _metarWindAngleLimitsDecoder = new WindAngleLimitsDecoder();

        public override string Description => "Wind";

        public override string RegExPattern => @"((\d{3}|VRB)(\d{2,3})(G(\d{2,3}))?(KT|MPS|KMH))";

        public override WindData Decode(string code)
        {
            var angleLimits = _metarWindAngleLimitsDecoder.Decode(code);
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new WindData(null, angleLimits);

            var wind = Regex.Match(code, RegExPattern, RegexOptions);
            return new WindData(wind.ToString(), angleLimits);
        }
    }
}