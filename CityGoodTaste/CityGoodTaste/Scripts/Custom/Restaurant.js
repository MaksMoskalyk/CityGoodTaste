$(document).ready(function () {
     SetSearchAutocompleteRes();
    myMap();
    //$("#demo2").TouchSpin({
    //    min: 1,
    //    max: 100,
    //    stepinterval: 1,
    //    maxboostedstep: 100,
    //});

    //$('#datetimepicker').datetimepicker({
    //    inline: true
    //});

    
    $("#datepicker").datepicker({
        showAnim: "slideDown",
        showOtherMonths: true,
        selectOtherMonths: true,
        showButtonPanel: true,
        minDate: 0,
        maxDate: "+1M +10D",
        showWeek: true,
    });   

    $('.clockpicker').clockpicker({ donetext: '<span class="glyphicon glyphicon-ok"></span>' });

    SetAjaxForShemaModals();

    //function myMap() {      
    //    var myCenter = new google.maps.LatLng(41.878114, -87.629798);
    //    var mapProp = { center: myCenter, zoom: 12, scrollwheel: false, draggable: false, mapTypeId: google.maps.MapTypeId.ROADMAP };
    //    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    //    var marker = new google.maps.Marker({ position: myCenter });
    //    marker.setMap(map);
    //}

    $('#sumbitReservBt').click(function (event) {
        $('#closeModalReserv').click();
        $('#successModalLink').click();
        $('#name').val('');
        $('#phone').val('');
    });

})

function SetAjaxForShemaModals() {
    $('#startModalSchema').click(function () {
        var restId = document.getElementById('modalSchema').getAttribute('restId');
        $.ajax({
            url: '/Restaurant/Schema/' + restId,
            type: 'GET',
            success: function (data) {
                $('#modalSchema').empty();
                $('#modalSchema').append(data);
            },
            error: function (xhr, status, p3) {

            }
        });
    });
};

function SetSearchAutocompleteRes() {
    $("#searchTextEvents").autocomplete({
        source: '/Restaurant/GetSearchDataEvents'
    });
    $("#searchTextRestaurants").autocomplete({
        source: '/Restaurant/GetSearchDataRestaurants'
    });
}