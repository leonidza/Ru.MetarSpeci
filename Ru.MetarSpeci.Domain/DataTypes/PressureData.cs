using System;
using System.Text;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class PressureData
    {
        public PressureData(string match)
        {
            if (string.IsNullOrEmpty(match))
                return;

            IsPressure = true;

            MetarPressureUnit = (PressureUnit)Enum.Parse(typeof(PressureUnit), match.Substring(0, 1), true);

            if (MetarPressureUnit == PressureUnit.A)
            {
                IntegralPart = Convert.ToInt32(match.Substring(1, 2));
                FractialPart = Convert.ToInt32(match.Substring(3, 2));
            }
            else
                IntegralPart = Convert.ToInt32(match.Substring(1, 4));
        }

        private bool IsPressure { get; }
        private PressureUnit MetarPressureUnit { get; }
        private int IntegralPart { get; }
        private int FractialPart { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsPressure)
                    return result.ToString();

                result.Append("QNH = ");

                if (MetarPressureUnit == PressureUnit.A)
                {
                    result.Append(IntegralPart + "," + FractialPart + " ");
                    result.Append(MetarPressureUnit.GetMetarDescription());
                }
                else
                {
                    result.Append(IntegralPart + " ");
                    result.Append(MetarPressureUnit.GetMetarDescription());
                }

                return result.ToString();
            }
        }
    }
}