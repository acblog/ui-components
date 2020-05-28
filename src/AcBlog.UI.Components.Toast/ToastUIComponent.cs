﻿using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Toast
{
    public class ToastUIComponent : UIComponent
    {
        public ToastUIComponent() : this(true)
        {
        }

        public ToastUIComponent(bool autoLoad = true)
        {
            Services.AddBlazoredToast();
            AddStyleSheetResource("_content/Blazored.Toast/blazored-toast.min.css", autoLoad);
        }
    }
}
