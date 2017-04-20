$(document).ready(function () {
    $("div.form-group").addClass("formGroupCentered");
    $("div.input-group").addClass("inputGroupCentered");
    
    $("label").addClass("control-label col-sm-4");

    $("#manageAccountWrapper input").css("width", "240px");
    $("#manageAccountWrapper select").css("width", "240px");
    $("#manageAccountWrapper input").addClass("form-control");
    $("#manageAccountWrapper select").addClass("form-control");

    SetDatepicker();
})

function SetDatepicker() {
    $("#birthdayInput").datepicker({
        changeMonth: true,
        changeYear: true,
        showAnim: "slide",
        showOtherMonths: true,
        selectOtherMonths: true,
        showButtonPanel: true,
        yearRange: "-100:+0",
        maxDate: "+0D"
    });
}