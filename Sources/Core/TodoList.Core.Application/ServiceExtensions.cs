using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Application.Interfaces.Services;
using TodoList.Core.Application.Services;

namespace TodoList.Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITodoService, TodoService>();
        }
    }
}