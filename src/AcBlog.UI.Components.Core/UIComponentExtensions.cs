using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AcBlog.UI.Components
{
    public static class UIComponentExtensions
    {
        public static UIComponentCollection AddUIComponents(this WebAssemblyHostBuilder builder)
        {
            UIComponentCollection uIComponentCollection = new UIComponentCollection();
            builder.Services.AddSingleton(uIComponentCollection);
            return uIComponentCollection;
        }

        public static async Task UseUIComponents(this WebAssemblyHostBuilder builder)
        {
            using var services = builder.Services.BuildServiceProvider();
            var collection = services.GetRequiredService<UIComponentCollection>();
            var jsRuntime = services.GetRequiredService<IJSRuntime>();
            foreach (var c in collection.Components)
            {
                foreach (var r in c.Resources)
                {
                    if (r.AutoLoad)
                        await r.Load(jsRuntime);
                }
            }
        }
    }
}
