using AcBlog.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Net.Http;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace AcBlog.Extensions
{
    public static class ExtensionExtensions
    {
        public static ExtensionCollection AddExtensions(this IServiceCollection services)
        {
            ExtensionCollection extensions = new ExtensionCollection(services);
            services.AddSingleton(extensions);
            return extensions;
        }

        public static async Task<Extension?> CreateExtension(this ExtensionMetadata metadata, ResouceLoadContext resouceLoadContext)
        {
            switch (metadata.Type)
            {
                case ExtensionType.Javascript:
                {
                    return new JSExtension(metadata);
                }
                case ExtensionType.CSharp:
                {
                    Type? extensionType = null;
                    foreach (var r in metadata.LoadingResources)
                    {
                        await r.Load(resouceLoadContext);
                        if (r.Type == ResourceType.DynamicLinkLibrary)
                        {
                            var ass = r.GetLoadedAssembly();
                            var type = ass.GetType(metadata.ClassName, false, false);
                            if (type != null)
                            {
                                if (extensionType != null)
                                {
                                    throw new Exception("multiple extension class");
                                }
                                extensionType = type;
                            }
                        }
                    }
                    if (extensionType == null)
                    {
                        throw new Exception("no extension class");
                    }
                    else if (!extensionType.IsSubclassOf(typeof(Extension)))
                    {
                        throw new Exception("extension class not is subclass of Extension");
                    }
                    var extension = (Extension)Activator.CreateInstance(extensionType);
                    return extension;
                }
            }
            return null;
        }

        public static async Task UseExtensions(this WebAssemblyHostBuilder builder)
        {
            using var services = builder.Services.BuildServiceProvider();
            var collection = services.GetRequiredService<ExtensionCollection>();
            var httpClient = services.GetRequiredService<HttpClient>();
            var jsRuntime = services.GetRequiredService<IJSRuntime>();
            var logger = services.GetRequiredService<ILogger<Extension>>();
            foreach (var c in collection.Extensions)
            {
                logger.LogInformation($"Loading {c.Metadata.Name}");
                AssemblyLoadContext? assemblyLoadContext = null;
                try
                {
                    // https://github.com/dotnet/aspnetcore/issues/7917 may throw NotImplementedException
                    assemblyLoadContext = AssemblyLoadContext.Default;
                }
                catch { }
                ResouceLoadContext resouceLoadContext = new ResouceLoadContext(jsRuntime,
                    assemblyLoadContext,
                    httpClient);
                c.AssemblyLoadContext = resouceLoadContext.AssemblyLoadContext;
                foreach (var r in c.Resources)
                {
                    if (r.AutoLoad)
                    {
                        logger.LogInformation($"Loading resources {r.Path} from {c.Metadata.Name}");
                        await r.Load(resouceLoadContext);
                    }
                }
                logger.LogInformation($"Loaded {c.Metadata.Name}");
            }
        }
    }
}
