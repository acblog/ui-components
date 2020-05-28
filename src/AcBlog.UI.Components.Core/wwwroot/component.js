// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.AcBlogUIComponentsCore = {
    loadScript: function (src) {
        var fileref = document.createElement('script');
        fileref.setAttribute("type", "text/javascript");
        fileref.setAttribute("src", src);
        document.getElementsByTagName("head")[0].appendChild(fileref);
    },
    loadStyleSheet: function (href) {
        var fileref = document.createElement('link');
        fileref.setAttribute("rel", "stylesheet");
        fileref.setAttribute("type", "text/css");
        fileref.setAttribute("href", href);
        document.getElementsByTagName("head")[0].appendChild(fileref);
    }
};
