using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace Ru.MetarSpeci.DataTypes
{
    public class AirportData
    {
        private readonly InnerAirportData _innerAirport = new InnerAirportData();

        public AirportData(string match)
        {
            var aiportMatch = match.Trim();
            var assembly = Assembly.GetExecutingAssembly();
            var airportsStream = assembly.GetManifestResourceStream("Ru.MetarSpeci.airports.xml");
            var airports = XDocument.Load(new XmlTextReader(airportsStream));
            var aiport = airports.Root.Elements("AiportData").FirstOrDefault(
                data => (string)data.Element("Code") == aiportMatch);
            _innerAirport.Code = aiportMatch;
            if (aiport != null)
                _innerAirport.Name = (string)aiport.Element("Name");

            else
                _innerAirport.Name = "";
        }

        public string Description => _innerAirport.Name + " ";

        private class InnerAirportData
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
    }
}