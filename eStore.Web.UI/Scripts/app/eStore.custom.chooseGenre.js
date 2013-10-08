"use strict";

function saveNewGenre() {
    var genreModel = {
        Title: $('#genreTitle').val(),
        Desc: $('#genreDesc').val()
    };
    
    estore.dataservice.saveNewItem(genreModel, "/api/genre", "Book_GenreId", "addGenre", "GenreId", "Title");
}

function saveNewAuthor() {
    var authorModel = {
        Name: $('#authorName').val()
    };

    estore.dataservice.saveNewItem(authorModel, "/api/author", "Book_AuthorId", "addAuthor", "AuthorId", "Name");
}