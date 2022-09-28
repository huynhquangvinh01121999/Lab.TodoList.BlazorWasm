using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BlazorWasm.Domain.Entities;
using TodoList.BlazorWasm.Domain.Interfaces;
using TodoList.BlazorWasm.Persistence.Contexts;

namespace TodoList.BlazorWasm.Persistence.Repositories
{
    public class TodosRepository : ITodosRepository<Todos>
    {
        private readonly AppDbContext _dbContext;

        public TodosRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Todos> CreateTodoAsync(Todos todo)
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

        public async Task<Todos> GetByIdAsync(Guid id)
        {
            var queryString = "select * from Lab.TodoLists where UserId = " + id;
            var result = await _dbContext.TodoLists.FromSqlRaw(queryString).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IReadOnlyList<Todos>> GetTodosAsync()
        {
            var queryString = "select * from Lab.TodoLists";
            var results = await _dbContext.TodoLists.FromSqlRaw(queryString).ToListAsync();
            return results;
        }

        public async Task<IReadOnlyList<Todos>> GetTodosByUserIdAsync(Guid id)
        {
            var queryString = "select * from Lab.TodoLists where Id = " + id;
            var results = await _dbContext.TodoLists.FromSqlRaw(queryString).ToListAsync();
            return results;
        }

        public async Task<Todos> UpdateTodoAsync(Todos todo)
        {
            _dbContext.TodoLists.Update(todo);

            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? todo : null;
        }
    }
}
