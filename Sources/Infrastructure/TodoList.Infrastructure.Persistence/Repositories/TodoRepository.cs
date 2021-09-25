using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TodoList.Core.Application.Interfaces.Repositories;
using TodoList.Core.Domain.Entities;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    public class TodoRepositoryAsync : GenericRepositoryAsync<Todo, int>, ITodoRepositoryAsync, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly NpgsqlConnection _connection;

        public TodoRepositoryAsync(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            _connection = new NpgsqlConnection(connectionString);
        }

        public async Task<int> AddAsync(Todo entity)
        {
            string insertSql = @"INSERT INTO todo (title, done)
                                VALUES(@title, @done)
                                RETURNING id;";

            return await _connection.ExecuteScalarAsync<int>(insertSql, new
            {
                title = entity.Title,
                done = entity.Done
            });
        }

        public async Task DeleteAsync(int id)
        {
            var deleteQuery = @"DELETE FROM todo 
                                WHERE id=@id";
            var rows = await _connection.ExecuteAsync(deleteQuery, new
            {
                id = id
            });
        }

        public async Task UpdateAsync(Todo entity)
        {
            var updateQuery = @"UPDATE todo 
                                SET title=@title, done=@done
                                WHERE id=@id";

            var rows = await _connection.ExecuteAsync(updateQuery, new
            {
                id = entity.Id,
                title = entity.Title,
                done = entity.Done
            });
        }

        public override void Dispose()
        {
            _connection.DisposeAsync();
            base.Dispose();
        }
    }
}