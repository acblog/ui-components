using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Loading
{
    public class LoadingUIComponent : UIComponent
    {
        public LoadingUIComponent()
        {
            AddLocalStyleSheetResource("component.css");
        }
    }
}
