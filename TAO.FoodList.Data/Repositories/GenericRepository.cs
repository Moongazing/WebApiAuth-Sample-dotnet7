using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Repositories;
using TAO.FoodList.Data.DbContexts;

namespace TAO.FoodList.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public IQueryable<TEntity> GetAllAsync()
        {
          return _dbSet.AsQueryable();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entitiy = await _dbSet.FindAsync(id);
            if (entitiy != null)
            {
                _context.Entry(entitiy).State = EntityState.Detached;
            }
            return entitiy;
        }
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);    
        }
    }
}
