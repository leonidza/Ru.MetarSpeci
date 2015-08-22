using System.Collections.Generic;
using System.Text;

namespace Ru.MetarSpeci.DataTypes
{
    public class TempoBecmgGroupsData
    {
        private readonly List<TempoBecmgGroupData> _groupDatas;

        public TempoBecmgGroupsData(List<TempoBecmgGroupData> groupDatas)
        {
            _groupDatas = groupDatas;
        }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                foreach (var group in _groupDatas)
                    result.Append(group.Description);

                return result.ToString();
            }
        }
    }
}