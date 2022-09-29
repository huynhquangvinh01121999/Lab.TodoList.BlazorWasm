using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BlazorWasm.Domain.Entities;
using TodoList.BlazorWasm.Domain.Interfaces.Base;

namespace TodoList.BlazorWasm.Domain.Interfaces
{
    public interface ITodosRepository : IRepository<Entities.TodosList>
    {
        Task<IReadOnlyList<Entities.TodosList>> GetTodosAsync();

        Task<IReadOnlyList<Entities.TodosList>> GetTodosByUserIdAsync(Guid id);

        Task<Entities.TodosList> GetByIdAsync(Guid id);

        Task<Entities.TodosList> CreateTodoAsync(Entities.TodosList todo);

        Task<Entities.TodosList> UpdateTodoAsync(Entities.TodosList todo);

        Task<bool> DeleteTodoAsync(int id);
    }
}
