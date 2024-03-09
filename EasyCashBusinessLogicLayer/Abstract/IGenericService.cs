using System.Linq.Expressions;

namespace EasyCashBusinessLogicLayer.Services
{
    public interface IGenericService<T> where T : class
    {
        // methods name start with T , because same design using for DAL , and i want to do this for differences.
        Task TAddAsync(T entity);
        Task TDeleteAsync(T entity);
        Task TUpdateAsync(T entity);
        Task<IEnumerable<T>> TGetAllAsync();
        Task<T> TGetByIdAsync(int id);
        Task<IEnumerable<T>> TGetAllAsync(Expression<Func<T, bool>> filter);
    }
}
