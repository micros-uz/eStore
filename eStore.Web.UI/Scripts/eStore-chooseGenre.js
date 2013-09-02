//  THIS IS NOT CALLED???
$('.modal').on('hidden', function () {
    $(this).removeData();
})
//  THIS IS NOT CALLED TOO - WHY???
$('#addGenre').on('hidden', function () {
    $(this).removeData('modal');
    alert('eee');
});

function save() {
    var genreModel = {
        Title: $('#genreTitle').val(),
        Desc: $('#genreDesc').val()
    }

    $.ajax({
        type: "POST",
        url: "/api/genre/add",
        data: JSON.stringify(genreModel),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            $.getJSON("/api/genre", null, function (data) {
                var ddl = $('#GenreId');
                ddl.empty();

                $(data).each(function (index, genre) {
                    ddl.append($("<option />").val(genre.GenreId).text(genre.Title));
                })
                $(ddl).find('option:contains(' + genreModel.Title + ')').attr('selected', 'selected');
                $('#addGenre').modal('hide');
            });
        },
        error: function (data) {
            alert(data.Message);
        }
    });;
}