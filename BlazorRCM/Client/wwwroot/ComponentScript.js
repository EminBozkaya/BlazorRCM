////function loadJs(sourceUrl) {
////	if (sourceUrl.Length == 0) {
////		console.error("Invalid source URL");
////		return;
////	}

////	var tag = document.createElement('script');
////	tag.src = sourceUrl;
////	tag.type = "text/javascript";

////	tag.onload = function () {
////		console.log("Script loaded successfully");
////	}

////	tag.onerror = function () {
////		console.error("Failed to load script");
////	}

////	document.body.appendChild(tag);
////}




function loadJs(sourceUrl) {
//window.loadJs(sourceUrl) {
    if (sourceUrl.Length == 0) {
        console.error("Invalid source URL");
        return;
    }

    var urls = sourceUrl.split("+");

    //for (const element of urls) {
    //    var tag = document.createElement('script');
    //    tag.src = element;
    //    tag.type = "text/javascript";

    //    tag.onload = function () {
    //        console.log("Script loaded successfully");
    //    }

    //    tag.onerror = function () {
    //        console.error("Failed to load script");
    //    }

    //    document.body.appendChild(tag);
    //}

    for (const element of urls) {
        if (element.includes("css")) {
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


    /*To load "jquery.min.js" to head element in html and after delete*/
    //----------------------------------------------
    var jq = document.createElement('script');
    jq.src = urls[urls.length - 1];
    jq.type = "text/javascript";

    jq.onload = function () {
        console.log("Script loaded successfully");
    }

    jq.onerror = function () {
        console.error("Failed to load script");
    }

    //document.body.appendChild(jq);
    document.head.appendChild(jq);

    urls.splice(-1)
    //--------------------------------------------------
    for (const element of urls) {
        //if (element.includes("jquery.min.js")) {
        //    continue;
        //}
        if (element.includes("js")) {
            var tag = document.createElement('script');
            tag.src = element;
            tag.type = "text/javascript";

            tag.onload = function () {
                console.log("Script loaded successfully");
            }

            tag.onerror = function () {
                console.error("Failed to load script");
            }

            document.body.appendChild(tag);
        }
    }




    //urls.forEach(function (value) {

    //    var tag = document.createElement('script');
    //    tag.src = value;
    //    tag.type = "text/javascript";

    //    tag.onload = function () {
    //        console.log("Script loaded successfully");
    //    }

    //    tag.onerror = function () {
    //        console.error("Failed to load script");
    //    }

    //    document.body.appendChild(tag);
    //})
}
