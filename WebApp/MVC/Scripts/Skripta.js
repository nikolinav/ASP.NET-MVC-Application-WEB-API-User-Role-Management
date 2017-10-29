$(document).ready(function () {


    var map;
    var geocoder;

    initializeMap();
    getAddress();

    function getAddress() {

        $.ajax({
            type: "POST",
            url: '/Mapp/GetUsers',
            success: function (data) {
                var result = JSON.stringify(data);
                $.each(data, function (i, item) {
                    var address = item.Address + "," + item.City;     
                    initialize(address);
                })
                },
            error: function (xhr, err) {
                alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                alert("responseText: " + xhr.responseText);
            }


        });
    }

    function initialize(address) {
        geocoder = new google.maps.Geocoder();
        
        if (geocoder) {
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
                        map.setCenter(results[0].geometry.location);

                         var infowindow = new google.maps.InfoWindow(
                            {
                                content: '<b>' + address + '</b>',
                                size: new google.maps.Size(150, 50)
                            });

                          var marker = new google.maps.Marker({
                            position: results[0].geometry.location,
                            map: map,
                            title: address
                        });
                        google.maps.event.addListener(marker, 'click', function () {
                            infowindow.open(map, marker);
                        });

                    } else {
                        alert("No results found");
                    }
                } else {
                    alert("Geocode was not successful for the following reason: " + status);
                }
            });
        }
    }

    function initializeMap() {
        var latlng = new google.maps.LatLng(45.267136, 19.833549);
        var myOptions = {
            zoom: 14,
            center: latlng,
            mapTypeControl: true,
            mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU },
            navigationControl: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById("map"), myOptions);
    }
});