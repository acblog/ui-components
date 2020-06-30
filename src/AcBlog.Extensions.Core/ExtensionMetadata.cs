using System;
using System.Collections.Generic;

namespace AcBlog.Extensions
{
    public class ExtensionMetadata
    {
        public string Name { get; set; } = string.Empty;

        public string Onwer { get; set; } = string.Empty;

        public Version Version { get; set; } = new Version();

        public ExtensionType Type { get; set; } = ExtensionType.CSharp;

        public IList<Resource> LoadingResources { get; set; } = new List<Resource>();

        public string ClassName { get; set; } = string.Empty;
    }
}
