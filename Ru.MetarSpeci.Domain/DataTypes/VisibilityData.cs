using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class VisibilityData
    {
        private readonly HorizontalVisibilityData _metarHorizontalVisibility;

        private readonly VisibilityWithDirectionData _metarHorizontalVisibilityWithDirection;

        private readonly RunwayVisibilityData _metarRunwayVisibility;

        public VisibilityData(HorizontalVisibilityData horizontalVisibility,
            VisibilityWithDirectionData horizontalVisibilityWithDirection, RunwayVisibilityData runwayVisibility)
        {
            if (horizontalVisibility != null)
            {
                IsHorizontalVisibility = true;
                _metarHorizontalVisibility = horizontalVisibility;
            }

            if (horizontalVisibilityWithDirection != null)
            {
                IsHorizontalVisibilityWithDirection = true;
                _metarHorizontalVisibilityWithDirection = horizontalVisibilityWithDirection;
            }

            if (runwayVisibility != null)
            {
                IsRunwayVisibility = true;
                _metarRunwayVisibility = runwayVisibility;
            }
        }

        private bool IsHorizontalVisibility { get; }

        private bool IsHorizontalVisibilityWithDirection { get; }

        private bool IsRunwayVisibility { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (IsHorizontalVisibility)
                {
                    result.Append("Горизонтальная видимость ");
                    if (_metarHorizontalVisibility.Visibility == 9999)
                        result.Append("10 км и выше ");
                    else
                        result.Append(_metarHorizontalVisibility.Visibility + "м ");
                }

                if (IsHorizontalVisibilityWithDirection)
                {
                    if (IsHorizontalVisibility)
                        result.AppendLine();

                    result.Append("Горизонтальная видимость ");
                    result.Append(_metarHorizontalVisibilityWithDirection.Visibility + "м ");
                    result.Append("в ");
                    result.Append(_metarHorizontalVisibilityWithDirection.Direction.GetMetarDescription() +
                                  " направлении ");
                }

                if (!IsRunwayVisibility)
                    return result.ToString();

                if (IsHorizontalVisibility || IsHorizontalVisibilityWithDirection)
                    result.AppendLine();

                result.Append("На ВПП ");
                result.Append(_metarRunwayVisibility.Number + " ");

                if (_metarRunwayVisibility.IsPosition)
                    result.Append(_metarRunwayVisibility.Position.GetMetarDescription() + " ");

                result.Append("видимость ");

                if (_metarRunwayVisibility.IsVisibilityСhanges)
                {
                    result.Append("меняется от ");
                    result.Append(_metarRunwayVisibility.LowerVisiblityLimit + " ");
                    result.Append("до ");
                    result.Append(_metarRunwayVisibility.UpperVisiblityLimit);
                }
                else
                {
                    if (_metarRunwayVisibility.IsMoreOrLess)
                        result.Append(_metarRunwayVisibility.MoreOrLess.GetMetarDescription() + " ");

                    result.Append(_metarRunwayVisibility.Visibility + "м");
                }

                if (_metarRunwayVisibility.IsTrendChanges)
                {
                    result.Append(", ");
                    result.Append(_metarRunwayVisibility.TrendChanges.GetMetarDescription());
                }

                return result.ToString();
            }
        }
    }
}