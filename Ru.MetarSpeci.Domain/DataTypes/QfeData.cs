using System;
using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class QfeData
    {
        public QfeData(string match)
        {
            if (string.IsNullOrEmpty(match))
                return;

            IsQfe = true;
            Pressure = Convert.ToInt32(match.Substring(3, 3));
        }

        private bool IsQfe { get; }
        private int Pressure { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsQfe)
                    return result.ToString();

                result.Append("Давление на аэродроме ");
                result.Append(Pressure + "мм.рт.ст ");

                return result.ToString();
            }
        }
    }
}