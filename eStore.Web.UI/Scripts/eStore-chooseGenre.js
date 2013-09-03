"use strict";

$('.modal').on('hidden.bs.modal', function () {
    $('input:text', this).val('');
});

$(document).ready(function () {
    $(".modal").on('shown.bs.modal', function () {
        $('input:text:visible:first', this).focus();     
    });
});

function saveNewItem(model, url2, id, valProp, textProp) {
    $.ajax({
        type: "POST",
        url: url2 + "/add",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        success: function () {
            $.getJSON(url2, null, function (data) {
                var ddl = $(id);
                ddl.empty();

                $(data).each(function (index, genre) {
                    ddl.append($("<option />").val(model[valProp]).text(model[textProp]));
                });
                $(ddl).find('option:contains(' + model[textProp] + ')').attr('selected', 'selected');
                $(id).modal('hide');
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

    var ee = genreModel["Title"];

//    saveNewItem(genreModel, "/api/genre", "GenreId", "Title");

    $.ajax({
        type: "POST",
        url: "/api/genre/add",
        data: JSON.stringify(genreModel),
        contentType: "application/json;charset=utf-8",
        success: function () {
            $.getJSON("/api/genre", null, function (data) {
                var ddl = $('#GenreId');
                ddl.empty();

                $(data).each(function (index, genre) {
                    ddl.append($("<option />").val(genre.GenreId).text(genre.Title));
                });
                $(ddl).find('option:contains(' + genreModel.Title + ')').attr('selected', 'selected');
                $('#addGenre').modal('hide');
            });
        },
        error: function (data) {
            alert(data.Message);
        }
    });
}