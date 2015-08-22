using System;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class PrefixData
    {
        public PrefixData(string match)
        {
            MetarPrefix = (Prefix)Enum.Parse(typeof(Prefix), match, true);
        }

        private Prefix MetarPrefix { get; }

        public string Description => MetarPrefix.GetMetarDescription() + " ";
    }
}