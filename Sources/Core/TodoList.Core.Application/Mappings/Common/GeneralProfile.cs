using AutoMapper;
using TodoList.Core.Application.DTOs.Todo;
using TodoList.Core.Domain.Entities;

namespace TodoList.Core.Application.Mappings.Common
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<TodoRequest, Todo>();
        }
    }
}