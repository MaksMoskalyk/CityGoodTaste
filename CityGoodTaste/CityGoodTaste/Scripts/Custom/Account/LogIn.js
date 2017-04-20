$(document).ready(function () {
    //$("span").css("background-color", "#EEEEEE");
    AddSubmitEventHandler();

    $("#Vkontakte").addClass("vkButton");
    $("#Facebook").addClass("facebookButton");
    $("#Google").addClass("googleButton");
})


//Configuration block
var validationFaultClass = "has-error";
var emailMessage = "Введите почту";
var passwordMessage = "Введите пароль";


//Events handlers addition
function AddSubmitEventHandler() {
    var submitButton = document.getElementById("logInButton");
    if (submitButton != null) {
        submitButton.addEventListener("click", SubmitClickHandler);
    }
}

function AddInputEventHandlers() {
    $("#email").on('input blur', EmailInputHandler);

    $("#password").on('input blur', PasswordInputHandler);
}


//Events handlers implementation
function EmailInputHandler(e) {
    if (!IsEmailEntered()) {
        $("#validationEmail").text(emailMessage);
        $("#validationEmail").css("display", "block");
        $("#validationEmailForm").addClass(validationFaultClass);
        e.preventDefault();
    }
    else {
        $("#validationEmail").css("display", "none");
        $("#validationEmailForm").removeClass(validationFaultClass);
    }
}

function PasswordInputHandler(e) {
    if (!IsPasswordEntered()) {
        $("#validationPassword").text(passwordMessage);
        $("#validationPassword").css("display", "block");
        $("#validationPasswordForm").addClass(validationFaultClass);
        e.preventDefault();
    }
    else {
        $("#validationPassword").css("display", "none");
        $("#validationPasswordForm").removeClass(validationFaultClass);
    }
}


//Submit handler
function SubmitClickHandler(e) {
    EmailInputHandler(e);
    PasswordInputHandler(e);

    if (e.defaultPrevented) {
        AddInputEventHandlers();
        return;
    }
}


//Validation block
function IsEmailEntered() {
    var emailInput = document.getElementById("email");
    return (emailInput.value != "");
}

function IsPasswordEntered() {
    var passwordInput = document.getElementById("password");
    return (passwordInput.value != "");
}