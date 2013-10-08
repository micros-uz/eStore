var estore = estore || {};

estore.CartViewModel = function (model, delUrl, getUrl) {
            
    this.items = ko.observableArray(model.items);
    this.returnUrl = ko.observable(model.returnUrl);

    this.delItem = function (itemId, event) {
        var data = ko.toJS(itemId);
        var item = ko.dataFor(itemId);
        console.log("ww", data);
        $.ajax({
            url: delUrl.replace('-ID', data.cartItemId),
            type: 'Delete',
            data: data,
            context: this,
            success: function (data) {
                if (data.success) {
                    this.items.pop();
                }
            }
        });
    }.bind(this);

    this.reload = function () {
        $.ajax({
            url: getUrl,
            type: 'POST',
            context: this,
            success: function (data) {
                this.items(data);
            }
        });
    }.bind(this);

    this.total = ko.computed(function () {
        var total = 0;
        for (var k = 0; k < this.items().length; ++k) {
            total += this.items()[k].count * this.items()[k].price;
        }
        return total;
    }, this);
};
