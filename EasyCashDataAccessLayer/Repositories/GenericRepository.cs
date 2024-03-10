using EasyCashDataAccessLayer.Abstract;
using EasyCashDataAccessLayer.Concrete;
using EasyCashEntityLayer.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace EasyCashDataAccessLayer.Repositories
{
    public class GenericRepository<T>(Context context) : IGenericDAL<T> where T : class, IEntityBase, new()
    {
        private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        private IQueryable<T> QueryWithIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await QueryWithIncludes().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await QueryWithIncludes().FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidDataException("Will logging");

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter) => await QueryWithIncludes().Where(filter).ToListAsync();
    }
}
