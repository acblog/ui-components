using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AcBlog.Extensions
{
    static class JsInterop
    {
        public static ValueTask CacheDataFromPath(IJSRuntime jsRuntime, string path, bool forceUpdate = false) => jsRuntime.InvokeVoidAsync("AcBlog_Extensions_Core.cacheDataFromPath", path, forceUpdate);

        public static ValueTask LoadScript(IJSRuntime jsRuntime, string src) => jsRuntime.InvokeVoidAsync("AcBlog_Extensions_Core.loadScript", src);

        public static ValueTask LoadStyleSheet(IJSRuntime jsRuntime, string href) => jsRuntime.InvokeVoidAsync("AcBlog_Extensions_Core.loadStyleSheet", href);
    }
}
