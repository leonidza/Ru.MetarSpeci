using System;
using System.Linq;

namespace Ru.MetarSpeci
{
    public static class MetarSpeciDescriptionAttirubeExtensions
    {
        public static string GetMetarDescription(this Enum enumeration)
        {
            var attribute = enumeration.GetType().GetMember(
                enumeration.ToString())[0].GetCustomAttributes(typeof (MetarSpeciDescriptionAttribute), false)
                .Cast<MetarSpeciDescriptionAttribute>().SingleOrDefault();

            return attribute == null ? "" : attribute.Description;
        }
    }
}