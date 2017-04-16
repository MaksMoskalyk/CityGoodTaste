$(document).ready(function () {
    $("div.form-group").addClass("formGroupCentered");
    $("div.input-group").addClass("inputGroupCentered");
    
    $("label").addClass("control-label col-sm-3");

    $("#manageAccountWrapper input").css("width", "240px");
    $("#manageAccountWrapper select").css("width", "240px");
    $("input, select").addClass("form-control");

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