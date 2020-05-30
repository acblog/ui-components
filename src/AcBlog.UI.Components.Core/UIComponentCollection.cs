using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace AcBlog.UI.Components
{
    public class UIComponentCollection
    {
        public UIComponentCollection(IServiceCollection services) => Services = services;

        IServiceCollection Services { get; }

        public IList<UIComponent> Components { get; } = new List<UIComponent>();

        public UIComponentCollection AddUIComponent<TComponent>()
            where TComponent : UIComponent, new() => AddUIComponent(new TComponent());

        public UIComponentCollection AddUIComponent<TComponent>(TComponent component)
            where TComponent : UIComponent
        {
            Components.Add(component);
            Services.TryAddSingleton(component);
            Services.TryAddEnumerable(component.Services);
            return this;
        }
    }
}
