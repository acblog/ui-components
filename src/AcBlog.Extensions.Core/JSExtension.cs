namespace AcBlog.Extensions
{
    internal class JSExtension : Extension
    {
        public JSExtension(ExtensionMetadata metadata)
        {
            Metadata = metadata;
            foreach (var v in metadata.LoadingResources)
                Resources.Add(v);
            AssemblyName = metadata.Name;
        }
    }
}
