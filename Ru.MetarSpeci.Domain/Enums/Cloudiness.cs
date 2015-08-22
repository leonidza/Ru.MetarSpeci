namespace Ru.MetarSpeci.Enums
{
    public enum MetarSpeciCloudiness
    {
        [MetarSpeciDescription("Облачность незначительная, 1 - 2 октанта")] FEW,

        [MetarSpeciDescription("Облачность рассеянная, 3 - 4 октанта")] SCT,

        [MetarSpeciDescription("Облачность разорванная, 5 - 7 октантов")] BKN,

        [MetarSpeciDescription("Облачность сплошная, 8 октанта")] OVC,

        [MetarSpeciDescription("Вертикальная видимость")] VV,

        [MetarSpeciDescription("Ожидается полное прояснение неба")] SKC,

        [MetarSpeciDescription("Ожидается исчезновение опасной облачности")] NSC
    }
}