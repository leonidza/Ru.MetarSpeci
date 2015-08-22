using System;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class VisibilityWithDirectionData
    {
        public VisibilityWithDirectionData(string horizontalVisibilityWithDirection)
        {
            Visibility = Convert.ToInt32(horizontalVisibilityWithDirection.Substring(0, 4));

            if (horizontalVisibilityWithDirection.Length == 5)
                Direction =
                    (Direction)
                        Enum.Parse(typeof(Direction),
                            horizontalVisibilityWithDirection.Substring(horizontalVisibilityWithDirection.Length - 1, 1),
                            true);
            else
                Direction =
                    (Direction)
                        Enum.Parse(typeof(Direction),
                            horizontalVisibilityWithDirection.Substring(horizontalVisibilityWithDirection.Length - 2, 2),
                            true);
        }

        public int Visibility { get; private set; }

        public Direction Direction { get; private set; }
    }
}