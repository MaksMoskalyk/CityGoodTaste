$(document).ready(function () {
    SetSearchAutocomplete();
})


function SetSearchAutocomplete() {
    $("#searchText").autocomplete({
        source: '/Home/GetSearchData'
    });
}