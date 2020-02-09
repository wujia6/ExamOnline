/**
 * JQuery序列化扩展方法
 * */
$.fn.serializeObject = function () {
    var hasOwnProperty = Object.prototype.hasOwnProperty;
    return this.serializeArray().reduce(function (data, pair) {
        if (!hasOwnProperty.call(data, pair.name)) {
            data[pair.name] = pair.value;
        }
        return data;
    }, {});
};

/**
 * 显示模态框
 * @param {object} opts 参数对象
 * @param {string} opts.remote：远程url
 * @param {string} opts.title：模态框标题
 * @param {function} opts.onOpenedEvent：窗口完成显示后触发事件
 * @param {function} opts.onClosedEvent：窗口关闭后回调事件
 * @param {function} opts.onSaveEvent：保存按钮回调事件
 */
function showModal(opts) {
    var options = $.extend({}, { id: "#dialogModal", backdrop: true, keyboard: false }, opts);  //合并设置对象
    var self = $(options.id);
    self.on("show.bs.modal", function () { //调用show函数时触发事件
        self.find(".modal-content").load(options.remote, {}, function () {
            self.find(".modal-title").text(options.title);
            self.find(".modal-footer").children("#btn_modal_save").bind("click", options.onSaveEvent);
        });
    })
        .on("shown.bs.modal", opts.onOpenedEvent)
        .on("hidden.bs.modal", options.onClosedEvent)
        .modal("show");
}

/**
 * 警告模态框
 * @param {any} opts
 * @param {string} opts.title  标题文本
 * @param {string} opts.message  消息文本
 * @param {function} opts.onSureEvent    确定按钮事件的回调函数
 */
function showConfirm(opts) {
    var contentHtml =
        "<div class=\"modal-header\">" +
        "<a class=\"close\" data-dismiss=\"modal\">×</a><h4 class=\"modal-title\"></h4>" +
        "</div>" +
        "<div class=\"modal-body\"></div>" +
        "<div class=\"modal-footer\">" +
        "<a href =\"#\" class=\"btn btn-default\" data-dismiss=\"modal\">取消</a>" +
        "<a id =\"btn_confirm\" href=\"#\" class=\"btn btn-primary\">确定</a>" +
        "</div>";
    var options = $.extend({}, { id: "#dialogModal", backdrop: true, keyboard: false }, opts);  //合并设置对象
    var self = $(options.id);
    self.on("show.bs.modal", function () {
        self.find(".modal-content").html(contentHtml);
        self.find(".modal-title").text(opts.title);
        self.find(".modal-body").html("<p>" + opts.message + "</p>");
        self.find(".modal-footer").children("#btn_confirm").bind("click", function () {
            opts.onSureEvent();
            self.modal("hide");
        });
    }).modal("show");
}

//提示框
var showDialog = {
    instance: function (title, message) {
        var dlg = $("#dlg");
        if (dlg == "undefined" || dlg == null) {
            $("body").append(
                "<div id=\"dlg\" class=\"\" role=\"alert\">" +
                "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                "<strong>" + title + "</strong> " + message +
                "</div>"
            );
        }
        return $("#dlg");
    },
    error: function (message) {
        var dlg = this.instance("错误", message);
        dlg.attr("class", "alert alert-danger alert-dismissible");
        dlg.alert();
    },
    info: function (message) {
        var dlg = this.instance("信息", message);
        dlg.attr("class", "alert alert-info alert-dismissible");
        dlg.alert();
    },
    success: function (message) {
        var dlg = this.instance("提示", message);
        dlg.attr("class", "alert alert-success alert-dismissible");
        dlg.alert();
    },
    warning: function (message) {
        var dlg = this.instance("提示", message);
        dlg.attr("class", "alert alert-warning alert-dismissible");
        dlg.alert();
    }
}

//表单操作
var formExt = {
    /**
     * clear 清空表单
     * @param {any} frm
     */
    clear: function (frm) {
        $(":input", frm).not(":button,:submit,:reset").val('').removeAttr("checked").removeAttr("selected");
    },
    /**
     * load 加载表单数据
     * @param {any} frm：表单对象
     * @param {any} data：数据源
     */
    load: function (frm, json) {
        if (frm == null || frm == 'undefined' || json == null || json == 'undefined') {
            bt_dialog.error("表单或数据不能为空");
            return;
        }
        $(":input", frm).not(":button,:submit,:reset").each(function () {
            var v = Object.keys(json).find(this.getAttribute("name")).val();
            if (v != null && v != 'undefined')
                this.val(v);
        });
    }
} 

/**
 * 公共初始化bootstrapTable组件
 * @param {object} opts 参数对象
 * @param {string} opts.tableId 表格ID
 * @param {string} opts.requestUrl ajax请求地址
 * @param {string} opts.ajaxMethod ajax请求方法
 * @param {object} opts.callback ajax请求自定义参数回调函数
 * @param {array} opts.dataColumns 需绑定的数据列
 */
var initDataTable = function (opts) {
    var tab = new Object();
    //实列
    tab.instance = $(opts.tableId);
    //初始化table组件
    tab.instance.bootstrapTable({
        uniqueId: "ID",
        showHeader: true,
        showLoading: true,
        striped: true,
        toolbar: "#tab_toolbar",
        clickToSelect: true,
        search: false,
        //searchOnEnterKey: true,
        showColumns: true,
        showRefresh: true,
        showToggle: true,
        cache: false,
        url: opts.requestUrl,
        method: opts.ajaxMethod,
        queryParams: function (params) {
            var temp = {
                search: params.search,
                sort: params.sort,
                order: params.order,
                offset: params.offset,  //偏移量（跳过的记录数）
                limit: params.limit,    //页记录大小
            }
            var inputs = opts.callback();
            var parms = $.extend({}, temp, inputs);
            return parms;
        },
        paginationLoop: false,
        pagination: true,
        sidePagination: "server",
        pageNumber: 1,
        pageSize: 10,
        pageList: [10, 25, 50, 100],
        columns: opts.dataColumns,
        responseHandler: function (data) {
            console.log(data);
            return data;
        },
        onLoadSuccess: function () {
            console.log("数据加载成功");
        }
    });
    /**
     * 获取table组件已选择行
     * */
    tab.getSelectRows = function () {
        var rows = tab.instance.bootstrapTable("getSelections");
        //if (rows.length == 0 || rows == "undefined") {
        //    showDialog.error("请选择有效数据。");
        //    return;
        //}
        return rows;
    }
    /**
     * 设置table组件额外查询参数
     * @param {object} params 参数对象
     */
    tab.setQueryParams = function (params) {
        var options = opts.callback(params);
        return options;
    }
    /**
     * 加载数据
     * @param {string} url：请求地址
     * @param {object} parms：查询参数
     */
    tab.reload = function (url, parms) {
        var params = tab.setQueryParams(parms);
        $.get(url, params, function (data) {
            tab.instance.bootstrapTable("load", data);
        });
    }
    /**
     * 刷新table组件
     * */
    tab.refresh = function () {
        tab.instance.bootstrapTable("refresh");
    }
    return tab;
}
