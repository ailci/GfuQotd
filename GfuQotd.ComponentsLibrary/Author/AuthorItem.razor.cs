using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace GfuQotd.ComponentsLibrary.Author;
public partial class AuthorItem
{
    [Inject] public ILogger<AuthorItem> Logger { get; set; } = default!;
    [Parameter] public AuthorViewModel? AuthorVm { get; set; }
}
