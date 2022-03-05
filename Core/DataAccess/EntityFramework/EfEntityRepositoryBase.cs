using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext,new()
    {
        private readonly TContext _context = new TContext();

        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task AddAsync(TEntity entity)
        {
                await Table.AddAsync(entity);
                await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
                return await Table.SingleOrDefaultAsync(filter);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
                return filter == null ?
                    Table :
                    Table.Where(filter);
        }

        public async Task UpdateAsync(TEntity entity)
        {
                Table.Update(entity);
                await _context.SaveChangesAsync();
        }
    }
}
