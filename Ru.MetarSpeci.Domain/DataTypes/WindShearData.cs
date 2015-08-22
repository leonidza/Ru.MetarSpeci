using System;
using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class WindShearData
    {
        public WindShearData(string match)
        {
            if (string.IsNullOrEmpty(match))
                return;

            IsWindShear = true;

            var indexOfR = match.IndexOf("r", StringComparison.InvariantCultureIgnoreCase);
            if (indexOfR != -1 && char.IsDigit(match[indexOfR + 1]))
                RunwayNumber = Convert.ToInt32(match.Substring(indexOfR + 1, 2));
            else
                IsWindShearAtAllRunways = true;
        }

        private bool IsWindShear { get; }

        private bool IsWindShearAtAllRunways { get; }

        private int RunwayNumber { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsWindShear)
                    return result.ToString();

                result.Append("Сдвиг ветра в приземном слое на ");
                if (IsWindShearAtAllRunways)
                    result.Append(" всех ВПП ");
                else
                    result.Append(" ВПП" + RunwayNumber + " ");

                return result.ToString();
            }
        }
    }
}