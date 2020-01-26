//JQuery序列化扩展方法
$.fn.serializeObject = function () {
    var hasOwnProperty = Object.prototype.hasOwnProperty;
    return this.serializeArray().reduce(function (data, pair) {
        if (!hasOwnProperty.call(data, pair.name)) {
            data[pair.name] = pair.value;
        }
        return data;
    }, {});
};

//JS公用组件

//table组件
var dataTable = {
    //请求地址
    postUrl: '',
    /**
     * 请求数据参数
     * @param {any} params：参数对象
     */
    queryParams: function (params) {
        params.index = this.pageNumber;
        params.size = this.pageSize;
        return params;
    },
    //表格对象
    tableTarget: null,
    //数据列
    dataColumns: [],
    /**初始化 */
    initTable: function () {
        if (this.tableTarget == null) {
            BootstrapDialog.show({ title: "系统提示", message: "列表组件初始化失败：table对象不能为空" });
            return;
        }
        if (this.postUrl == '') {
            BootstrapDialog.alert({ title: "系统提示",message: "列表组件初始化失败：数据请求地址不能为空" });
            return;
        }
        if (this.dataColumns == "undefined" || this.dataColumns == null) {
            BootstrapDialog.alert({ title: "系统提示", message: "列表组件初始化失败：数据列未设置" });
            return;
        }
        return this.tableTarget.bootstrapTable("destroy").bootstrapTable({
            uniqueId: "ID",         //行标识，一般为主键列
            showHeader: true,
            showLoading: true,
            striped: true,          //启用行交替颜色
            toolbar: "#toolbar",    //指定工具条容器
            clickToSelect: true,    //启用点击选中行
            search: true,           //显示表格搜索
            searchOnEnterKey: true,  //回车键执行搜索
            showColumns: true,       //显示全部列
            showRefresh: true,      //启用刷新按钮
            showToggle: true,        //启用详细视图和列表视图
            cache: false,           //是否启用缓存
            url: this.postUrl,               //数据请求地址
            method: "get",          //ajax提交方式（*）
            queryParams: this.queryParams,      //传递参数（*）
            pagination: true,       //启用分页（*）
            onlyInfoPagination: true,//显示总记录数
            sidePagination: "server",   //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,              //当前页码初始化加载第一页，默认第一页
            pageSize: 10,               //每页的记录行数（*）
            pageList: [10, 20, 50, 100],    //可供选择的每页的行数（*）
            columns: this.dataColumns
        });
    }
}

//自定义dialog
var bt_dialog = {
    /**
     * 信息弹框
     * @param {any} msg 弹框消息
     */
    alert: function (msg) {
        BootstrapDialog.alert({
            type: "BootStrapDialog.TYPE_WARNING",
            title: "错误提示",
            message: msg,
            btnOKLabel:"确定"
        });
    },
    /**
     * 信息弹框
     * @param {any} title：窗口标题
     * @param {any} msg：提示消息
     */
    show: function (title, msg) {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DANGER,  //弹框类型
            size: BootstrapDialog.SIZE_SMALL,   //弹框大小
            closeable: true,
            title: title,
            message: msg,
            buttons: [{// 设置关闭按钮
                label: '确定',
                action: function (dialog) { dialog.close();}
            }],
        })
    },
    /**
     * 确认弹框
     * @param {any} msg：提示消息
     * @param {any} funcBack：回调方法
     */
    confirm: function (msg, funcBack) {
        BootstrapDialog.confirm({
            type: BootstrapDialog.TYPE_WARNING,
            title: '警告',
            message: msg,
            closable: true,
            draggable: true,
            btnCancelLabel: '取消',
            btnOKLabel: '确定', // <-- Default value is 'OK',
            btnOKClass: 'btn-warning',
            callback: funcBack.call()
        })
    },
    /**
     * 加载url弹框
     * @param {any} title：窗口标题
     * @param {any} url: 远程路径
     * @param {any} parms：绑定到dialog数据对象（JSON）
     * @param {any} success：提交事件（回调方法）
     */
    remoteLoad: function (title, url, databind, success) {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DEFAULT,
            size: BootstrapDialog.SIZE_WIDE,
            title: title,
            cssClass: "fade",
            closeable: true,
            data: { 'pageToLoad': url },
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
                action: function (dialog) { success(dialog); }
            }],
            onshown: function (dialog) {
                if (databind != null && databind != "undefined") {
                    var frmTarget = dialog.getModalBody().find("form");
                    form.load(frmTarget, databind);
                }
            }
        });
    },
    /**
     * 加载url弹框
     * @param {any} parms 绑定到dialog参数对象
     */
    loadUrl: function (parms) {
        BootstrapDialog.show({
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
var form = {
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
        if (frm == null || frm == 'undefined' || data == null || data == 'undefined') {
            bt_dialog.show("错误提示", "表单或数据不能为空");
            return;
        }
        $(":input", frm).not(":button,:submit,:reset").each(function () {
            var v = Object.keys(json).find(this.getAttribute("name")).val();
            if (v != null && v != 'undefined') 
                this.val(v);
        });
    },
    /**
     * getJson 获取表单JSON对象
     * @param {any} frm 表单对象
     */
    getJsonObject: function (frm) {
        if (frm == null || frm == 'undefined') {
            bt_dialog.show("错误", "表单对象不能为空");
            return;
        }
        return frm.serializeArray();
    }
}
