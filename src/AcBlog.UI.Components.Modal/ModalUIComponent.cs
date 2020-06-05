using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Modal
{
    public class ModalUIComponent : UIComponent
    {
        public ModalUIComponent()
        {
            Services.AddBlazoredModal();
            AddStyleSheetResource("_content/Blazored.Modal/blazored-modal.css");
        }
    }
}
