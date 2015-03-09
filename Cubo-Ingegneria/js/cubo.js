
$(document).ready(function () {

    $("img#logoDefault").click(function () {
        var id = "home";

        $('#' + id).siblings().find(".active").removeClass("active");

        $('#' + id).addClass("active");
        localStorage.setItem("selectedolditem", id);
        
    });

    $(".menu li").click(function () {
        var id = $(this).attr("id");

        $('#' + id).siblings().find(".active").removeClass("active");
                              
        $('#' + id).addClass("active");
        localStorage.setItem("selectedolditem", id);
    });

    var selectedolditem = localStorage.getItem('selectedolditem');

    if (selectedolditem != null) {
        $('#' + selectedolditem).siblings().find(".active").removeClass("active");
                                                
        $('#' + selectedolditem).addClass("active");
    }
});

$(document).ready(function initialize() {
   
        var mapProp = {
            center: new google.maps.LatLng(45.298257, 12.036265),
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(45.298257, 12.036265),
        });

        marker.setMap(map);

    google.maps.event.addDomListener(window, 'load', initialize);
});




