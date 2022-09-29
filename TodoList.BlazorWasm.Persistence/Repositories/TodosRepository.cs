using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BlazorWasm.Domain.Entities;
using TodoList.BlazorWasm.Domain.Interfaces;
using TodoList.BlazorWasm.Persistence.Contexts;
using TodoList.BlazorWasm.Persistence.Repositories.Base;

namespace TodoList.BlazorWasm.Persistence.Repositories
{
    public class TodosRepository : Repository<TodosList>, ITodosRepository
    {
        private readonly AppDbContext _dbContext;

        public TodosRepository(AppDbContext dbContext) : base (dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TodosList> CreateTodoAsync(TodosList todo)
        {
            await _dbContext.TodoLists.AddAsync(todo);

            var result = await _dbContext.SaveChangesAsync();

            return result > 0 ? todo : null;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todo = await _dbContext.TodoLists.FindAsync(id);

            if (todo == null)
                return false;

            _dbContext.TodoLists.Remove(todo);

            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<TodosList> GetByIdAsync(Guid id)
        {
            var queryString = string.Format("select * from Lab.TodoLists where id = '{0}'", id);
            var result = await _dbContext.TodoLists.FromSqlRaw(queryString).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IReadOnlyList<TodosList>> GetTodosAsync()
        {
            var queryString = "select * from Lab.TodoLists";
            var results = await _dbContext.TodoLists.FromSqlRaw(queryString).ToListAsync();
            return results;
        }

        public async Task<IReadOnlyList<TodosList>> GetTodosByUserIdAsync(Guid id)
        {
            var queryString = string.Format("select * from Lab.TodoLists where UserId = '{0}'", id);
            var results = await _dbContext.TodoLists.FromSqlRaw(queryString).ToListAsync();
            return results;
        }

        public async Task<TodosList> UpdateTodoAsync(TodosList todo)
        {
            _dbContext.TodoLists.Update(todo);

            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? todo : null;
        }
    }
}
