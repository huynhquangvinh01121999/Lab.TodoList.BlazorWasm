using System;

namespace TodoList.BlazorWasm.Application.Features.Todos.Commands.CreateTodos
{
    public class CreateTodosViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Mode { get; set; }    // public/private
    }
}
