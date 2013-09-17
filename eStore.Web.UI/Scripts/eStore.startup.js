var startup = function () {
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

    $(document).ready(function () {
        $('.addToCart').on('click', function () {
            dataservice.addToCart(function (json) {

            });
        });
    });

}();
