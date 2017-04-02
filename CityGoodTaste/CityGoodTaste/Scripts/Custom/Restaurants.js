$(document).ready(function () {

    SetRestaurantsSearchAutocomplete();

    SetCheckboxClickHandler();
})


function SetRestaurantsSearchAutocomplete() {
    $("#searchTextRestaurants").autocomplete({
        source: '/Restaurant/GetSearchDataRestaurants'
    });
}

function SetCheckboxClickHandler() {
    $('.CuisinesCheck').click(function () {
        var t = document.getElementById("sendData");
        t.click();
    });

    $('.FeaturesCheck').click(function () {
        var t = document.getElementById("sendData");
        t.click();
    });

    $('.MealGroups').click(function () {
        var t = document.getElementById("sendData");
        t.click();
    });
}