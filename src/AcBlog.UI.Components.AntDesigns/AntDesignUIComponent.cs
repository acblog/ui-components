using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.AntDesigns
{
    public class AntDesignUIComponent : UIComponent
    {
        public AntDesignUIComponent()
        {
            AddStyleSheetResource("_content/AntDesign/css/ant-design-blazor.css");
            AddScriptResource("_content/AntDesign/js/ant-design-blazor.js");
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddAntDesign();
            base.ConfigureServices(services);
        }
    }
}
