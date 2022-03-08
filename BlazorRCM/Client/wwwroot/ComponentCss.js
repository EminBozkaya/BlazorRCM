function loadCSS(sourceUrl) {
    if (sourceUrl.Length == 0) {
        console.error("Invalid source URL");
        return;
    }

    var urls = sourceUrl.split("+");

    for (const element of urls) {
        var link = document.createElement('link');
        link.rel = "stylesheet";
        link.type = "text/css";
        link.href = element;

        link.onload = function () {
            console.log("CSS loaded successfully");
        }

        link.onerror = function () {
            console.error("CSS to load script");
        }

        document.head.appendChild(link);
    }
}