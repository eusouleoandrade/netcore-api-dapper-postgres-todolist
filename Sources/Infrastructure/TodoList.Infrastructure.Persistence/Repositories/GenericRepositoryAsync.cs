using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TodoList.Core.Application.Interfaces.Repositories;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    public class GenericRepositoryAsync<TEntity, TId> : IDisposable, IGenericRepositoryAsync<TEntity, TId>
        where TEntity : class
        where TId : struct
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public GenericRepositoryAsync(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("Default");
            _connection = new SqlConnection(connectionString);
        }

        public async Task<TId> AddAsync(TEntity entity)
        {
            var idEntity = await _connection.ExecuteScalarAsync("");
            return (TId)Convert.ChangeType(idEntity, typeof(TId));
        }

        public async Task DeleteAsync(TEntity entity) => await _connection.DeleteAsync<TEntity>(entity);


        public void Dispose() => _connection.DisposeAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _connection.GetAllAsync<TEntity>();

        public async Task<TEntity> GetByIdAsync(TId id) => await _connection.GetAsync<TEntity>(id);

        public async Task UpdateAsync(TEntity entity) => await _connection.UpdateAsync<TEntity>(entity);
    }
}