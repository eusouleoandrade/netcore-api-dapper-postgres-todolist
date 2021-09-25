using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TodoList.Core.Application.Interfaces.Repositories;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    public class GenericRepositoryAsync<TEntity, TId> : IDisposable, IGenericRepositoryAsync<TEntity, TId>
        where TEntity : class
        where TId : struct
    {
        private readonly IConfiguration _configuration;
        private readonly NpgsqlConnection _connection;

        public GenericRepositoryAsync(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            _connection = new NpgsqlConnection(connectionString);
        }

        public virtual void Dispose() => _connection.DisposeAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _connection.GetAllAsync<TEntity>();

        public async Task<TEntity> GetByIdAsync(TId id) => await _connection.GetAsync<TEntity>(id);
    }
}