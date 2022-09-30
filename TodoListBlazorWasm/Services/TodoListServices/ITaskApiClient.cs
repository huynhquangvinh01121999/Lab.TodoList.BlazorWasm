using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoListBlazorWasm.Services.TodoListServices
{
    public interface ITaskApiClient
    {
        Task<IReadOnlyList<TaskViewModel>> GetTodosAsync();
        Task<TaskViewModel> GetTodoByIdAsync(int id);
    }
}
