$(document).ready(function () {

    SetEventsSearchAutocomplete();

    SetCheckboxClickHandler();

    SetDatepickers();

})
function DeselectET(id) {
    var t = document.getElementById(id);
    t.click();
}

function SetEventsSearchAutocomplete() {
    $("#searchTextEvents").autocomplete({
        source: '/Restaurant/GetSearchDataEvents'
    });
}

function SetCheckboxClickHandler() {
    $('.EventTypesCheck').click(function () {
        var t = document.getElementById("sendData");
        t.click();
    });
}

function SetDatepickers() {
    $(function () {
        $("#from").datepicker({
            minDate: 0,
            showOtherMonths: true,
            selectOtherMonths: true
        });
        $("#to").datepicker({
            minDate: 0,
            showOtherMonths: true,
            selectOtherMonths: true
        });
        var dateFormat = "mm/dd/yy",
          from = $("#from")
            .datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 1
            })
            .on("change", function () {
                to.datepicker("option", "minDate", getDate(this));
            }),
          to = $("#to").datepicker({
              defaultDate: "+1w",
              changeMonth: true,
              numberOfMonths: 1
          })
          .on("change", function () {
              from.datepicker("option", "maxDate", getDate(this));
          });

        function getDate(element) {
            var date;
            try {
                date = $.datepicker.parseDate(dateFormat, element.value);
            } catch (error) {
                date = null;
            }
            return date;
        }
    });
}