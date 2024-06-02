using Model;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Repository
{
    public class MongoRepositoryDao
    {
        #region Mongo Variables
        private readonly string _connection = "mongodb://root:Mongo%402024%23@localhost:27017/";
        private readonly MongoClient _client;
        private static MongoRepositoryDao? _instance;
        #endregion

        private MongoRepositoryDao()
        {
            _instance = this;
            _client = new(_connection);
        }

        public static MongoRepositoryDao GetInstance() => _instance ?? new MongoRepositoryDao();

        public List<Radar> GetMongoRadars()
        {
            var db = _client.GetDatabase("BDRadar");
            var collection = db.GetCollection<Radar>("Radar");

            return collection.Find(FilterDefinition<Radar>.Empty).ToList();
        }

        public bool LoadMongo(List<Radar> radars)
        {
            try
            {
                var db = _client.GetDatabase("BDRadar");
                var collection = db.GetCollection<Radar>("Radar");

                collection.InsertMany(radars);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}