using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AcBlog.UI.Components
{
    public abstract class UIComponent
    {
        private string _assemblyName = string.Empty;
        private string _jsInteropName = string.Empty;

        public IList<UIComponentResource> Resources { get; } = new List<UIComponentResource>();

        public IServiceCollection Services { get; } = new ServiceCollection();

        protected string AssemblyName
        {
            get
            {
                if (string.IsNullOrEmpty(_assemblyName))
                {
                    _assemblyName = GetType().Assembly.GetName().Name;
                }
                return _assemblyName;
            }
        }

        protected string JSInteropName
        {
            get
            {
                if (string.IsNullOrEmpty(_jsInteropName))
                {
                    _jsInteropName = AssemblyName.Replace('.', '_');
                }
                return _jsInteropName;
            }
        }

        public ValueTask<T> JSInvokeAsync<T>(IJSRuntime jsRuntime, string identifier, params object[] args) => jsRuntime.InvokeAsync<T>($"{JSInteropName}.{identifier}", args);

        public ValueTask<T> JSInvokeAsync<T>(IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object[] args) => jsRuntime.InvokeAsync<T>($"{JSInteropName}.{identifier}", cancellationToken, args);

        public ValueTask<T> JSInvokeAsync<T>(IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object[] args) => jsRuntime.InvokeAsync<T>($"{JSInteropName}.{identifier}", timeout, args);

        public ValueTask JSInvokeAsync(IJSRuntime jsRuntime, string identifier, params object[] args) => jsRuntime.InvokeVoidAsync($"{JSInteropName}.{identifier}", args);

        public ValueTask JSInvokeAsync(IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object[] args) => jsRuntime.InvokeVoidAsync($"{JSInteropName}.{identifier}", cancellationToken, args);

        public async ValueTask JSInvokeAsync(IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object[] args) => await jsRuntime.InvokeAsync<object>($"{JSInteropName}.{identifier}", timeout, args);

        public UIComponent AddScriptResource(string path, bool autoLoad = true)
        {
            Resources.Add(new UIComponentResource
            {
                Type = UIComponentResourceType.Script,
                Path = path,
                AutoLoad = autoLoad,
            });
            return this;
        }

        public UIComponent AddStyleSheetResource(string path, bool autoLoad = true)
        {
            Resources.Add(new UIComponentResource
            {
                Type = UIComponentResourceType.StyleSheet,
                Path = path,
                AutoLoad = autoLoad,
            });
            return this;
        }

        public UIComponent AddLocalScriptResource(string path, bool autoLoad = true) => AddScriptResource($"_content/{AssemblyName}/{path}", autoLoad);

        public UIComponent AddLocalStyleSheetResource(string path, bool autoLoad = true) => AddStyleSheetResource($"_content/{AssemblyName}/{path}", autoLoad);
    }
}
