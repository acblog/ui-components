using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;

namespace AcBlog.Extensions
{
    public abstract class Extension
    {
        private string _assemblyName = string.Empty;
        private string _jsInteropName = string.Empty;

        public ExtensionMetadata Metadata { get; protected set; } = new ExtensionMetadata();

        public AssemblyLoadContext? AssemblyLoadContext { get; set; } = null;

        public IList<Resource> Resources { get; } = new List<Resource>();

        public virtual void ConfigureServices(IServiceCollection services)
        {

        }

        internal protected string AssemblyName
        {
            get
            {
                if (string.IsNullOrEmpty(_assemblyName))
                {
                    _assemblyName = GetType().Assembly.GetName().Name;
                }
                return _assemblyName;
            }
            protected set
            {
                _assemblyName = value;
            }
        }

        internal protected string JSInteropName
        {
            get
            {
                if (string.IsNullOrEmpty(_jsInteropName))
                {
                    _jsInteropName = AssemblyName.Replace('.', '_');
                }
                return _jsInteropName;
            }
            protected set
            {
                _jsInteropName = value;
            }
        }

        public ValueTask<T> JSInvokeAsync<T>(IJSRuntime jsRuntime, string identifier, params object[] args) => jsRuntime.InvokeAsync<T>($"{JSInteropName}.{identifier}", args);

        public ValueTask<T> JSInvokeAsync<T>(IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object[] args) => jsRuntime.InvokeAsync<T>($"{JSInteropName}.{identifier}", cancellationToken, args);

        public ValueTask<T> JSInvokeAsync<T>(IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object[] args) => jsRuntime.InvokeAsync<T>($"{JSInteropName}.{identifier}", timeout, args);

        public ValueTask JSInvokeAsync(IJSRuntime jsRuntime, string identifier, params object[] args) => jsRuntime.InvokeVoidAsync($"{JSInteropName}.{identifier}", args);

        public ValueTask JSInvokeAsync(IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object[] args) => jsRuntime.InvokeVoidAsync($"{JSInteropName}.{identifier}", cancellationToken, args);

        public async ValueTask JSInvokeAsync(IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object[] args) => await jsRuntime.InvokeAsync<object>($"{JSInteropName}.{identifier}", timeout, args);
    }
}
