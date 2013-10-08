var estore = estore || {};

estore.UsersViewModel = function (url, filterParams) {

    this.rows = ko.observableArray();
    this.filterParams = ko.mapping.fromJS(filterParams);
    this.paging = {
        pageNumber: ko.observable(1),
        totalPagesCount: ko.observable(0),
        next: function () {
            var pn = this.pageNumber();
            if (pn < this.totalPagesCount()) this.pageNumber(pn + 1);
        },
        back: function () {
            var pn = this.pageNumber();
            if (pn > 1) this.pageNumber(pn - 1);
        },
        page: function (index) {
            if (index > 0 && index <= this.totalPagesCount())
                this.pageNumber(index)
        }
    };

    this.allPages = ko.dependentObservable(function () {
        var pages = [];
        for (i = 1; i <= this.paging.totalPagesCount() ; i++) {
            pages.push({ pageIdx: (i) });
        }
        return pages;
    }, this);

    this.reload = function () {
        var data = ko.toJS(this.filterParams);
        data.pageNumber = this.paging.pageNumber();
        $.ajax({
            url: url,
            type: 'POST',
            data: data,
            context: this,
            success: function (data) {
                console.log('post', data);
                this.rows(data.Data);
                this.paging.pageNumber(data.paging.pageNumber);
                this.paging.totalPagesCount(data.paging.totalPagesCount);
            }
        });
    }.bind(this);

    ko.dependentObservable(function () {
        //var data = ko.toJS(this.filterParams);
        //data.pageNumber = this.paging.PageNumber();
        //$.ajax({
        //    url: url,
        //    type: 'POST',
        //    data: data,
        //    context: this,
        //    success: function (data) {
        //        console.log('post', data);
        //        this.rows(data.Data);
        //        this.paging.PageNumber(data.Paging.PageNumber);
        //        this.paging.TotalPagesCount(data.Paging.TotalPagesCount);
        //    }
        //});
        this.reload();
    }, this);

    ko.dependentObservable(function () {
        var data = ko.toJS(this.filterParams);
        // Reset page number when any filtration parameters change
        // However this solution will cause double-load problem. Consider using pause-notifications
        this.paging.pageNumber(1);
    }, this);
};