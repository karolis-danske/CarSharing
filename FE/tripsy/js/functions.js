var database = "https://api.dev.june.dk/gemini-proxy/proxy/blaz-pc/api/";
var localDatabase = "http://localhost:8080/api/";
var distanceService = new google.maps.DistanceMatrixService;
var currentLocation = 'currentLocation';
var destination = 'Kalvarijų g. 61, Vilnius 09317, Lithuania';
var userId = 'userId';
var potentialTravels = [];
var potentialTravelsDestinations = [];
var filteredTravelsIndexes = [];
var filteredTravels = [];
var driverListHtml = [];
var allUsers = [];
var previousUser = "";

    
function setDestination() {
    localStorage.setItem("destination", document.getElementById("travelDestination").value);
    window.location.href = "driver-list.html";
}

function setDriver(name, car, destination) {
    localStorage.setItem("DriverName", name);
    localStorage.setItem("DriverCar", car);
    localStorage.setItem("DriverDestination", destination);
    window.location.href = "driver-details.html";
}

function getDriverList() {
    $.get(database + "users", function(data, status){
        if (status !== 'OK' && status !== 'success') {
            alert('Problems calling database: ' + status);
        } else {
            allUsers = data;
        }
    });

    $.get(database + "travels/all", function(data, status){
        if (status !== 'OK' && status !== 'success') {
            alert('Problems calling database: ' + status);
        }
        else if (data == null) {
            alert('No data received from database.');
        }
        else {
            data.forEach(function (travel) {
                if (travel.driverUserId !== userId) {
                    potentialTravels.push(travel);
                    potentialTravelsDestinations.push(travel.destination);
                }
            });
            if (potentialTravelsDestinations.length > 0) {
                distanceService.getDistanceMatrix({
                    origins: [localStorage.getItem("destination")],
                    destinations: potentialTravelsDestinations,
                    travelMode: 'WALKING',
                    unitSystem: google.maps.UnitSystem.METRIC,
                    avoidHighways: false,
                    avoidTolls: false
                }, function(response, status) {
                    if (status !== 'OK') {
                        alert('Problems calling distance service: ' + status);
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
                                if (results[j].duration.value <= 600) {
                                    filteredTravelsIndexes.push(j);
                                }
                            }
                        }

                        if(filteredTravelsIndexes.length > 0) {
                            filteredTravelsIndexes.forEach(function (travelIndex) {
                                filteredTravels.push(potentialTravels[travelIndex]);
                            });
                            filteredTravels.forEach(function (travel) {
                                allUsers.forEach(function (user) {
                                    if (user.id == travel.driverUserId && user.car !== null && user.id !== previousUser) {
                                        previousUser = user.id;
                                        driverListHtml.push('<li onclick=\'setDriver("' + user.name + '", "' + user.car.number + '", "' + travel.destination + '")\'><div class="driver"><span class="name">' + user.name + '</span><span class="car">' + user.car.number + '</span></div><div class="info"><span class="time">Leaves in <b>' + getRandomNumber() + 'min</b></span><span class="destination">' + travel.destination + '</span></div></li>');
                                    }
                                });
                            });

                            driverListHtml.forEach(function (driverHtml) {
                                $("ul.list.drivers").append(driverHtml);
                            });
                        } else {
                            alert('Failed to find any drivers :(');
                        }
                    }
                });
            }
            
        }
        console.log("Data: " + JSON.stringify(data) + "\nStatus: " + status);
    });
}

function getRandomNumber () {
    return Math.floor(Math.random() * 60);
}

$.postJSON = function(url, data, callback) {
    return jQuery.ajax({
    headers: { 
        'Accept': 'application/json',
        'Content-Type': 'application/json' 
    },
    'type': 'POST',
    'url': url,
    'data': JSON.stringify(data),
    'dataType': 'json',
    'success': callback
    });
};