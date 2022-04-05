using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TddSocialNetwork.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet = null;
        protected readonly SocialNetworkDbContext Context = null;

        public Repository(SocialNetworkDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {

            return DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChangesAsync();
        }

        public void Update(T obj)
        {
            Save();
        }

        public void Delete(T entity)
        {
            T existing = DbSet.Find(entity);
            DbSet.Remove(existing);
        }

        public void Save()
        {
            Context.SaveChangesAsync();
        }
    }
}