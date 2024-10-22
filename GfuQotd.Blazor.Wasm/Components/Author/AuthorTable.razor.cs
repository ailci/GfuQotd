using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace GfuQotd.Blazor.Wasm.Components.Author;
public partial class AuthorTable
{
    [Parameter, EditorRequired] 
    public IEnumerable<AuthorViewModel>? AuthorViewModels { get; set; }
}
