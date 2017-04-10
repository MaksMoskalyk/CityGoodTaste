$(document).ready(function () {

    SetRestaurantsSearchAutocomplete();

    SetCheckboxClickHandler();

    PrevenUserClickRestRank();

})

function PrevenUserClickRestRank() {
    $('#rankField input:radio').click(function () {
        return false;
    });  
}


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
    $('.NeighborhoodsCheck').click(function () {
        var t = document.getElementById("sendData");
        t.click();
    });
}

var SetRestRankStarts = function (restRank) {
    if (restRank == '0')
        return;
    $('#r' + restRank).attr('checked', true);
};

