using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.BlazorWasm.Application.Features.Todos.Commands.CreateTodos;
using TodoList.BlazorWasm.Application.Features.Todos.Queries.GetTodosByUserId;

namespace TodoList.BlazorWasm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTodos")]
        public async Task<IActionResult> GetTodos()
        {
            return Ok(await _mediator.Send(new GetTodosQuery()));
        }

        [HttpGet("GetTodosByUserId")]
        public async Task<IActionResult> GetTodosByUserId(Guid userId)
        {
            return Ok(await _mediator.Send(new GetTodosByUserIdQuery { UserId = userId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodos(CreateTodosCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
