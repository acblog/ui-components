using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AcBlog.UI.Components
{
    public abstract class UIComponent
    {
        private string _assemblyName = string.Empty;

        public IList<UIComponentResource> Resources { get; } = new List<UIComponentResource>();

        public IServiceCollection Services { get; } = new ServiceCollection();

        private string AssemblyName
        {
            get
            {
                if (string.IsNullOrEmpty(_assemblyName))
                {
                    _assemblyName = GetType().Assembly.GetName().Name;
                }
                return _assemblyName;
            }
        }

        public UIComponent AddLocalScriptResource(string path, bool autoLoad = true)
        {
            Resources.Add(new UIComponentResource
            {
                Type = UIComponentResourceType.Script,
                Path = $"_content/{AssemblyName}/{path}",
                AutoLoad = autoLoad,
            });
            return this;
        }

        public UIComponent AddLocalStyleSheetResource(string path, bool autoLoad = true)
        {
            Resources.Add(new UIComponentResource
            {
                Type = UIComponentResourceType.StyleSheet,
                Path = $"_content/{AssemblyName}/{path}",
                AutoLoad = autoLoad,
            });
            return this;
        }
    }
}
