using System.Linq.Expressions;

namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        T Find(int id);
        IEnumerable<T> GetAll();
    }
}
