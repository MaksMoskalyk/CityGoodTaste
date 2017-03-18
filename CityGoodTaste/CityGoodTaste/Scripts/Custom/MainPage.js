$(document).ready(function () {
    SetAjaxForAuthenticationModals();
    $('.datepicker').datepicker();
})


function SetAjaxForAuthenticationModals() {
    $('#modalLogIn').on('hidden.bs.modal', function () {
        $('#modalLogIn').empty();
    });

    $('#modalSignUp').on('hidden.bs.modal', function () {
        $('#modalSignUp').empty();
    });

    $('#authenticationBlock').click(function () {

        $.ajax({
            url: '/Home/LogIn',
            type: 'GET',
            success: function (data) {
                $('#modalSignUp').empty();
                $('#modalLogIn').empty();
                $('#modalLogIn').append(data);
                $('#loginButton').click(function () {
                    var data = {
                        "login": $("#email").val(),
                        "password": $("#password").val(),
                        "rememberMe": $("#rememberMe").val()
                    };
                    var login = $('#email').val();
                    $.ajax({
                        type: "POST",
                        url: '/Account/Login',
                        data: JSON.stringify(data),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (result) {
                            

                        },
                        error: function (xhr, status, p3) {

                        }
                    });
                });
                $('#signUpOpenButton').click(function () {
                    $.ajax({
                        url: '/Home/SignUp',
                        type: 'GET',
                        success: function (data) {
                            $('#modalSignUp').empty();
                            $('#modalSignUp').append(data);
                        }
                    });
                });
            }
        });
    });
}