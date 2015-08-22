namespace Ru.MetarSpeci.Enums
{
    public enum Direction
    {
        [MetarSpeciDescription("северном")] N,

        [MetarSpeciDescription("восточном")] E,

        [MetarSpeciDescription("южном")] S,

        [MetarSpeciDescription("западном")] W,

        [MetarSpeciDescription("северо-восточном")] NE,

        [MetarSpeciDescription("северо-западном")] NW,

        [MetarSpeciDescription("юго-западном")] SW,

        [MetarSpeciDescription("юго-восточном")] SE
    }
}