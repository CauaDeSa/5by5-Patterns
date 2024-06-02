using Model;
using Repository;

namespace Service
{
    public class SqlService
    {
        public List<Radar> GetSqlRadars() => SqlRepositoryDao.GetInstance().RetrieveAll();
    }
}