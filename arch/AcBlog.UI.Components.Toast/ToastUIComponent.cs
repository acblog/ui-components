using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Toast
{
    public class ToastUIComponent : UIComponent
    {
        public ToastUIComponent()
        {
            AddStyleSheetResource("_content/Blazored.Toast/blazored-toast.min.css");
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredToast();
            base.ConfigureServices(services);
        }
    }
}
