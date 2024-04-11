using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly JustBlogContext _context;
        protected DbSet<T> dbSet;

        public Repository(JustBlogContext db)
        {
            _context = db;
            dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
            else
            {
                throw new ArgumentException($"{id} not exist in the {typeof(T).Name} table");
            }
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            var navigations = _context.Model.FindEntityType(typeof(T))
                .GetDerivedTypesInclusive()
                .SelectMany(type => type.GetNavigations())
                .Distinct();
            foreach (var property in navigations)
            {
                query = query.Include(property.Name);
            }
            return query.ToList();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
