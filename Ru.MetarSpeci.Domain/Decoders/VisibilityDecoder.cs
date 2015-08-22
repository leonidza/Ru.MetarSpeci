using Ru.MetarSpeci.DataTypes;
using Ru.MetarSpeci.Decoders.Abstract;

namespace Ru.MetarSpeci.Decoders
{
    public class VisibilityDecoder : Decoder<VisibilityData>
    {
        private readonly HorizontalVisibilityDecoder _metarHorizontalVisibilityDecoder =
            new HorizontalVisibilityDecoder();

        private readonly HorizontalVisibilityWithDirectionDecoder _metarHorizontalVisibilityWithDirectionDecoder =
            new HorizontalVisibilityWithDirectionDecoder();

        private readonly RunwayVisibilityDecoder _metarRunwayVisibilityDecoder = new RunwayVisibilityDecoder();

        public override string Description => "Visibility";

        public override string RegExPattern => _metarRunwayVisibilityDecoder.RegExPattern +
            _metarHorizontalVisibilityDecoder.RegExPattern +
            _metarHorizontalVisibilityWithDirectionDecoder.RegExPattern;

        public override VisibilityData Decode(string code)
        {
            var horizontalVisibility = _metarHorizontalVisibilityDecoder.Decode(code);
            var horizonatlVisibilityWithDirection = _metarHorizontalVisibilityWithDirectionDecoder.Decode(code);
            var runwayVisiblity = _metarRunwayVisibilityDecoder.Decode(code);

            return new VisibilityData(horizontalVisibility, horizonatlVisibilityWithDirection, runwayVisiblity);
        }
    }
}