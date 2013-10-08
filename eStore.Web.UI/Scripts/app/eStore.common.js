"use strict"

var estore = estore || {};

//$(document).ready(function () {
//    $("form:first *:input,select,textarea").filter(":not([readonly='readonly']):not([disabled='disabled']):not([type='hidden'])").first().focus();
//});

$(document).ready(function () {
    $('#mainCarousel').carousel();
});

$(document).ready(function () {
    $("#srchfrm").submit(function (e) {
        if (!$('#srchtxt').val()) {
            e.preventDefault(); // This will prevent the form submission
        }
    });
});

$(document).ready(function () {
    $('#addToCart').on('click', function () {
        estore.dataservice.addToCart(function (json) {

        });
    });
});