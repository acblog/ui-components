using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Bootstrap
{
    public class BootstrapUIComponent : UIComponent
    {
        public BootstrapUIComponent()
        {
            AddStyleSheetResource("_content/BootstrapBlazor/lib/bootstrap/css/bootstrap.min.css");
            AddStyleSheetResource("_content/BootstrapBlazor/lib/font-awesome/css/font-awesome.min.css");
            AddStyleSheetResource("_content/BootstrapBlazor/lib/overlayscrollbars/OverlayScrollbars.min.css");
            AddStyleSheetResource("_content/BootstrapBlazor/css/bootstrap.blazor.css");
            AddScriptResource("_content/BootstrapBlazor/lib/jquery/jquery.min.js");
            AddScriptResource("_content/BootstrapBlazor/lib/bootstrap/js/bootstrap.bundle.min.js");
            
            AddScriptResource("_content/BootstrapBlazor/lib/overlayscrollbars/jquery.overlayScrollbars.min.js");
            AddScriptResource("_content/BootstrapBlazor/js/bootstrap.blazor.js");

            /*
            AddStyleSheetResource("_content/BootstrapBlazor/lib/chartjs/Chart.min.css");
            AddScriptResource("_content/BootstrapBlazor/lib/chartjs/Chart.bundle.min.js");
            */

            /*
            AddStyleSheetResource("_content/BootstrapBlazor/lib/summernote/summernote-bs4.min.css");
            AddScriptResource("_content/BootstrapBlazor/lib/summernote/summernote-bs4.min.js");
            AddScriptResource("_content/BootstrapBlazor/lib/summernote/summernote-zh-CN.min.js");
            */
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddBootstrapBlazor();
            base.ConfigureServices(services);
        }
    }
}
