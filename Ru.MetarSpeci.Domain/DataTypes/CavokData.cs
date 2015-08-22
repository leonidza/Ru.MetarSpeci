using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class CavokData
    {
        public CavokData(string match)
        {
            if (!string.IsNullOrEmpty(match))
                IsCavok = true;
        }

        private bool IsCavok { get; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsCavok)
                    return result.ToString();

                result.Append(
                    "Видимость более 10км и более, отсутствие кучево - дождевых облаков ниже 1500м или ниже вернего предела мин высоты ");
                result.Append(
                    "в секторе в зависимости от того, какая величина больше, отсутствие особых явлений погоды");

                return result.ToString();
            }
        }
    }
}