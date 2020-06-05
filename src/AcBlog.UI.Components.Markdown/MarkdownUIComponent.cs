using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Markdown
{
    public class MarkdownUIComponent : UIComponent
    {
        public MarkdownUIComponent()
        {
            AddLocalStyleSheetResource("highlight.js/github.css");
            AddLocalStyleSheetResource("katex/katex.min.css");
            AddLocalScriptResource("component-min.js");
            AddLocalScriptResource("mermaid/mermaid.min.js");
        }
    }
}
