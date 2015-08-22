using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class NosigData
    {
        public NosigData(string match)
        {
            if (!string.IsNullOrEmpty(match))
                IsNosig = true;
        }

        private bool IsNosig { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (IsNosig)
                    result.Append("Без существенных изменений ");

                return result.ToString();
            }
        }
    }
}