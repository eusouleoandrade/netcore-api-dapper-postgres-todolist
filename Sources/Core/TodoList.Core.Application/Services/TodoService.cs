using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Core.Application.Interfaces.Repositories;
using TodoList.Core.Application.Interfaces.Services;
using TodoList.Core.Domain.Entities;

namespace TodoList.Core.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepositoryAsync _repository;

        public TodoService(ITodoRepositoryAsync repository) => _repository = repository;

        public async Task<int> AddAsync(Todo entity) => await _repository.AddAsync(entity);

        public async Task<IEnumerable<Todo>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Todo> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task UpdateAsync(Todo entity) => await _repository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}