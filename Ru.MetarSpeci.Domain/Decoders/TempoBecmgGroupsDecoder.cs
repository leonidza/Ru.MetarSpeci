using System;
using System.Collections.Generic;
using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class TempoBecmgGroupsDecoder : Decoder<TempoBecmgGroupsData>
    {
        public override string Description => "tempo becmg groups";

        public override string RegExPattern => "";

        public override TempoBecmgGroupsData Decode(string code)
        {
            var splittedWords = code.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return new TempoBecmgGroupsData(MakeGroupsFromSplittedWords(splittedWords));
        }

        private List<TempoBecmgGroupData> MakeGroupsFromSplittedWords(IReadOnlyList<string> splittedWords)
        {
            var result = new List<TempoBecmgGroupData>();
            var decoder = new TempoBecmgGroupDecoder();

            for (var i = 0; i < splittedWords.Count; i++)
            {
                if (splittedWords[i].Equals("BECMG", StringComparison.InvariantCultureIgnoreCase) ||
                    splittedWords[i].Equals("TEMPO", StringComparison.InvariantCultureIgnoreCase))
                {
                    var groupCode = splittedWords[i];
                    for (var j = i + 1; j < splittedWords.Count; j++)
                    {
                        groupCode += " ";
                        if (splittedWords[j].Equals("BECMG", StringComparison.InvariantCultureIgnoreCase) ||
                            splittedWords[j].Equals("TEMPO", StringComparison.InvariantCultureIgnoreCase))
                        {
                            break;
                        }
                        groupCode += splittedWords[j];
                    }
                    result.Add(decoder.Decode(groupCode));
                }
            }

            return result;
        }
    }
}