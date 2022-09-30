using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListBlazorWasm.Services.TypesServices;

namespace TodoListBlazorWasm.Components
{
    public partial class Modal
    {
        [Inject] private ITypeApiClient _typeApiClient { get; set; }

        private IReadOnlyList<TypeViewModel> Types;
        protected override async Task OnInitializedAsync()
        {
            Types = await _typeApiClient.GetTypesAsync();
        }

    }
}
