var estore = estore || {};

estore.LogModel = function(model){
    var items = ko.observable(model.entries);

    return {
        items: items
    }
};
