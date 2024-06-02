using Model;
using RepositoryDao;

namespace Service
{
    public class SqlService
    {
        public bool LoadData(List<Radar> lst) => SqlRepositoryDao.GetInstance().LoadData(lst);
    }
}
