using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TodoListBlazorWasm.Services.TodoListServices
{
    public class TaskApiClient : ITaskApiClient
    {
        private HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaskViewModel> GetTodoByIdAsync(int id) 
            => await _httpClient.GetFromJsonAsync<TaskViewModel>($"/api/Todos/{id}");
            

        public async Task<IReadOnlyList<TaskViewModel>> GetTodosAsync() 
            => await _httpClient.GetFromJsonAsync<IReadOnlyList<TaskViewModel>>("/api/Todos");
    }
}
