(function () {
    var origin1 = new google.maps.LatLng(55.930385, -3.118425);
    var origin2 = 'Greenwich, England';
    var destinationA = 'Stockholm, Sweden';
    var destinationB = new google.maps.LatLng(50.087692, 14.421150);

    var service = new google.maps.DistanceMatrixService;
    service.getDistanceMatrix({
        origins: [origin1, origin2],
        destinations: [destinationA, destinationB],
        travelMode: 'DRIVING',
        unitSystem: google.maps.UnitSystem.METRIC,
        avoidHighways: false,
        avoidTolls: false
    }, function(response, status) {
        if (status !== 'OK') {
        alert('Error was: ' + status);
        } else {
        var originList = response.originAddresses;
        var destinationList = response.destinationAddresses;

        for (var i = 0; i < originList.length; i++) {
            var results = response.rows[i].elements;
            console.log("origin address: ", originList[i]);

            for (var j = 0; j < results.length; j++) {
                console.log("destination address: ", destinationList[j]);

                console.log(originList[i] + ' to ' + destinationList[j] +
                    ': ' + results[j].distance.text + ' in ' +
                    results[j].duration.text);
            }
        }
        }
    });

    $.get("https://api.dev.june.dk/gemini-proxy/proxy/blaz-pc/api/users", function(data, status){
        console.log("Data: " + JSON.stringify(data) + "\nStatus: " + status);
    });

    console.log("Greetings from main functions!");
})();