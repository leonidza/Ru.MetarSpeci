using System.Text.RegularExpressions;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class DayTimeDecoder : Decoder<DayTimeData>
    {
        public override string Description => "Day - Time";

        public override string RegExPattern => @"(\d{2})(\d{2})(\d{2})Z";

        public override DayTimeData Decode(string code)
        {
            if (!Regex.IsMatch(code, RegExPattern, RegexOptions))
                return new DayTimeData(null);

            var dayTime = Regex.Match(code, RegExPattern, RegexOptions);
            return new DayTimeData(dayTime.ToString());
        }
    }
}