window.AcBlogUIComponentsCore = {
    loadScript: function (src) {
        var fileref = document.createElement('script');
        fileref.setAttribute("type", "text/javascript");
        fileref.setAttribute("src", src);
        document.body.appendChild(fileref);
    },
    loadStyleSheet: function (href) {
        var fileref = document.createElement('link');
        fileref.setAttribute("rel", "stylesheet");
        fileref.setAttribute("type", "text/css");
        fileref.setAttribute("href", href);
        document.head.appendChild(fileref);
    }
};
