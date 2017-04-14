$(document).ready(function () {
    createTextClearButton();
    addTextClearButtons();
})

function textClearToggle(v) {
    return v ? 'addClass' : 'removeClass';
}

function createTextClearButton() {
    var offset = 23;
    $(document).on('input', '.clearable', function () {
        $(this)[textClearToggle(this.value)]('x');
    }).on('mousemove', '.x', function (e) {
        $(this)[textClearToggle(this.offsetWidth - offset < e.clientX - this.getBoundingClientRect().left)]('onX');
    }).on('touchstart click', '.onX', function (ev) {
        ev.preventDefault();
        $(this).removeClass('x onX').val('').change();
    });
}

function addTextClearButtons() {
    $('input[type="text"],input[type="password"]').addClass("clearable");
}