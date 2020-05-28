using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AcBlog.UI.Components
{
    public class UIComponentResource
    {
        public UIComponentResourceType Type { get; set; }

        public string Path { get; set; } = string.Empty;

        public bool AutoLoad { get; set; } = true;

        public async Task Load(IJSRuntime jsRuntime)
        {
            switch (Type)
            {
                case UIComponentResourceType.Script:
                    await JsInterop.LoadScript(jsRuntime, Path);
                    break;
                case UIComponentResourceType.StyleSheet:
                    await JsInterop.LoadStyleSheet(jsRuntime, Path);
                    break;
            }
        }
    }
}
