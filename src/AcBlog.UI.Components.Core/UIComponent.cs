using AcBlog.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AcBlog.UI.Components
{
    public abstract class UIComponent : Extension
    {
        protected UIComponent()
        {
            var assname = GetType().Assembly.GetName();
            Metadata.Name = assname.Name;
            Metadata.Onwer = "StardustDL";
            Metadata.Version = assname.Version;
        }

        public UIComponent AddScriptResource(string path)
        {
            Resources.Add(new Resource(ResourceType.Script, path));
            return this;
        }

        public UIComponent AddStyleSheetResource(string path)
        {
            Resources.Add(new Resource(ResourceType.StyleSheet, path));
            return this;
        }

        public UIComponent AddLocalScriptResource(string path) => AddScriptResource($"_content/{AssemblyName}/{path}");

        public UIComponent AddLocalStyleSheetResource(string path) => AddStyleSheetResource($"_content/{AssemblyName}/{path}");
    }
}
