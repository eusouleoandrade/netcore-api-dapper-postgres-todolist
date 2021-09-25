using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Application.Interfaces.Repositories;
using TodoList.Infrastructure.Persistence.Repositories;

namespace TodoList.Infrastructure.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepositoryAsync<,>), typeof(GenericRepositoryAsync<,>));
            services.AddScoped<ITodoRepositoryAsync, TodoRepositoryAsync>();
        }
    }
}