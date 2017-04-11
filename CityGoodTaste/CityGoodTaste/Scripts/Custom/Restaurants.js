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
    restRank = restRank.replace(',', '');
    restRank = restRank.replace('.', '');
    $('#r' + restRank).attr('checked', true);
    alert(restRank);
};

function reviewAddedSuccess() {
    $('input:radio').removeAttr('checked');
    $('#revText').val('');
    $('#successHeader').text('Отзыв');
    $('#successMsg').text('Благодарим Вас за отзыв.');
    $('#successModalLink').click();
}