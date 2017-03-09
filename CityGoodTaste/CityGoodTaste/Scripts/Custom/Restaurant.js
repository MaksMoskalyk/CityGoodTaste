$(document).ready(function () {

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







});

