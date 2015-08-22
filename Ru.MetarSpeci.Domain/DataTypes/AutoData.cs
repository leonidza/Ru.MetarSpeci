using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class AutoData
    {
        public AutoData(string match)
        {
            if (!string.IsNullOrEmpty(match))
            {
                IsAutoPrefix = true;
            }
        }

        private bool IsAutoPrefix { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (IsAutoPrefix)
                {
                    result.Append("Автоматизированное наблюдение ");
                }

                return result.ToString();
            }
        }
    }
}