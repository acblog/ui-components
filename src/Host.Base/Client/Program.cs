using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AcBlog.UI.Components;
using AcBlog.UI.Components.Loading;
using AcBlog.UI.Components.Markdown;
using AcBlog.UI.Components.Slides;

namespace Host.Base.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.AddUIComponents()
                .AddUIComponent<LoadingUIComponent>()
                .AddUIComponent<MarkdownUIComponent>()
                .AddUIComponent<SlidesUIComponent>();

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.UseUIComponents();

            await builder.Build().RunAsync();
        }
    }
}
