using Microsoft.EntityFrameworkCore;
using repositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace repositoryPattern.Repositories
{
    //B
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected repositoryContext context;
        internal DbSet<T> dbset;

        public GenericRepository(repositoryContext context) {
        this.context = context;
        this.dbset=context.Set<T>();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbset.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<bool> Add(T entity)
        {
            await dbset.AddAsync(entity);
            return true; ;
        }

        public async Task<IEnumerable<T>> All()
        {
            return await dbset.AsNoTracking().ToListAsync();
        }

        public async Task<bool> Upsert(T entity, Expression<Func<T, bool>> predicate)
        {
            var obj = await dbset.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
            if (obj == null)
                return false;

            dbset.Update(entity);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await dbset.FindAsync(id);
            if (obj == null)
                return false;

            dbset.Remove(obj);
            return true;
        }
        public async Task save()
        {
            await context.SaveChangesAsync();
        }
    }
}
