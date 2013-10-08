var estore = estore || {};

estore.dataservice = function () {
    var saveNewItem = function (model, url2, ddlId, modalId, valProp, textProp) {
        $.ajax({
            type: "POST",
            url: url2 + "/add",
            data: JSON.stringify(model),
            contentType: "application/json;charset=utf-8",
            success: function () {
                $.getJSON(url2, null)
                    .done(function (data) {
                        var ddl = $('#' + ddlId);
                        ddl.empty();

                        $(data).each(function (index, obj) {
                            ddl.append($("<option />").val(obj[valProp]).text(obj[textProp]));
                        });
                        $(ddl).find('option:contains(' + model[textProp] + ')').attr('selected', 'selected');
                        $('#' + modalId).modal('hide');
                    })
                    .fail(function (jqxhr, textStatus, error) {
                        var err = textStatus + ', ' + error;
                        alert(err);
                    });

            },
            error: function (data) {
                alert(data.Message);
            }
        });
    },
        addToCart = function () {
            $.getJSON("/store/cart/add", { id: 4 })
                    .done(function (data) {
                        alert(data);
                    })
                    .fail(function (jqxhr, textStatus, error) {
                        var err = textStatus + ', ' + error;
                        alert(err);
                    });
        }

    return {
        saveNewItem: saveNewItem,
        addToCart: addToCart
    }
}();