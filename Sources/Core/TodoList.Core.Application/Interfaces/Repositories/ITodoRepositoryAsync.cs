using System.Threading.Tasks;
using TodoList.Core.Domain.Entities;

namespace TodoList.Core.Application.Interfaces.Repositories
{
    public interface ITodoRepositoryAsync : IGenericRepositoryAsync<Todo, int>
    {
         Task<int> AddAsync(Todo entity);

          Task DeleteAsync(int entity);

          Task UpdateAsync(Todo entity);
    }
}