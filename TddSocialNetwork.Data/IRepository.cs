using System;
using System.Linq;
using System.Linq.Expressions;

namespace TddSocialNetwork.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T obj);
        void Delete(T entity);
        void Save();
    }
}