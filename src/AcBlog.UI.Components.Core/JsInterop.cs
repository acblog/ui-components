using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AcBlog.UI.Components
{
    static class JsInterop
    {
        public static ValueTask LoadScript(IJSRuntime jsRuntime, string src) => jsRuntime.InvokeVoidAsync("AcBlogUIComponentsCore.loadScript", src);

        public static ValueTask LoadStyleSheet(IJSRuntime jsRuntime, string href) => jsRuntime.InvokeVoidAsync("AcBlogUIComponentsCore.loadStyleSheet", href);
    }
}
