using PetShopCRM.Domain.Models;
using System.Linq.Expressions;

namespace PetShopCRM.Infrastructure.Data.Repository.Interfaces;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<T?> GetByIdAsync(int id);
    IQueryable<T> GetBy(Expression<Func<T, bool>>? filter = null);
    Task<int> GetTotalByAsync(Expression<Func<T, bool>>? filter = null);
    Task<IQueryable<T>> GetPaginateByAsync(Expression<Func<T, bool>>? filter = null, int pageIndex = 0, int pageSize = 10);
    Task<T> AddOrUpdateAsync(T entity);
    Task<List<T>> AddOrUpdateRangeAsync(List<T> entities);
    Task<bool> DeleteOrRestoreAsync(int id);
    Task<bool> DeletePermanentAsync(int id);

}
