using System;
using System.Text;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class WindData
    {
        private readonly WindAngleLimitsData _angleLimits;

        public WindData(string windString, WindAngleLimitsData metarWindAngleLimits)
        {
            if (metarWindAngleLimits != null)
            {
                IsAngleLimits = true;
                _angleLimits = metarWindAngleLimits;
            }

            if (string.IsNullOrEmpty(windString))
                return;

            IsWind = true;

            if (windString.Substring(0, 5) == "00000")
            {
                IsCalm = true;
                GetMetarWindUnit(windString);
                return;
            }
            if (windString.Substring(0, 3) == "VRB")
            {
                IsVariable = true;
                GetMetarWindSpeed(windString);
                GetMetarWindUnit(windString);
                return;
            }

            GetMetarWindAngle(windString);
            GetMetarWindSpeed(windString);

            if (windString[5] == 'G')
            {
                IsWithGusts = true;
                GustsSpeed = Convert.ToInt32(windString.Substring(6, 2));
            }

            GetMetarWindUnit(windString);
        }

        private bool IsWind { get; }

        private bool IsCalm { get; }

        private int Angle { get; set; }

        private int Speed { get; set; }

        private WindUnit Unit { get; set; }

        private bool IsWithGusts { get; }

        private int GustsSpeed { get; }

        private bool IsVariable { get; }

        private bool IsAngleLimits { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();
                if (IsWind)
                {
                    if (IsCalm)
                    {
                        result.Append("Штиль ");
                        return result.ToString();
                    }
                    if (IsVariable)
                    {
                        result.Append("Ветер переменный ");
                        result.Append(Speed + " ");
                        result.Append(Unit.GetMetarDescription() + " ");
                        return result.ToString();
                    }

                    result.Append("Ветер ");
                    result.Append(Angle + "° ");
                    result.Append(Speed + " ");

                    if (IsWithGusts)
                    {
                        result.Append("с порывами ");
                        result.Append(GustsSpeed + " ");
                    }

                    result.Append(Unit.GetMetarDescription() + " ");
                }
                if (!IsAngleLimits)
                    return result.ToString();

                if (IsWind)
                    result.Append("Направление ветра менялось в секторе между ");

                result.Append("направление ветра менялось в секторе между ");
                result.Append(_angleLimits.LowerAngleLimit + "° ");
                result.Append("и ");
                result.Append(_angleLimits.UpperAngleLimit + "° ");

                return result.ToString();
            }
        }

        #region Helpers

        private void GetMetarWindUnit(string windString)
        {
            if (char.IsLetter(windString[windString.Length - 3]))
                Unit =
                    (WindUnit)
                        Enum.Parse(typeof(WindUnit), windString.Substring(windString.Length - 3, 3));
            else
                Unit =
                    (WindUnit)
                        Enum.Parse(typeof(WindUnit), windString.Substring(windString.Length - 2, 2));
        }

        private void GetMetarWindSpeed(string windString)
        {
            Speed = Convert.ToInt32(windString.Substring(3, 2));
        }

        private void GetMetarWindAngle(string windString)
        {
            Angle = Convert.ToInt32(windString.Substring(0, 3));
        }

        #endregion
    }
}