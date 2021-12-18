using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CrudDemo.Data.Services
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IQueryable<T>> All();
        Task<T> GetById(Guid id, CancellationToken cancellationToken);
        Task<bool> Add(T entity, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<bool> Upsert(T entity, CancellationToken cancellationToken);
        Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
