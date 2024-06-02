using Model;

namespace Repository
{
    public interface IRepository
    {
        public List<Radar> RetrieveAll();
    }
}