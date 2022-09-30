using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TodoListBlazorWasm.Models;
using TodoListBlazorWasm.Services.TodoListServices;

namespace TodoListBlazorWasm.Pages
{
    public partial class TodoListDetail
    {
        [Inject] private ITaskApiClient _taskApiClient { get; set; }

        [Parameter]
        public string TodoListId { get; set; }

        private TaskViewModel TaskVM;

        protected override async Task OnInitializedAsync()
        {
            TaskVM = await _taskApiClient.GetTodoByIdAsync(int.Parse(TodoListId));
        }
    }
}
