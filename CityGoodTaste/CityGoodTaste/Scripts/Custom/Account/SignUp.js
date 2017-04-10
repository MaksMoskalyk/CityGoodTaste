$(document).ready(function () {
    var submitButton = document.getElementById("signUpButton");
    if (submitButton != null)
        submitButton.addEventListener("click", SubmitClickHandler);
})

function SubmitClickHandler(e) {
    if (!IsEmailEntered()) {
        $("#validationEmail").text("Введите почту");
        $("#validationEmail").css("display", "block");
        e.preventDefault();
    }

    if (!IsPasswordEntered()) {
        $("#validationPassword").text("Введите пароль");
        $("#validationPassword").css("display", "block");
        e.preventDefault();
    }

    if (!IsPasswordConfirmationEntered()) {
        $("#validationConfirmPassword").text("Введите подтверждение пароля");
        $("#validationConfirmPassword").css("display", "block");
        e.preventDefault();
    }

    if (!IsNameEntered()) {
        $("#validationName").text("Введите имя");
        $("#validationName").css("display", "block");
        e.preventDefault();
    }

    if (!IsSurnameEntered()) {
        $("#validationSurname").text("Введите фамилию");
        $("#validationSurname").css("display", "block");
        e.preventDefault();
    }

    if (!IsPhoneEntered()) {
        $("#validationPhone").text("Введите номер телефона");
        $("#validationPhone").css("display", "block");
        e.preventDefault();
    }

    if (e.defaultPrevented) {
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

function IsPasswordConfirmationEntered() {
    var passwordConfirmInput = document.getElementById("passwordConfirm");
    return (passwordConfirmInput.value != "");
}

function IsNameEntered() {
    var nameInput = document.getElementById("name");
    return (nameInput.value != "");
}

function IsSurnameEntered() {
    var surnameInput = document.getElementById("surname");
    return (surnameInput.value != "");
}

function IsPhoneEntered() {
    var phoneInput = document.getElementById("phone");
    return (phoneInput.value != "");
}