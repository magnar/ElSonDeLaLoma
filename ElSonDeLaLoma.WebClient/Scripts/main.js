function ajaxError(jqXHR, textStatus, errorThrown) {
    var message = "There was an error with the AJAX request.\n";
    switch (textStatus) {
        case 'timeout':
            message += "The request timed out.";
            break;
        case 'notmodified':
            message += "The request was not modified but was not retrieved from the cache.";
            break;
        case 'parsererror':
            message += "XML/Json format is bad.";
            break;
        default:
            message += "HTTP Error (" + jqXHR.status + " " + jqXHR.statusText
                    + "). " + jqXHR.responseText;
    }
    message += "\n";
    alert(message);
}


function findLocation(successCallback) {

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showLocation, showError);
    }
    else {
        alert("geolocation api does not work with this browser");
    }

    function showLocation(position) {
        successCallback({ lat: position.coords.latitude, long: position.coords.longitude });
    }

    function showError(error) {
        console.log("error during finding location")
        switch (error.code) {
            case error.PERMISSION_DENIED:
                alert("User denied the request for Geolocation.");
                break;
            case error.POSITION_UNAVAILABLE:
                alert("Location information is unavailable.");
                break;
            case error.TIMEOUT:
                alert("The request to get user location timed out.");
                break;
            case error.UNKNOWN_ERROR:
                alert("An unknown error occurred.");
                break;
        }
    }
}

