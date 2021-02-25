using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using CT.BusinessLogic.Interfaces;

namespace CT.Web.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject] ICanMessageComposer CanMessageComposer { get; set; }
        [Inject] IHandler Handler { get; set; }
        [Inject] ISerialService Notifier { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Notifier.Notify += GetCurrentValue;
        }
        public async Task GetCurrentValue(string inCanCommand)
        {
            Handler.Handle(CanMessageComposer.Compose(inCanCommand));
            await InvokeAsync(StateHasChanged);
        }
        public void Dispose()
        {
            Notifier.Notify -= GetCurrentValue;
        }
    }
}

