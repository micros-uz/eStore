var estore = estore || {};
estore.migrations = {};

estore.migrations.onBegin = function (ajaxContext) {

    if (!$('#option1').is(':checked') && !$('#option2').is(':checked')
        && $('#target').val().length == 0) {
        $('#infoAlert').removeClass('in').addClass('hide');
        $('#warnAlert').addClass('in').removeClass('hide');
        return false;
    }

    $('.close').click(function () {
        $(this).parent().removeClass('in');
    });

    return true;
}

estore.migrations.onSuccess = function () {
    $('#infoAlert').removeClass('in').addClass('hide');
    $('#warnAlert').removeClass('in').addClass('hide');
    $('#successAlert').addClass('in').removeClass('hide');

    vm.reload();
}

estore.migrations.onFailure = function (ajaxContext) {
    $('#infoAlert').removeClass('in').addClass('hide');
    $('#warnAlert').removeClass('in').addClass('hide');
    $('#errAlert').addClass('in').removeClass('hide');
    $('#errmsg').text(ajaxContext.responseText);
}

$("select").dblclick(function () {
    if (this.selectedIndex > -1) {
        $('#target').val(this.options[this.selectedIndex].value);
    }
});

$('#clearBtn').click(function () {
    $('#target').val('');
})

estore.MigrationsViewModel = function (model, url) {

    var migrationsDb = ko.observable(model.Database);
    var migrationsLocal = ko.observable(model.Local);
    var migrationsPending = ko.observable(model.Pending);

    var reload = function () {
        $.getJSON(url, null,
            function (data) {
                migrationsDb(data.database);
                migrationsLocal(data.local);
                migrationsPending(data.pending);
            });
    };

    return {
        reload: reload,
        migrationsDb: migrationsDb,
        migrationsLocal: migrationsLocal,
        migrationsPending: migrationsPending,

    }
};