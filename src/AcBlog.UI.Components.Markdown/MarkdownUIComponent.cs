using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Markdown
{
    public class MarkdownUIComponent : UIComponent
    {
        public MarkdownUIComponent() : this(true)
        {
        }

        public MarkdownUIComponent(bool autoLoad = true)
        {
            AddLocalStyleSheetResource("highlight.js/github.css", autoLoad);
            AddLocalStyleSheetResource("katex/katex.min.css", autoLoad);
            AddLocalScriptResource("component-min.js", autoLoad);
            AddLocalScriptResource("mermaid/mermaid.min.js", autoLoad);
        }
    }
}
