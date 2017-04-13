$('document').ready(

    createBorders()

);


function createBorders() {
    $("[coord='0.6']").css('border-bottom', '3px solid black');
    $('#16').css('border-bottom', '3px solid black');
    $('#46').css('border-bottom', '3px solid black');
    $('#47').css('border-right', '3px solid black');
    $('#49').css('border-right', '3px solid black');
    $('#411').css('border-right', '3px solid black');
    $('#64').css('border-bottom', '3px solid black');
    $('#74').css('border-bottom', '3px solid black');
    $('#84').css('border-bottom', '3px solid black');
    $('#94').css('border-bottom', '3px solid black');
    $('#104').css('border-bottom', '3px solid black');
    $('#114').css('border-bottom', '3px solid black');
    $('#124').css('border-bottom', '3px solid black');
    $('#134').css('border-bottom', '3px solid black');
    $('#155').css('border-bottom', '3px solid black');
    $('#165').css('border-bottom', '3px solid black');
    $('#175').css('border-bottom', '3px solid black');
    $('#185').css('border-bottom', '3px solid black');
    $('#195').css('border-bottom', '3px solid black');
    $('#205').css('border-bottom', '3px solid black');
    $('#215').css('border-bottom', '3px solid black');
    $('#156').css('border-left', '3px solid black');
    $('#159').css('border-left', '3px solid black');
    $('#1511').css('border-left', '3px solid black');
    $('#00').css('border-top', '3px solid black');
    $('#10').css('border-top', '3px solid black');
    $('#20').css('border-top', '3px solid black');
    $('#30').css('border-top', '3px solid black');
    $('#40').css('border-top', '3px solid black');
    $('#50').css('border-top', '3px solid black');
    $('#51').css('border-right', '3px solid black');
    $('#52').css('border-right', '3px solid black');
    $('#53').css('border-right', '3px solid black');
    $('#54').css('border-right', '3px solid black');
    $('#55').css('border-right', '3px solid black');
    $('#50').css('border-right', '3px solid black');
    $('#144').css('border-bottom', '3px solid black');
    $('#145').css('border-right', '3px solid black');
    $('#216').css('border-right', '3px solid black');
    $('#217').css('border-right', '3px solid black');
    $('#218').css('border-right', '3px solid black');
    $('#219').css('border-right', '3px solid black');
    $('#2110').css('border-right', '3px solid black');
    $('#2111').css('border-right', '3px solid black');
    $('#011').css('border-bottom', '3px solid black');
    $("[coord='1.11']").css('border-bottom', '3px solid black');
    $("[coord='2.11']").css('border-bottom', '3px solid black');
    $('#311').css('border-bottom', '3px solid black');
    $('#411').css('border-bottom', '3px solid black');
    $('#63').css('border-bottom', '3px solid black');
    $('#73').css('border-bottom', '3px solid black');
    $('#83').css('border-bottom', '3px solid black');
    $('#93').css('border-bottom', '3px solid black');
    $('#103').css('border-bottom', '3px solid black');
    $('#113').css('border-bottom', '3px solid black');
    $('#123').css('border-bottom', '3px solid black');
    $('#133').css('border-bottom', '3px solid black');
    $('#143').css('border-bottom', '3px solid black');
    $('#154').css('border-left', '3px solid black');

    for (var i = 7; i < 22; i++) {
        $('#' + i + '11').css('border-bottom', '3px solid black');
    }

    $('#94').append('<p style="font:bold; font-size: 150%">B</p>');
    $('#104').append('<p style="font:bold; font-size: 150%">A</p>');
    $('#114').append('<p style="font:bold; font-size: 150%">R</p>');

    var color = "#fcfcfc";
    for (var x = 0; x < 6; x++) {
        for (var y = 0; y < 12; y++) {
            $("[coord='" + x + "." + y + "']").css('background-color', color);
        }
    }

    for (var x = 6; x < 15; x++) {
        for (var y = 5; y < 12; y++) {
            $("[coord='" + x + "." + y + "']").css('background-color', color);
        }
    }

    for (var x = 6; x < 15; x++) {
        for (var y = 5; y < 12; y++) {
            $("[coord='" + x + "." + y + "']").css('background-color', color);
        }
    }

    for (var x = 15; x < 22; x++) {
        for (var y = 6; y < 12; y++) {
            $("[coord='" + x + "." + y + "']").css('background-color', color);
        }
    }

    var barColor = "#ffc1c1";
    for (var x = 6; x < 15; x++) {
        for (var y = 4; y < 5; y++) {
            $("[coord='" + x + "." + y + "']").css('background-color', barColor);
        }
    }

    $('#09').append('<img style="width:36px; height:36px" src="/Content/icons/SchemaIcons/tv.png" alt="loading"/>');
}