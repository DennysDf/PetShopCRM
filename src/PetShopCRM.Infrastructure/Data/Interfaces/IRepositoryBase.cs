using PetShopCRM.Domain.Models;
using System.Linq.Expressions;

namespace PetShopCRM.Infrastructure.Data.Interfaces;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<T?> GetByIdAsync(int id);
    Task<IQueryable<T>> GetByAsync(Expression<Func<T, bool>>? filter = null);
    Task<int> GetTotalByAsync(Expression<Func<T, bool>>? filter = null);
    Task<IQueryable<T>> GetPaginateByAsync(Expression<Func<T, bool>>? filter = null, int pageIndex = 0, int pageSize = 10);
    Task AddOrUpdateAsync(T entity);
    Task AddOrUpdateRangeAsync(List<T> entities);
    Task<bool> DeleteAsync(int id);
}
