using AutoMapper;
using TodoList.BlazorWasm.Application.Features.Todos.Commands.CreateTodos;
using TodoList.BlazorWasm.Application.Features.Todos.Queries.GetTodosByUserId;
using TodoList.BlazorWasm.Domain.Entities;

namespace TodoList.BlazorWasm.Application.AutoMapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateTodosCommand, TodosList>();
            CreateMap<TodosList, CreateTodosViewModel>();
            CreateMap<TodosList, GetTodosByUserIdQueryViewModel>();
            CreateMap<TodosList, GetTodosQueryViewModel>();
        }
    }
}
