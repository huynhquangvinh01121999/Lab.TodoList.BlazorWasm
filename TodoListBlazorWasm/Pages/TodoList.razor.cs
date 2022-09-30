using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListBlazorWasm.Models;
using TodoListBlazorWasm.Services.TodoListServices;

namespace TodoListBlazorWasm.Pages
{
    public partial class TodoList
    {
        [Inject] private ITaskApiClient _taskApiClient { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }

        private IReadOnlyList<TaskViewModel> Todos;

        protected override async Task OnInitializedAsync()
        {
            Todos = await _taskApiClient.GetTodosAsync();
        }

        private void CreateNewTask()
        {
            _navigationManager.NavigateTo("/todolist/addNew");
        }

        public void BackToList()
        {
            _navigationManager.NavigateTo("/todolist");
        }
    }
}
