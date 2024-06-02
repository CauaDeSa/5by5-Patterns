using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Model;

namespace Service
{
    public class JsonService
    {
        public List<Radar>? LoadData(string path)
        {
            StreamReader file = new(path);

            string jsonString = file.ReadToEnd();

            var lst = JsonConvert.DeserializeObject<RadarDao>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            return lst?.GetRadars();
        }
    }
}