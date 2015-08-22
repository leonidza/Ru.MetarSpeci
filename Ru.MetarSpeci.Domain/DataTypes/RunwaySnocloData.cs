using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class RunwaySnocloData
    {
        public RunwaySnocloData(string match)
        {
            if (!string.IsNullOrEmpty(match))
                IsRunwaySnoclo = true;
        }

        private bool IsRunwaySnoclo { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (IsRunwaySnoclo)
                    result.Append("Аэродром закрыт из-за снежных экстремальных осадков ");

                return result.ToString();
            }
        }
    }
}