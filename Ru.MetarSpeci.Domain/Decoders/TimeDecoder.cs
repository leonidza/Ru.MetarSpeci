using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class TimeDecoder : Decoder<TimeData>
    {
        public override string Description => "Time";

        public override string RegExPattern => @"(FM|TL|AT)\d{4}";

        public override TimeData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new TimeData(null);

            var match = Regex.Match(code, RegExPattern, RegexOptions);
            return new TimeData(match.ToString());
        }
    }
}