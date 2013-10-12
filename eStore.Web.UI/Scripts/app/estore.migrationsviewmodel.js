var estore = estore || {};

$("select").dblclick(function () {
    if (this.selectedIndex > -1) {
        $('#target').val(this.options[this.selectedIndex].value);
    }
});

$('#clearBtn').click(function () {
    $('#target').val('');
})

estore.MigrationsViewModel = function (model, url) {

    var migrationsDb = ko.observable(model.database),
        migrationsLocal = ko.observable(model.local),
        migrationsPending = ko.observable(model.pending),

    reload = function () {
        $.getJSON(url, null,
            function (data) {
                migrationsDb(data.database);
                migrationsLocal(data.local);
                migrationsPending(data.pending);
            });
    },

    onBegin = function (ajaxContext) {
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
    },

    onSuccess = function () {
        $('#infoAlert').removeClass('in').addClass('hide');
        $('#warnAlert').removeClass('in').addClass('hide');
        $('#successAlert').addClass('in').removeClass('hide');

        vm.reload();
    },

    onFailure = function (ajaxContext) {
        $('#infoAlert').removeClass('in').addClass('hide');
        $('#warnAlert').removeClass('in').addClass('hide');
        $('#errAlert').addClass('in').removeClass('hide');
        $('#errmsg').text(ajaxContext.responseText);
    };

    var vm = {
        onBegin: onBegin,
        onSuccess: onSuccess,
        onFailure: onFailure,
        reload: reload,
        migrationsDb: migrationsDb,
        migrationsLocal: migrationsLocal,
        migrationsPending: migrationsPending,
    }

    return vm;
};