using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Core.Domain.Entities;

namespace TodoList.Core.Application.Interfaces.Services
{
    public interface ITodoService
    {
        Task<int> AddAsync(Todo entity);
        
        Task UpdateAsync(Todo entity);
        
        Task<Todo> GetByIdAsync(int id);

        Task<IEnumerable<Todo>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}