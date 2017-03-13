$(document).ready(function () {
    myMap();
    $("#demo2").TouchSpin({
        min: 1,
        max: 100,
        stepinterval: 1,
        maxboostedstep: 100,
    });

    //$('#datetimepicker').datetimepicker({
    //    inline: true
    //});


    $('#dp6').datepicker({
        todayBtn: 'linked'
    });
    
    $('.clockpicker').clockpicker({ donetext: 'Done' });

    function myMap() {      
        var myCenter = new google.maps.LatLng(41.878114, -87.629798);
        var mapProp = { center: myCenter, zoom: 12, scrollwheel: false, draggable: false, mapTypeId: google.maps.MapTypeId.ROADMAP };
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
        var marker = new google.maps.Marker({ position: myCenter });
        marker.setMap(map);
    }

});

