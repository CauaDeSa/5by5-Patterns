using Model;
using Repository;

namespace Service
{
    public class SmartReferralProxy : IRepository
    {
        private IRepository? _repository;
        private List<Radar>? _radars;
        private string _type = "";

        public void SetProxy(string type)
        {
            if (!_type.Equals(type))
            {
                _type = type;
                _repository = type switch
                {
                    "SQL" => SqlRepositoryDao.GetInstance(),
                    "MONGO" => MongoRepositoryDao.GetInstance(),
                    _ => null
                };
                _radars = _repository?.RetrieveAll();
            }
        }

        public List<Radar> RetrieveAll() => _radars?? new List<Radar>();

        public void ClearProxy() => _repository = null;
    }
}