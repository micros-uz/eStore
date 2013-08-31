$(function () {
    $('#genreDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Add Genre',
        buttons: {
            'Save': function () {
                var createGenreForm = $('#createGenreForm');
                if (createGenreForm.valid()) {
                    $.post(createGenreForm.attr('action'), createGenreForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it

                            $('#GenreId').append(
                                    $('<option></option>')
                                        .val(data.Genre.GenreId)
                                        .html(data.Genre.Name)
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#genreDialog').dialog('close');
                        }
                    });
                }
            },

            'Cancel': function () {
                $(this).dialog('close');
            }
        }
    });
})