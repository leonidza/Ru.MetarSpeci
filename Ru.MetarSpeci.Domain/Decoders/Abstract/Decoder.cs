using System.Text.RegularExpressions;

namespace Ru.MetarSpeci.Decoders.Abstract
{
    public abstract class Decoder<T>
    {
        protected RegexOptions RegexOptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;

        public abstract string Description { get; }
        public abstract string RegExPattern { get; }

        public abstract T Decode(string code);
    }
}