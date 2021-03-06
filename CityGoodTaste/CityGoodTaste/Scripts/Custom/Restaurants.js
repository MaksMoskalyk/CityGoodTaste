﻿$(document).ready(function () {

    SetRestaurantsSearchAutocomplete();

    //SetCheckboxClickHandler();

    PrevenUserClickRestRank();

    CheckReviewText();

})

function DeselectRest(id) {
    var t = document.getElementById(id);
    t.click();
}
function DeselectRestAll() {
    var checkedEls = document.querySelectorAll('input[type=checkbox]:checked');
    for (i in checkedEls) {
        checkedEls[i].checked = false;
    }
    var t = document.getElementById("sendData");
    t.click();

}
function checkElChB() {
    var t = document.getElementById("sendData");
    t.click();
}
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


function reviewAddedSuccess() {
    $('input:radio').removeAttr('checked');
    $('#revText').val('');
    $('#successHeader').text('Отзыв');
    $('#successMsg').text('Благодарим Вас за отзыв.');
    $('#successModalLink').click();
}


function reviewAddedFailure() {
    $('#failureHeader').text('Ошибка');
    $('#failureMsg').text('Возможно, вы пытались отравить пустое сообщение.');
    $('#errorModalLink').click();
}

function CheckReviewText() {
    function isEmptyOrSpaces(str) {
        return str.length==0 || str.match(/^ *$/) !== null;
    }
    $('#makeReviewBt').click(function () {
        if (isEmptyOrSpaces($('#revText').val())) {
            reviewAddedFailure();
            return false;
        }
    });
}