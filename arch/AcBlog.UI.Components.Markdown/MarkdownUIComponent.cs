using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StardustDL.RazorComponents.Markdown;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Markdown
{
    public class MarkdownUIComponent : UIComponent
    {
        public MarkdownUIComponent()
        {
            AddStyleSheetResource("_content/StardustDL.RazorComponents.Markdown/highlight.js/github.css");
            AddStyleSheetResource("_content/StardustDL.RazorComponents.Markdown/katex/katex.min.css");
            AddStyleSheetResource("_content/StardustDL.RazorComponents.Markdown/css/markdown.css");
            AddScriptResource("_content/StardustDL.RazorComponents.Markdown/component-min.js");
            AddScriptResource("_content/StardustDL.RazorComponents.Markdown/mermaid/mermaid.min.js");
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMarkdownComponentService, MarkdownComponentService>();
            base.ConfigureServices(services);
        }
    }
}
