using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Modal
{
    public class ModalUIComponent : UIComponent
    {
        public ModalUIComponent()
        {
            AddStyleSheetResource("_content/Blazored.Modal/blazored-modal.css");
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredModal();
            base.ConfigureServices(services);
        }
    }
}
