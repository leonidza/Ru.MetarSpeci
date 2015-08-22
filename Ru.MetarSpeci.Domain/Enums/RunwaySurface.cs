namespace Ru.MetarSpeci.Enums
{
    public enum RunwaySurface
    {
        [MetarSpeciDescription("чисто и сухо")] CleanAndDry,

        [MetarSpeciDescription("влажно")] Damp,

        [MetarSpeciDescription("мокро")] Wet,

        [MetarSpeciDescription("иней или изморозь")] FrostOrRime,

        [MetarSpeciDescription("сухой снег")] DrySnow,

        [MetarSpeciDescription("мокрый снег")] WetSnow,

        [MetarSpeciDescription("слякоть")] Slob,

        [MetarSpeciDescription("лёд")] Ice,

        [MetarSpeciDescription("уплотненный или укатанный снег")] CompactedOrRolledSnow,

        [MetarSpeciDescription("мерзлая неровная поверхность (борозды, складки)")] FrozenRutsOrRidges
    }
}