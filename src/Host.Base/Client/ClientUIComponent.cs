using AcBlog.UI.Components;

namespace Host.Base.Client
{
    public class ClientUIComponent : UIComponent
    {
        public ClientUIComponent()
        {
            AddStyleSheetResource("css/bootstrap/bootstrap.min.css");
            AddStyleSheetResource("css/app.css");
            AddStyleSheetResource("//cdn.materialdesignicons.com/5.3.45/css/materialdesignicons.min.css");
        }
    }
}
