using Microsoft.JSInterop;
using System.Net.Http;
using System.Runtime.Loader;

namespace AcBlog.Extensions
{
    public class ResouceLoadContext
    {
        public ResouceLoadContext(IJSRuntime? jSRuntime, AssemblyLoadContext? assemblyLoadContext, HttpClient? httpClient)
        {
            JSRuntime = jSRuntime;
            AssemblyLoadContext = assemblyLoadContext;
            HttpClient = httpClient;
        }

        public IJSRuntime? JSRuntime { get; }

        public AssemblyLoadContext? AssemblyLoadContext { get; }

        public HttpClient? HttpClient { get; }
    }
}
