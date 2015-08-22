using System;

namespace Ru.MetarSpeci.DataTypes
{
    public class HorizontalVisibilityData
    {
        public HorizontalVisibilityData(string horizontalVisibility)
        {
            Visibility = Convert.ToInt32(horizontalVisibility);
        }

        public int Visibility { get; private set; }
    }
}