const baseUrl = "http://wh2309.danskenet.net:5001/api/";

function getHtttpRequest(method, url) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", baseUrl + url, true);
    return xmlHttp;
}

function login(username, callback) {
    var xmlHttp = getHtttpRequest("GET", "login");
    xmlHttp.send(null);

    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4 && xmlHttp.status == 200)
            console.log(xmlHttp.responseText);
            //callback(xmlHttp.responseText);
    }

    return xmlHttp.responseText;
}