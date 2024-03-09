using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Interfaces;
using System.Linq.Expressions;

namespace PetShopCRM.Infrastructure.Data;

public class RepositoryBase<T>(PetShopDbContext _context) : IRepositoryBase<T> where T : EntityBase
{
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context
            .Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IQueryable<T>> GetByAsync(Expression<Func<T, bool>>? filter = null)
    {
        var query = _context.Set<T>().AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        return await Task.FromResult(query);
    }

    public async Task AddOrUpdateAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        try
        {
            entity.UpdatedDate = DateTime.Now;

            if (entity.Id == 0)
            {
                entity.CreatedDate = DateTime.Now;
                await _context.Set<T>().AddAsync(entity);
            }
            else
                _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task AddOrUpdateRangeAsync(List<T> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));

        try
        {
            if (entities.Exists(x => x.Id == 0))
                await _context.Set<T>().AddRangeAsync(entities.Where(x => x.Id == 0));
            else
                _context.Set<T>().UpdateRange(entities.Where(x => x.Id != 0));

            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (id == 0) throw new ArgumentNullException(nameof(id));

        try
        {
            var entity = _context.Find<T>(id);

            if (entity == null) throw new NullReferenceException(nameof(entity));

            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return true;
    }
}
