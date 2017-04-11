$(document).ready(function () {
    AddSubmitEventHandler();
})

//Configuration block
var minPasswordLength = 6;
var validationSuccessColor = "white";
var validationFaultColor = "#FFD4DF";
var minPhoneLength = 4;
var maxPhoneLength = 13;

var emailMessage = "Почта введена неверно";
var passwordMessage = "Введите пароль из не менее чем 6 символов";
var passwordConfirmMessage = "Пароль не подтвержден";
var nameMessage = "Введите имя корректно";
var surnameMessage = "Введите фамилию корректно";
var phoneMessage = "Введите действительный номер телефона";


//Events handlers addition
function AddSubmitEventHandler() {
    var submitButton = document.getElementById("signUpButton");
    if (submitButton != null) {
        submitButton.addEventListener("click", SubmitClickHandler);
    }   
}

function AddInputEventHandlers() {
    var emailInput = document.getElementById("email");
    if (emailInput != null) {
        emailInput.addEventListener("input", EmailInputHandler);
    }

    var passwordInput = document.getElementById("password");
    if (passwordInput != null) {
        passwordInput.addEventListener("input", PasswordInputHandler);
    }

    var passwordConfirmInput = document.getElementById("passwordConfirm");
    if (passwordConfirmInput != null) {
        passwordConfirmInput.addEventListener("input", PasswordConfirmInputHandler);
    }

    var nameInput = document.getElementById("name");
    if (nameInput != null) {
        nameInput.addEventListener("input", NameInputHandler);
    }

    var surnameInput = document.getElementById("surname");
    if (surnameInput != null) {
        surnameInput.addEventListener("input", SurnameInputHandler);
    }

    var phoneInput = document.getElementById("phone");
    if (phoneInput != null) {
        phoneInput.addEventListener("input", PhoneInputHandler);
    }
}


//Events handlers implementation
function EmailInputHandler(e) {
    if (!IsEmailValid()) {
        $("#validationEmail").text(emailMessage);
        $("#email").css("background-color", validationFaultColor);
        $("#validationEmail").css("display", "block");
        e.preventDefault();
    }
    else {
        $("#email").css("background-color", validationSuccessColor);
        $("#validationEmail").css("display", "none");
    }
}

function PasswordInputHandler(e) {
    if (!IsPasswordValid()) {
        $("#validationPassword").text(passwordMessage);
        $("#password").css("background-color", validationFaultColor);
        $("#validationPassword").css("display", "block");
        e.preventDefault();
    }
    else {
        $("#password").css("background-color", validationSuccessColor);
        $("#validationPassword").css("display", "none");
    }
}

function PasswordConfirmInputHandler(e) {
    if (!IsPasswordConfirmationValid()) {
        $("#validationConfirmPassword").text(passwordConfirmMessage);
        $("#passwordConfirm").css("background-color", validationFaultColor);
        $("#validationConfirmPassword").css("display", "block");
        e.preventDefault();
    }
    else {
        $("#passwordConfirm").css("background-color", validationSuccessColor);
        $("#validationConfirmPassword").css("display", "none");
    }
}

function NameInputHandler(e) {
    if (!IsNameValid()) {
        $("#validationName").text(nameMessage);
        $("#name").css("background-color", validationFaultColor);
        $("#validationName").css("display", "block");
        e.preventDefault();
    }
    else {
        $("#name").css("background-color", validationSuccessColor);
        $("#validationName").css("display", "none");
    }
}

function SurnameInputHandler(e) {
    if (!IsSurnameValid()) {
        $("#validationSurname").text(surnameMessage);
        $("#surname").css("background-color", validationFaultColor);
        $("#validationSurname").css("display", "block");
        e.preventDefault();
    }
    else {
        $("#surname").css("background-color", validationSuccessColor);
        $("#validationSurname").css("display", "none");
    }
}

function PhoneInputHandler(e) {
    if (!IsPhoneValid()) {
        $("#validationPhone").text(phoneMessage);
        $("#phone").css("background-color", validationFaultColor);
        $("#validationPhone").css("display", "block");
        e.preventDefault();
    }
    else {
        $("#phone").css("background-color", validationSuccessColor);
        $("#validationPhone").css("display", "none");
    }
}


//Submit handler
function SubmitClickHandler(e) {
    EmailInputHandler(e);
    PasswordInputHandler(e);
    PasswordConfirmInputHandler(e);
    NameInputHandler(e);
    SurnameInputHandler(e);
    PhoneInputHandler(e);

    if (e.defaultPrevented) {
        AddInputEventHandlers()
        return;
    }
}


//Validation block
function IsEmailValid() {
    var emailInput = document.getElementById("email");
    var mask = /^[A-Za-z](\w{1,16})(@)([a-z]+\.)([a-z]+\.)?([a-z]{2,4})$/;
    return (emailInput.value.match(mask));
}

function IsPasswordValid() {
    var passwordInput = document.getElementById("password");
    var mask = /^\w+$/;
    return (passwordInput.value.match(mask) &&
        passwordInput.value.length >= minPasswordLength);
}

function IsPasswordConfirmationValid() {
    var passwordConfirmInput = document.getElementById("passwordConfirm");
    var passwordInput = document.getElementById("password");
    return (passwordConfirmInput.value == passwordInput.value &&
        passwordConfirmInput.value != "");
}

function IsNameValid() {
    var nameInput = document.getElementById("name");
    var nameMaskRu = /^[\u0410-\u042F\u0430-\u044F]+$/;
    var nameMaskEng = /^[A-Za-z]+$/;
    var f = nameInput.value.match(nameMaskEng);
    return (nameInput.value.match(nameMaskRu) ||
        nameInput.value.match(nameMaskEng));
}

function IsSurnameValid() {
    var surnameInput = document.getElementById("surname");
    var nameMaskRu = /^[\u0410-\u042F\u0430-\u044F]+$/;
    var nameMaskEng = /^[A-Za-z]+$/;
    return (surnameInput.value.match(nameMaskRu) ||
        surnameInput.value.match(nameMaskEng));
}

function IsPhoneValid() {
    var phoneInput = document.getElementById("phone");
    var mask = /^\d+$/;
    return (phoneInput.value.match(mask) &&
        phoneInput.value.length >= minPhoneLength &&
        phoneInput.value.length <= maxPhoneLength);
}