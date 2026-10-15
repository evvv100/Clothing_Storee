using Model;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject
    {
        void Add(T item);
        void Delete(int id);
        List<T> ReadAll();
        T ReadById(int id);
        void Update(T item);
    }
}
