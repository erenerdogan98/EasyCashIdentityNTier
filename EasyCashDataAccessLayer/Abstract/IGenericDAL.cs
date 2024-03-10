using EasyCashEntityLayer.Abstract;
using System.Linq.Expressions;

namespace EasyCashDataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    }
}
