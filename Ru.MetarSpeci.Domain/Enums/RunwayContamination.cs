namespace Ru.MetarSpeci.Enums
{
    public enum RunwayContamination
    {
        [MetarSpeciDescription("менее 10%")] Less10Percents,

        [MetarSpeciDescription("от 11 до 25%")] From11To25Percents,

        [MetarSpeciDescription("от 26 до 50%")] Fromt26To50Percents,

        [MetarSpeciDescription("от 51 до 100%")] From51To100Percents
    }
}