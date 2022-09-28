using System;
using System.Threading.Tasks;

namespace TodoList.BlazorWasm.Domain.Interfaces
{
    public interface IUsersRepository<AppUser>
    {
        Task<string> Authenticate(string username, string password);
        Task<Guid> RegisterUserAsync(AppUser user,string password);
    }
}
