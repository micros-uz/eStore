"use strict";

$('.modal').on('hidden.bs.modal', function () {
    $('input:text', this).val('');
});

$('.modal').on('shown.bs.modal', function () {
    $('input:text', this).val('');
});

$(document).ready(function () {
    $(".modal").on('shown.bs.modal', function () {
        $('input:text:visible:first', this).focus();     
    });
});

function saveNewItem(model, url2, ddlId, modalId, valProp, textProp) {
    $.ajax({
        type: "POST",
        url: url2 + "/add",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        success: function () {
            $.getJSON(url2, null, function (data) {
                var ddl = $('#' + ddlId);
                ddl.empty();

                $(data).each(function (index, obj) {
                    ddl.append($("<option />").val(obj[valProp]).text(obj[textProp]));
                });
                $(ddl).find('option:contains(' + model[textProp] + ')').attr('selected', 'selected');
                $('#' + modalId).modal('hide');
            });
        },
        error: function (data) {
            alert(data.Message);
        }
    });
}

function saveNewGenre() {
    var genreModel = {
        Title: $('#genreTitle').val(),
        Desc: $('#genreDesc').val()
    };

    saveNewItem(genreModel, "/api/genre", "GenreId", "addGenre", "GenreId", "Title");
}

function saveNewAuthor() {
    var authorModel = {
        Name: $('#authorName').val()
    };

    saveNewItem(authorModel, "/api/author", "AuthorId", "addAuthor", "AuthorId", "Name");
}