using Model;
using System.Xml.Serialization;

namespace Service
{
    public class XmlRadarAdapter : IRadar
    {
        public static string ToString(List<Radar> lst)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var xmlSerializer = new XmlSerializer(typeof(Radar));
            var textWriter = new StringWriter();

            foreach (var radar in lst)
                xmlSerializer.Serialize(textWriter, radar, namespaces);

            return textWriter.ToString();
        }
    }
}