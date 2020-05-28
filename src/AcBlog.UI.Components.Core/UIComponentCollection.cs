using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace AcBlog.UI.Components
{
    public class UIComponentCollection
    {
        public WebAssemblyHostBuilder? HostBuilder { get; }

        public IList<UIComponent> Components { get; } = new List<UIComponent>();

        public UIComponentCollection AddUIComponent<TComponent>()
            where TComponent : UIComponent, new() => AddUIComponent(new TComponent());

        public UIComponentCollection AddUIComponent<TComponent>(TComponent component)
            where TComponent : UIComponent
        {
            Components.Add(component);
            HostBuilder?.Services.TryAddEnumerable(component.Services);
            return this;
        }
    }
}
