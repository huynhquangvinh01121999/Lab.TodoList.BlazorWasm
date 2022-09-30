using Microsoft.AspNetCore.Components;

namespace TodoListBlazorWasm.Pages
{
    public partial class TodoListDetail
    {
        [Parameter]
        public string TodoListId { get; set; }


    }
}
