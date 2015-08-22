namespace Ru.MetarSpeci.Enums
{
    public enum RunwayBrakingPerformance
    {
        [MetarSpeciDescription("плохая")] Poor,

        [MetarSpeciDescription("от плохой до средней")] FromPoorToAverage,

        [MetarSpeciDescription("средняя")] Average,

        [MetarSpeciDescription("от средней до хорошей")] FromAverageToGood,

        [MetarSpeciDescription("хорошая")] Good,

        [MetarSpeciDescription("нет данных, ненадежное измерение")] UnreliableMeasurement
    }
}