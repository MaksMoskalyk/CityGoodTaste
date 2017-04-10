$(document).ready(function () {
    var submitButton = document.getElementById("logInSubmit");
    submitButton.addEventListener("click", SubmitClickHandler);
})

function SubmitClickHandler(e) {
    if (!IsEmailEntered())
    {
        $("#validationEmail").text("Введите почту");
        $("#validationEmail").css("display", "block");        
        e.preventDefault();
    }

    if (!IsPasswordEntered())
    {
        $("#validationPassword").text("Введите пароль");
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