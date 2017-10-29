$(document).ready(function () {
    google.maps.event.addDomListener(window, 'load', initilize);
    function initilize() {
        var autocomplete = new google.maps.places.Autocomplete(getElementById('textautocomlete'));
        google.maps.event.addDomListener(autocomplete, 'place_change', function () {

            var places = autocomplete.getplace();
            var location = "<b>Location</b>" + places.formatted_address + "<br/>";
            location += "<b>Lat</b>" + places.geometry.location.lat() + "<br/>";
            location += "<b>Lng</b>" + places.geometry.location.lng() + "<br/>";
            document.getElementById('result').innerHTML = location;

        });

    }
});