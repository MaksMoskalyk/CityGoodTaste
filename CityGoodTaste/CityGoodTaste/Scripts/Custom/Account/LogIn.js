$(document).ready(function () {
    var submitButton = document.getElementById("logInSubmit");
    if (submitButton != null)
        submitButton.addEventListener("click", SubmitClickHandler);
})


var emailMessage = "Введите почту";
var passwordMessage = "Введите пароль";


function SubmitClickHandler(e) {
    if (!IsEmailEntered())
    {
        $("#validationEmail").text(emailMessage);
        $("#validationEmail").css("display", "block");        
        e.preventDefault();
    }

    if (!IsPasswordEntered())
    {
        $("#validationPassword").text(passwordMessage);
        $("#validationPassword").css("display", "block");
        e.preventDefault();
    }

    if (e.defaultPrevented)
    {
        return;
    }
}

function IsEmailEntered() {
    var emailInput = document.getElementById("email");
    return (emailInput.value != "");
}

function IsPasswordEntered() {
    var passwordInput = document.getElementById("password");
    return (passwordInput.value != "");
}