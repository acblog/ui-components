using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace AcBlog.Extensions
{
    public class ExtensionCollection
    {
        public ExtensionCollection(IServiceCollection services) => Services = services;

        IServiceCollection Services { get; }

        public IList<Extension> Extensions { get; } = new List<Extension>();

        public ExtensionCollection AddExtension<TExtension>()
            where TExtension : Extension, new() => AddExtension(new TExtension());

        public ExtensionCollection AddExtension<TExtension>(TExtension extension)
            where TExtension : Extension
        {
            Extensions.Add(extension);
            Services.TryAddSingleton(extension);
            extension.ConfigureServices(Services);
            return this;
        }
    }
}
