window.AcBlogUIComponentsCore = {
    loadScript: function (src) {
        return new Promise((resolve, reject) => {
            var script = document.createElement('script');
            script.src = src;
            script.type = "text/javascript";

            script.onload = function () {
                resolve()
            }
            script.onerror = function (error) {
                reject(error)
            }

            document.body.appendChild(script);
        })
    },
    loadStyleSheet: function (href) {
        var link = document.createElement('link');
        link.rel = "stylesheet";
        link.type = "text/css";
        link.href = href;
        document.head.appendChild(link);
    }
};