using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCar.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetByWhere(Expression<Func<T, bool>> predicate);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}