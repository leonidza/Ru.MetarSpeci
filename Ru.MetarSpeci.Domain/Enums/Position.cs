namespace Ru.MetarSpeci.Enums
{
    public enum Position
    {
        [MetarSpeciDescription("левая")] L,

        [MetarSpeciDescription("центральная")] C,

        [MetarSpeciDescription("правая")] R,

        [MetarSpeciDescription("правее правой")] RR,

        [MetarSpeciDescription("левее левой")] LL
    }
}