using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Loading
{
    public class LoadingUIComponent : UIComponent
    {
        public LoadingUIComponent() : this(true)
        {
        }

        public LoadingUIComponent(bool autoLoad = true)
        {
            AddLocalStyleSheetResource("component.css", autoLoad);
        }
    }
}
