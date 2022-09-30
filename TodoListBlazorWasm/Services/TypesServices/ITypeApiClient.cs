using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoListBlazorWasm.Services.TypesServices
{
    public interface ITypeApiClient
    {
        Task<IReadOnlyList<TypeViewModel>> GetTypesAsync();
    }
}
