"use strict"

$(document).ready(function () {
    $("form:first *:input,select,textarea").filter(":not([readonly='readonly']):not([disabled='disabled']):not([type='hidden'])").first().focus();
});
