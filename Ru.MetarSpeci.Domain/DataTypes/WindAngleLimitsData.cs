using System;

namespace Ru.MetarSpeci.DataTypes
{
    public class WindAngleLimitsData
    {
        public WindAngleLimitsData(string windAngleLimits)
        {
            var angle = windAngleLimits.Substring(0, 3);
            LowerAngleLimit = Convert.ToInt32(angle);

            angle = windAngleLimits.Substring(4, 3);
            UpperAngleLimit = Convert.ToInt32(angle);
        }

        public int LowerAngleLimit { get; private set; }

        public int UpperAngleLimit { get; private set; }
    }
}