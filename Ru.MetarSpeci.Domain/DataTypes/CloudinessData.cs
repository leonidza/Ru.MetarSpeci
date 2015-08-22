using System;
using System.Text;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class CloudinessData
    {
        public CloudinessData(string cloudinessData)
        {
            if (string.IsNullOrEmpty(cloudinessData))
                return;

            IsCloudiness = true;

            if (!(char.IsDigit(cloudinessData[2])) && cloudinessData[2] != '/')
                MetarCloudiness =
                    (MetarSpeciCloudiness)
                        Enum.Parse(typeof(MetarSpeciCloudiness), cloudinessData.Substring(0, 3), true);
            else
                MetarCloudiness =
                    (MetarSpeciCloudiness)
                        Enum.Parse(typeof(MetarSpeciCloudiness), cloudinessData.Substring(0, 2), true);

            if (cloudinessData.Length <= 3)
                return;

            if (cloudinessData.IndexOf("///", StringComparison.InvariantCultureIgnoreCase) != -1)
                IsBelowLevelOfRunway = true;
            else
            {
                IsLowLimit = true;

                if (char.IsDigit(cloudinessData[2]))
                    LowLimit = Convert.ToInt32(cloudinessData.Substring(2, 3)) * 30;
                else
                    LowLimit = Convert.ToInt32(cloudinessData.Substring(3, 3)) * 30;
            }

            if (cloudinessData.Substring(cloudinessData.Length - 2) == "CB" ||
                cloudinessData.Substring(cloudinessData.Length - 3) == "TCU")
            {
                IsCloudsType = true;
                CloudsType = cloudinessData.Substring(cloudinessData.Length - 2) == "CB"
                    ? CloudsType.CB
                    : CloudsType.TCU;
            }
        }

        private bool IsCloudiness { get; }
        private MetarSpeciCloudiness MetarCloudiness { get; }
        private bool IsLowLimit { get; }
        private int LowLimit { get; }
        private bool IsBelowLevelOfRunway { get; }
        private bool IsCloudsType { get; }
        private CloudsType CloudsType { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsCloudiness)
                    return result.ToString();

                if (MetarCloudiness == MetarSpeciCloudiness.VV && IsBelowLevelOfRunway)
                    result.Append("Информации о вертикальной видимости не имеется ");

                else
                {
                    result.Append(MetarCloudiness.GetMetarDescription());

                    if (IsBelowLevelOfRunway)
                    {
                        result.Append(", ниже уровня ВПП ");
                    }
                    if (IsLowLimit)
                    {
                        result.Append(", нижняя граница облаков ");
                        result.Append(LowLimit + "м");
                    }

                    if (!IsCloudsType)
                        return result.ToString();

                    result.Append(", ");
                    result.Append(CloudsType.GetMetarDescription());
                }

                return result.ToString();
            }
        }
    }
}