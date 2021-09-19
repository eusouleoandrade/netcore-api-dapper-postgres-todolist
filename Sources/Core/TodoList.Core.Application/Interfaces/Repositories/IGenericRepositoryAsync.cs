using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoList.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepositoryAsync<TEntity, TId>
        where TEntity : class
        where TId : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);
        Task<TId> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}