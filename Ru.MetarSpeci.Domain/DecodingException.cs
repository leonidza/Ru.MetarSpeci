using System;

namespace Ru.MetarSpeci
{
    public class MetarSpeciDecodingException : Exception
    {
        public MetarSpeciDecodingException(string description)
        {
            throw new ArgumentException($"Failed to decode: {description}");
        }
    }
}