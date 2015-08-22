using System;

namespace Ru.MetarSpeci
{
    public class MetarSpeciDescriptionAttribute : Attribute
    {
        public MetarSpeciDescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }
}