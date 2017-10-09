$(document).ready(function () {

    SetDatepicker();

    SetClockpicker();

    ReservBtClick();

    CheckBoxChecked();
});


function SetClockpicker() {
    $('.clockpicker').clockpicker
        ({ donetext: '<span class="glyphicon glyphicon-ok"></span>' });
}

function SetDatepicker() {
    $("#datepicker").datepicker({
        showAnim: "slideDown",
        showOtherMonths: true,
        selectOtherMonths: true,
        showButtonPanel: true,
        minDate: 0,
        maxDate: "+1M +10D",
        onSelect: function (date) {
            $.ajax({
                url: '/Administration/GetSchemaPartail',
                dataType: 'html',
                data: { reservdate: date },
                success: function (data) {
                    $('#schemaAndInfo').html(data);
                },
                error: function (xhr, status, p3) {

                }
            });
        }
    });
}



function removeReservSuccess() {
    $('#closeModalUnReserv').click();

    $('#headerSuccessModal').text('Резерв отменен');
    $('#successMsgModal').text('Резерв отменен успешно.');
    $('#successModalLink').click();
}

function reservSuccess() {
    $('#closeModalUnReserv').click();
    $('#closeModalClientReserv').click();
    $('#closeModalReserv').click();

    $('#headerSuccessModal').text('Резерв подтвержден');
    $('#successMsgModal').text('Резерв подтвержден успешно.');
    $('#successModalLink').click();
}

function reservByAdministrationSuccess() {
    $('#checkboxNewReservs:checked').prop('checked', false);

    reservSuccess();
}

function UnCheckNewReservationCheckBox() {
    $('#checkboxNewReservs:checked').prop('checked', false);
    SetDefaultColorAndRemoveAttrNewreservedTD();
}

function ReservBtClick() {
    $('#reservBt').click(function () {
        // check info - table / name / phone

        if ($('td[newreserved]').length == 0 ||
            $('#checkboxNewReservs:checked').val() != 'on' ||
            $('#name').val().length == 0 || $('#phone').val().length == 0) {
            $('#errorModalLink').click();
            return;
        }

        $('#newTablesInfoModal').empty();
        $('#nameModal').val($('#name').val());
        $('#phoneModal').val($('#phone').val());
        $('#dateModal').val($('#datepicker').val());
        $('#timeModal').val($('#timePicker').val());

        for (var i = 0; i < $('td[newReserved="True"]').length; i++) {
            var elemId = $('td[newReserved="True"]')[i].id;
            var id = document.getElementById($('td[newReserved="True"]')[i].id).getAttribute('tableid');
            var seats = document.getElementById($('td[newReserved="True"]')[i].id).getAttribute('seats');
            $('#newTablesInfoModal').append("<input data-val=\"true\" elemid=" + elemId + " id=\"tableId" + id + "\" name=\"tableId" + id + "\" type=\"hidden\" value=\"" + id + "\">");
            $('#newTablesInfoModal').append("<p style=\"font-weight:bold; padding-left:20px;\">#" + id + " <span style=\"padding-left:10px;\" class=\"glyphicon glyphicon-user\">" + seats + "</span></p>");
        }
        $('#confirmModalLink').click();

    });
}

function CheckBoxChecked() {
    $('#checkboxNewReservs').click(function () {
        SetDefaultColorAndRemoveAttrNewreservedTD();
    });
}

function SetDefaultColorAndRemoveAttrNewreservedTD() {
    $('td[selected]').css("background-color", '#fcfcfc');
    $('td[selected]').removeAttr('selected');

    for (var i = 0; i < $('td[newreserved]').length; i++) {
        var id = $('td[newreserved]')[i].id;
        document.getElementById("P." + id).style.color = "black";
    }

    $('td[newreserved]').css("background-color", '#fcfcfc');
    $('td[newreserved]').removeAttr('newreserved');
}