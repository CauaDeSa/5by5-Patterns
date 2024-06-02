using Model;
using Service;

namespace Controller
{
    public class ViewController
    {
        public List<Radar> GetSqlRadars()
        {
            return new SqlService().GetSqlRadars();
        }

        public List<Radar> GetMongoRadars()
        {
            return new MongoService().GetMongoRadars();
        }

        public bool LoadMongo()
        {
            return new MongoService().LoadMongo(GetSqlRadars());
        }
    }
}
