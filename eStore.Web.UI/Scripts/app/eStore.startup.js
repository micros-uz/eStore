var startup = function () {
    $('.modal').on('hidden.bs.modal', function () {
        $('input:text', this).val('');
    });

    $('.modal').on('shown.bs.modal', function () {
        $('input:text', this).val('');
    });
}();
