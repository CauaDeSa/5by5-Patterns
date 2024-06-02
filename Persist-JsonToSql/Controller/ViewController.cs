using Model;
using Service;

namespace Controller
{
    public class ViewController
    {
        private readonly JsonService _jsonService;
        private readonly SqlService _sqlService;

        public ViewController()
        {
            _jsonService = new();
            _sqlService = new();
        }

        public bool LoadJsonData(string path) => RadarDao.GetInstance().Fill(_jsonService.LoadData(path));

        public bool LoadSqlData() => _sqlService.LoadData(RadarDao.GetInstance().GetRadars());

        public List<Radar>? GetRadars() => RadarDao.GetInstance().GetRadars();
    }
}
