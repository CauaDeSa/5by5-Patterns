using Model;
using Newtonsoft.Json;

namespace Service
{
    public class JsonRadarAdapter
    {
        public static string ToString(List<Radar> lst) => JsonConvert.SerializeObject(lst);
    }
}