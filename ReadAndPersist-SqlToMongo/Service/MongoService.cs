using Model;
using Repository;

namespace Service
{
    public class MongoService
    {
        public List<Radar> GetMongoRadars() => MongoRepositoryDao.GetInstance().RetrieveAll();

        public bool LoadMongo(List<Radar> radars) => MongoRepositoryDao.GetInstance().LoadMongo(radars);
    }
}