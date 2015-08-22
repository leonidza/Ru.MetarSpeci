using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class RmkData
    {
        public RmkData(string match)
        {
            if (!string.IsNullOrEmpty(match))
                IsRmk = true;
        }

        private bool IsRmk { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (IsRmk)
                    result.Append("Дополнительная информация: ");

                return result.ToString();
            }
        }
    }
}