$(document).ready(function () {

    SetDatepicker();

    SetClockpicker();

    SetAjaxForShemaModals();

    SubmitReservation();

    //MyMap();
})


function SetDatepicker() {
    $("#datepicker").datepicker({
        showAnim: "slideDown",
        showOtherMonths: true,
        selectOtherMonths: true,
        showButtonPanel: true,
        minDate: 0,
        maxDate: "+1M +10D",
    });
}

function SetClockpicker() {
    $('.clockpicker').clockpicker
        ({ donetext: '<span class="glyphicon glyphicon-ok"></span>' });
}

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
}

function SubmitReservation() {
    $('#sumbitReservBt').click(function (event) {
        $('#closeModalReserv').click();
        $('#successModalLink').click();
        $('#name').val('');
        $('#phone').val('');
    });
}

//function MyMap() {      
//    var myCenter = new google.maps.LatLng(41.878114, -87.629798);
//    var mapProp = { center: myCenter, zoom: 12, scrollwheel: false, draggable: false, mapTypeId: google.maps.MapTypeId.ROADMAP };
//    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
//    var marker = new google.maps.Marker({ position: myCenter });
//    marker.setMap(map);
//}