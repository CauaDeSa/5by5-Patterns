using Newtonsoft.Json;

namespace Model
{
    public class RadarDao
    {
        private static RadarDao? _instance;

        [JsonProperty("radar")]
        private readonly List<Radar> _radars;

        private RadarDao()
        {
            _radars = new List<Radar>();
            _instance = this;
        }

        public static RadarDao GetInstance() => _instance ?? new RadarDao();

        public List<Radar>? GetRadars() => _radars;

        public bool Fill(List<Radar>? radars)
        {
            if (_radars.Count != 0)
                return false;
            
            _radars.AddRange(radars ?? new List<Radar>());
            return true;
        }
    }
}