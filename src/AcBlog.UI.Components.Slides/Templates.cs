using System;
using System.Collections.Generic;
using System.Text;

namespace AcBlog.UI.Components.Slides
{
    class Templates
    {
        const string Slides = @"<!DOCTYPE html>
<html>
<head>
<title>Title</title>
<meta charset=""utf-8"">
</head>
<body>
<textarea id=""source"">
@Value
</textarea>
<script src=""_content/AcBlog.UI.Components.Slides/remark/remark.min.js"">
</script>
<script>
window.onerror = function(message, source, lineno, colno, error) { return true; }
var slideshow = remark.create();
</script>
</body>
</html>
";

        public static string RenderSlides(string value)
        {
            return Slides.Replace("@Value", value);
        }
    }
}
