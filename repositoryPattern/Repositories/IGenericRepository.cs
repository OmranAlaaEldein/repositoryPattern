using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace repositoryPattern.Repositories
{
    //A
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int id);
        Task<bool> Upsert(T entity, Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task save();
    }
}
