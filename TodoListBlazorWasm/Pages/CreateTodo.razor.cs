using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListBlazorWasm.Pages
{
    public partial class CreateTodo
    {
        [Inject] private NavigationManager _navigationManager { get; set; }

        private void BackToList()
        {
            _navigationManager.NavigateTo("/todolist");
        }
    }
}
