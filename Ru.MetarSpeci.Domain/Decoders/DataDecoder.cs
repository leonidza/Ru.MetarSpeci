using Ru.MetarSpeci.DataTypes;

namespace Ru.MetarSpeci.Decoders
{
    public class DataDecoder
    {
        public Data Decode(string code)
        {
            return new Data(code);
        }
    }
}