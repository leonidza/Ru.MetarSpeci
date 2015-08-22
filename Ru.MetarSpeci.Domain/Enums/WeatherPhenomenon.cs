namespace Ru.MetarSpeci.Enums
{
    public enum WeatherPhenomenon
    {
        [MetarSpeciDescription("гроза")] TS,

        [MetarSpeciDescription("ливень")] SH,

        [MetarSpeciDescription("переохлажденный")] FZ,

        [MetarSpeciDescription("буря")] BL,

        [MetarSpeciDescription("низовой поземок")] DR,

        [MetarSpeciDescription("низкий туман")] MIFG,

        [MetarSpeciDescription("гряды тумана")] BCFG,

        [MetarSpeciDescription("морось")] DZ,

        [MetarSpeciDescription("дождь")] RA,

        [MetarSpeciDescription("снег")] SN,

        [MetarSpeciDescription("небольшой град/снежная крупа")] GS,

        [MetarSpeciDescription("ледяной дождь")] PL,

        [MetarSpeciDescription("алмазная пыль")] IC,

        [MetarSpeciDescription("град")] GR,

        [MetarSpeciDescription("снежная крупа")] SG,

        [MetarSpeciDescription("туман")] FG,

        [MetarSpeciDescription("дымка")] BR,

        [MetarSpeciDescription("песок")] SA,

        [MetarSpeciDescription("пыль обложная")] DU,

        [MetarSpeciDescription("мгла")] HZ,

        [MetarSpeciDescription("дым")] FU,

        [MetarSpeciDescription("вулканический пепел")] VA,

        [MetarSpeciDescription("пыльный вихрь")] PO,

        [MetarSpeciDescription("шквал")] SQ,

        [MetarSpeciDescription("торнадо или смерч")] FC,

        [MetarSpeciDescription("пыльная буря")] DS,

        [MetarSpeciDescription("песчаная буря")] SS,

        [MetarSpeciDescription("вблизи")] VC,

        [MetarSpeciDescription("неизвестные осадки")] UP,

        [MetarSpeciDescription("недавнее явление")] RE
    }
}