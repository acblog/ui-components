using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Modal
{
    public class ModalUIComponent : UIComponent
    {
        public ModalUIComponent() : this(true)
        {
        }

        public ModalUIComponent(bool autoLoad = true)
        {
            Services.AddBlazoredModal();
            AddStyleSheetResource("_content/Blazored.Modal/blazored-modal.css", autoLoad);
        }
    }
}
