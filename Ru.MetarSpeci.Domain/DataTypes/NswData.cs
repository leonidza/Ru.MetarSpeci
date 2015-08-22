using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class NswData
    {
        public NswData(string match)
        {
            if (!string.IsNullOrEmpty(match))
                IsNsw = true;
        }

        private bool IsNsw { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (IsNsw)
                    result.Append("Опасные явления прекратятся ");

                return result.ToString();
            }
        }
    }
}