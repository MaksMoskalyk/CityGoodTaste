$(document).ready(function () {

    SetEventsSearchAutocomplete();

    SetCheckboxClickHandler();

})


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