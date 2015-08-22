using System;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class RunwayVisibilityData
    {
        public RunwayVisibilityData(string runwayVisibility)
        {
            Number = Convert.ToInt32(runwayVisibility.Substring(1, 2));

            var positionString = runwayVisibility.Substring(3, 2);
            if (positionString[0] != '/')
            {
                IsPosition = true;
                if (positionString[1] != '/')
                    Position = (Position)Enum.Parse(typeof(Position), positionString, true);
                else
                    Position = (Position)Enum.Parse(typeof(Position), positionString.Substring(0, 1), true);
            }

            var slashPosition = runwayVisibility.IndexOf('/');

            var vPosition = runwayVisibility.IndexOf('V');
            if (vPosition != -1)
            {
                IsVisibilityСhanges = true;

                LowerVisiblityLimit = Convert.ToInt32(runwayVisibility.Substring(slashPosition + 1, 4));

                UpperVisiblityLimit = Convert.ToInt32(runwayVisibility.Substring(slashPosition + 6, 4));
            }
            else if (!char.IsDigit(runwayVisibility[slashPosition + 1]))
            {
                IsMoreOrLess = true;
                MoreOrLess =
                    (MoreOrLess)Enum.Parse(typeof(MoreOrLess), runwayVisibility.Substring(slashPosition + 1, 1), true);

                Visibility = Convert.ToInt32(runwayVisibility.Substring(slashPosition + 2, 4));
            }
            else
                Visibility = Convert.ToInt32(runwayVisibility.Substring(slashPosition + 1, 4));

            if (char.IsDigit(runwayVisibility[runwayVisibility.Length - 1]))
                return;

            IsTrendChanges = true;
            TrendChanges =
                (TrendChanges)
                    Enum.Parse(typeof(TrendChanges), runwayVisibility.Substring(runwayVisibility.Length - 2, 1),
                        true);
        }

        public int Number { get; private set; }

        public bool IsTrendChanges { get; private set; }

        public TrendChanges TrendChanges { get; private set; }

        public bool IsPosition { get; private set; }

        public Position Position { get; private set; }

        public int Visibility { get; }

        public bool IsVisibilityСhanges { get; private set; }

        public int LowerVisiblityLimit { get; private set; }

        public int UpperVisiblityLimit { get; private set; }

        public bool IsMoreOrLess { get; private set; }

        public MoreOrLess MoreOrLess { get; private set; }
    }
}