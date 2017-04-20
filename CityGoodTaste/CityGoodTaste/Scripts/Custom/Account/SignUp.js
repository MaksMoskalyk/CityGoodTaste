$(document).ready(function () {
    //$("span").css("background-color", "#EEEEEE");
    AddSubmitEventHandler();

    $("#Vkontakte").addClass("vkButton");
    $("#Facebook").addClass("facebookButton");
    $("#Google").addClass("googleButton");
})


//Configuration block
var minPasswordLength = 6;
var validationFaultClass = "has-error";
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
    $("#email").on('input blur', EmailInputHandler);

    $("#password").on('input blur', PasswordInputHandler);

    $("#passwordConfirm").on('input blur', PasswordConfirmInputHandler);

    $("#name").on('input blur', NameInputHandler);

    $("#surname").on('input blur', SurnameInputHandler);

    $("#phone").on('input blur', PhoneInputHandler);
}


//Events handlers implementation
function EmailInputHandler(e) {
    if (!IsEmailValid()) {
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
    if (!IsPasswordValid()) {
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

function PasswordConfirmInputHandler(e) {
    if (!IsPasswordConfirmationValid()) {
        $("#validationConfirmPassword").text(passwordConfirmMessage);
        $("#validationConfirmPassword").css("display", "block");
        $("#validationConfirmPasswordForm").addClass(validationFaultClass);
        e.preventDefault();
    }
    else {
        $("#validationConfirmPassword").css("display", "none");
        $("#validationConfirmPasswordForm").removeClass(validationFaultClass);
    }
}

function NameInputHandler(e) {
    if (!IsNameValid()) {
        $("#validationName").text(nameMessage);
        $("#validationName").css("display", "block");
        $("#validationNameForm").addClass(validationFaultClass);
        e.preventDefault();
    }
    else {
        $("#validationName").css("display", "none");
        $("#validationNameForm").removeClass(validationFaultClass);
    }
}

function SurnameInputHandler(e) {
    if (!IsSurnameValid()) {
        $("#validationSurname").text(surnameMessage);
        $("#validationSurname").css("display", "block");
        $("#validationSurnameForm").addClass(validationFaultClass);
        e.preventDefault();
    }
    else {
        $("#validationSurname").css("display", "none");
        $("#validationSurnameForm").removeClass(validationFaultClass);
    }
}

function PhoneInputHandler(e) {
    if (!IsPhoneValid()) {
        $("#validationPhone").text(phoneMessage);
        $("#validationPhone").css("display", "block");
        $("#validationPhoneForm").addClass(validationFaultClass);
        e.preventDefault();
    }
    else {
        $("#validationPhone").css("display", "none");
        $("#validationPhoneForm").removeClass(validationFaultClass);
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
        AddInputEventHandlers();
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