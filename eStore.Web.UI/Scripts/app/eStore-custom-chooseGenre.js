"use strict";

function saveNewGenre() {
    var genreModel = {
        Title: $('#genreTitle').val(),
        Desc: $('#genreDesc').val()
    };
    
    dataservice.saveNewItem(genreModel, "/api/genre", "Book_GenreId", "addGenre", "GenreId", "Title");
}

function saveNewAuthor() {
    var authorModel = {
        Name: $('#authorName').val()
    };

    dataservice.saveNewItem(authorModel, "/api/author", "Book_AuthorId", "addAuthor", "AuthorId", "Name");
}