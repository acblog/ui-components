using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AcBlog.UI.Components.Loading;
using AcBlog.UI.Components.Slides;
using AcBlog.Extensions;

namespace HostBase.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddExtensions()
                .AddExtension<ClientUIComponent>()
                .AddExtension<LoadingUIComponent>()
                // .AddExtension<MarkdownUIComponent>()
                .AddExtension<SlidesUIComponent>();
                // .AddExtension<ModalUIComponent>()
                // .AddExtension<ToastUIComponent>()
                // .AddExtension<BootstrapUIComponent>()
                // .AddExtension<AntDesignUIComponent>();

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.UseExtensions();

            await builder.Build().RunAsync();
        }
    }
}
