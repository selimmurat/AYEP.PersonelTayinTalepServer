using Domain.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Common
{
    public class BaseRepository<T>(DbContext context) : IBaseRepository<T> where T : class
    {
        protected readonly DbContext _context = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        public void Add(T entity) => _dbSet.Add(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync([id], cancellationToken);
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => await _dbSet.AnyAsync(predicate, cancellationToken);
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);
    }
}
