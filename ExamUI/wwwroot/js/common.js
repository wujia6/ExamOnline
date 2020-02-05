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

//自定义dialog
var bt_dialog = {
    /**
     * 信息弹框
     * @param {any} msg 弹框消息
     */
    error: function (msg) {
        return BootstrapDialog.alert({
            type: BootStrapDialog.TYPE_WARNING,
            size: BootstrapDialog.SIZE_SMALL,
            title: "错误",
            message: msg,
            btnOKLabel: "确定"
        });
    },
    /**
     * 信息弹框
     * @param {any} title：窗口标题
     * @param {any} msg：提示消息
     */
    information: function (msg) {
        return BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DANGER,  //弹框类型
            size: BootstrapDialog.SIZE_SMALL,   //弹框大小
            closeable: true,
            title: "信息",
            message: msg,
            buttons: [{// 设置关闭按钮
                label: '确定',
                action: function (dialog) { dialog.close(); }
            }],
        })
    },
    /**
     * 确认弹框
     * @param {any} msg：提示消息
     * @param {any} funcBack：回调方法
     */
    confirm: function (msg, funcBack) {
        return BootstrapDialog.confirm({
            type: BootstrapDialog.TYPE_WARNING,
            title: "警告",
            message: msg,
            closable: false,
            draggable: true,
            btnCancelLabel: "取消",
            btnOKLabel: "确定",
            btnOKClass: "btn-warning",
            callback: funcBack
        });
    },
    /**
     * 加载url弹框
     * @param {any} parms 绑定到dialog参数对象
     */
    remoteUrl: function (parms) {
        return BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DEFAULT,
            size: BootstrapDialog.SIZE_WIDE,
            title: parms.title,
            cssClass: "fade",
            closeable: false,
            data: { 'pageToLoad': parms.url },
            message: function (dialog) {
                var $message = $('<div></div>');
                var pageToLoad = dialog.getData('pageToLoad');
                $message.load(pageToLoad);
                return $message;
            },
            buttons: [{
                label: '<i class="fa fa-close"></i> 取消',
                action: function (dialog) { dialog.close(); }
            }, {
                label: '<i class="fa fa-check"></i> 提交',
                cssClass: 'btn btn-primary',
                action: function (dialog) { parms.event_submit(dialog); }
            }],
            onshown: function (dialog) { parms.event_showed(dialog); }
        });
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


//var bsTable = function (tableId, dataUrl, dataColumns) {
//    this.cache = false;
//    this.targetId = tableId;
//    this.toolbar = '#' + tableId + '_toolbar';
//    this.columns = dataColumns;
//    this.url = dataUrl;
//    this.method = 'get';
//    this.queryParams = {};
//    this.pagination = true;
//    this.sidePagination = 'server';
//    this.pageNumber = 1;
//    this.pageSize = 10;
//    this.pageList = [10, 25, 50];
//    this.classes = 'table table-hover';
//    this.instance = null;
//}
////对象原型
//bsTable.prototype = {
//    init: function () {
//        var targetId = this.targetId;
//        var self = this;
//        this.instance = $(targetId).bootstrapTable({
//            uniqueId: "ID",
//            showHeader: true,
//            showLoading: true,
//            striped: true,
//            toolbar: this.toolbar,  //工具栏(*)
//            clickToSelect: true,
//            search: false,
//            searchOnEnterKey: true,
//            showColumns: true,
//            showRefresh: true,
//            showToggle: true,
//            cache: this.cache, //其哟弄个缓存(*)
//            url: this.url,  //数据请求地址(*)
//            method: this.method,    //请求方式(*)
//            queryParams: function (params) {
//                return $.extend(self.queryParams, params);
//            },
//            paginationLoop: false,  //是否无限循环
//            pagination: this.pagination,       //启用分页（*）
//            sidePagination: this.sidePagination,   //分页方式：client客户端分页，server服务端分页（*）
//            pageNumber: this.pageNumber,              //当前页码初始化加载第一页，默认第一页
//            pageSize: this.pageSize,               //每页的记录行数（*）
//            pageList: this.pageList,    //可供选择的每页的行数（*）
//            columns: this.columns,
//            icons: {
//                refresh: 'glyphicon-repeat',
//                toggle: 'glyphicon-list-alt',
//                columns: 'glyphicon-list'
//            },
//            iconSize: 'outline'
//        });
//        return this;
//    },
//    setParams: function (params) {
//        this.queryParams = params;
//    },
//    getData: function () {
//        return this.instance.bootstrapTable("getData");
//    },
//    getSelected: function () {
//        var selectRows = this.instance.bootstrapTable("getSelections");
//        if (selectRows.length == 0) {
//            bt_dialog.error("请选择有效的数据行");
//            return;
//        }
//        return selectRows;
//    },
//    refresh: function (params) {
//        typeof params != 'undefined' ?
//            this.instance.bootstrapTable('refresh') : this.instance.bootstrapTable('refresh', params);
//    }
//}
//注册全局对象
//window.manageTable = bsTable;   
