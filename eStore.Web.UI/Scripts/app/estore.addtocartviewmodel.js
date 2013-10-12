var estore = estore || {};
estore.vm = estore.vm || {};

estore.AddToCartViewModel = function () {
    this.addToCart = function (vm, e) {
        var id = $(e.currentTarget).attr('data-bookid');
        alert('Book ID = ' + id);
        estore.dataservice.addToCart(id);
    };
};

(function attachModel() {
    estore.vm.addToCartVM = new estore.AddToCartViewModel();
})()