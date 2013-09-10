"use strict"

$(document).ready(function () {
    $("form:first *:input,select,textarea").filter(":not([readonly='readonly']):not([disabled='disabled']):not([type='hidden'])").first().focus();
});

$(document).ready(function () {
    $("#srchfrm").submit(function (e) {
        if (!$('#srchtxt').val()) {
            e.preventDefault(); // This will prevent the form submission
        }
    });
});