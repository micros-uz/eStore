"use strict"

var estore = estore || {};

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
