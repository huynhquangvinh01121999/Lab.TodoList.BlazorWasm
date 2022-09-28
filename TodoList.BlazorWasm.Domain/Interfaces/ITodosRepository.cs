using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoList.BlazorWasm.Domain.Interfaces
{
    public interface ITodosRepository<Todo>
    {
        Task<IReadOnlyList<Todo>> GetTodosAsync();

        Task<IReadOnlyList<Todo>> GetTodosByUserIdAsync(Guid id);

        Task<Todo> GetByIdAsync(Guid id);

        Task<Todo> CreateTodoAsync(Todo todo);

        Task<Todo> UpdateTodoAsync(Todo todo);

        Task<bool> DeleteTodoAsync(int id);
    }
}
