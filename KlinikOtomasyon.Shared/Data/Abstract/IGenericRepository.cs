using System.Linq.Expressions;
using KlinikOtomasyon.Shared.Entities.Abstract;
using KlinikOtomasyon.Shared.Utilities.Abstract;
using KlinikOtomasyon.Shared.Utilities.Concrete;

namespace KlinikOtomasyon.Shared.Data.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        Task<IResult> AddAsync(T Entity);
        Task<IResult> UpdateAsync(T Entity);
        Task<IResult> DeleteAsync(T Entity);
        Task<DataResult<T>> GetByIdAsync (Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<DataResult<T>> GetListAsync (Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<DataResult<T>> GetListAsync(IQueryable<T> query);
        IQueryable<T> SetQuery();
    }
}