using Microsoft.JSInterop;
using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AcBlog.Extensions
{

    public class Resource
    {
        public Resource(ResourceType type, string path, bool autoLoad = true, bool cached = true)
        {
            Type = type;
            Path = path;
            AutoLoad = autoLoad;
            AutoCache = cached;
        }

        public ResourceType Type { get; set; }

        public string Path { get; set; } = string.Empty;

        public bool AutoLoad { get; set; } = true;

        public bool AutoCache { get; set; } = true;

        public async Task Load(ResouceLoadContext loadContext)
        {
            if (AutoCache)
            {
                if (loadContext.JSRuntime != null)
                    await JsInterop.CacheDataFromPath(loadContext.JSRuntime, Path);
            }

            switch (Type)
            {
                case ResourceType.Script:
                    if (loadContext.JSRuntime != null)
                        await JsInterop.LoadScript(loadContext.JSRuntime, Path);
                    break;
                case ResourceType.StyleSheet:
                    if (loadContext.JSRuntime != null)
                        await JsInterop.LoadStyleSheet(loadContext.JSRuntime, Path);
                    break;
                case ResourceType.DynamicLinkLibrary:
                {
                    if (loadContext.HttpClient != null)
                    {
                        var response = await loadContext.HttpClient.GetAsync(Path);
                        response.EnsureSuccessStatusCode();
                        if (loadContext.AssemblyLoadContext != null)
                        {
                            using var stream = await response.Content.ReadAsStreamAsync();
                            LoadedAssembly = loadContext.AssemblyLoadContext.LoadFromStream(stream);
                        }
                        else
                        {
                            var bytes = await response.Content.ReadAsByteArrayAsync();
                            LoadedAssembly = Assembly.Load(bytes);
                        }
                    }
                }
                break;
            }
        }

        public Assembly GetLoadedAssembly()
        {
            if (LoadedAssembly == null)
                throw new System.Exception("No assembly loaded");
            return LoadedAssembly;
        }

        private Assembly? LoadedAssembly { get; set; } = null;
    }
}
