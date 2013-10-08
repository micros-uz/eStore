
estore.LogModel = function(model){
    var items = ko.observable(model.entries);

    return {
        items: items
    }
};

ko.applyBindings(new estore.LogModel(estore.Model));