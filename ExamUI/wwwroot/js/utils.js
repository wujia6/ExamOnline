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

//modal组件封装
var modalUtils = {
    /**
     * 显示模态框
     * @param {object} opts 参数对象
     * @param {string} opts.remote：远程url
     * @param {string} opts.title：模态框标题
     * @param {function} opts.onOpenedEvent：窗口完成显示后触发事件
     * @param {function} opts.onClosedEvent：窗口关闭后回调事件
     * @param {function} opts.onSaveEvent：保存按钮回调事件
     */
    showModal: function (opts) {
        //合并设置对象
        var options = $.extend({}, { id: "#dialogModal", backdrop: true, keyboard: false }, opts);
        var self = $(options.id);
        $(self).on("show.bs.modal", function () { //调用show函数时触发事件
            $(self).find(".modal-content").load(options.remote, {}, function () {
                $(self).find(".modal-title").text(options.title);
                $(self).find(".modal-footer").children("#btn_modal_save").bind("click", options.onSaveEvent);
            });
        })
            .on("shown.bs.modal", opts.onOpenedEvent)
            .on("hidden.bs.modal", options.onClosedEvent)
            .modal("show");
    },

    /**
     * 警告模态框
     * @param {any} opts
     * @param {string} opts.title  标题文本
     * @param {string} opts.message  消息文本
     * @param {function} opts.onSureEvent    确定按钮事件的回调函数
     */
    showConfirm: function (opts) {
        //html
        var contentHtml =
            "<div class='modal-header'>" +
            "<h4 class='modal-title'></h4><a class='close' data-dismiss='modal'>×</a>" +
            "</div>" +
            "<div class='modal-body'></div>" +
            "<div class='modal-footer'>" +
            "<a href ='#' class='btn btn-default' data-dismiss='modal'><i class='fas fa-close'></i> 取消</a>" +
            "<a id ='btn_confirm' href='#' class='btn btn-primary'><i class='fas fa-check'> 确定</a>" +
            "</div>";
        //合并设置对象
        var options = $.extend({}, { id: "#dialogModal", backdrop: true, keyboard: false }, opts);  
        var self = $(options.id);
        $(self).on("show.bs.modal", function () {
            $(self).find(".modal-content").html(contentHtml);
            $(self).find(".modal-title").text(opts.title);
            $(self).find(".modal-body").html("<strong>" + opts.message + "</strong>");
            $(self).find(".modal-footer").children("#btn_confirm").bind("click", function () {
                opts.onSureEvent();
                $(self).modal("hide");
            });
        }).modal("show");
    }
}

//form封装
var formUtils = {
    /**
     * 清空表单
     * @param {object} frm 表单对象
     */
    clear: function (frm) {
        $(":input", frm).not(":button,:submit,:reset,:option").val('').removeAttr("checked");
        $(":option: first-child", frm).attr("selected", true);
    },

    /**
     * 表单回显
     * @param {object} frm 表单对象
     * @param {JSON} json JSON对象
     * toLowerCase() ------ 将字符串中的所有字符都转换成小写；
     * toUpperCase() ------ 将字符串中的所有字符都转换成大写；
     */
    load: function (frm, obj) {
        if (frm == null || frm == 'undefined' || obj == null || obj == 'undefined') {
            layerUtils.info("表单对象或数据对象为空", 2);
            return;
        }
        for (var key in obj) {
            if (key == "0" || obj[key] == null) continue;
            //重新拼凑json属性名(parnetID=ParentID)
            var propName = key == "id" ? key.toUpperCase() : key.substr(0, 1).toUpperCase() + key.substr(1, key.lenght);
            var dmEle = frm.find("*[name=" + propName + "]");
            if (dmEle == "undefined" || dmEle == null)  continue;
            if ($(dmEle).is("select") && $.type(obj[key]) == "string") 
                dmEle.find("option:contains(" + obj[key] + ")").attr("selected", true);
            else   
                dmEle.val(obj[key]);
        }
    }
}

//layer组件封装
var layerUtils = {
    //弹窗
    alert: function (msg) {
        lyer.alert(msg, { icon: 1, closeButton: 0 }, function (index) {
            layer.close(index);
        });
    },
    //消息框
    info: function (msg, iconId) { layer.msg(msg, { icon: iconId }); },
    //提示
    tips: function (msg, elementId) { layer.tips(msg, elementId); },
    //询问
    confirm: function (msg, callback) {
        layer.confirm(msg, { icon: 3, title: '提示' }, function (index) {
            callback(index);
            layer.close(index);
        });
    },
    //打开Url
    openUrl: function (title, contentHtml) {
        layer.open({
            type: 1, //Page层类型
            area: ['500px', '300px'],
            title: title,
            shade: 0.6, //遮罩透明度
            maxmin: false, //允许全屏最小化
            anim: 1, //0-6的动画形式，-1不开启
            content: contentHtml
        });
    }
}

/**
 * bootstrapTable组件封装
 * @param {object} opts 参数对象
 * @param {string} opts.tableId 表格ID
 * @param {string} opts.ajaxUrl ajax请求地址
 * @param {string} opts.ajaxMethod ajax请求方法
 * @param {object} opts.queryParamsCallback 自定义ajax查询参数回调函数
 * @param {array} opts.dataColumns 需绑定的数据列
 */
window.initTable = function (opts) {
    //参数初始化
    opts = opts || {};
    opts.tableId = opts.tableId || "";
    opts.ajaxUrl = opts.ajaxUrl || "";
    opts.ajaxMethod = opts.ajaxMethod || "get";
    opts.queryParamsCallback = opts.queryParamsCallback || this.setQueryParams;
    opts.dataColumns = opts.dataColumns || this.setDataColumns;
    //实列
    this.instance = $("#" + opts.tableId);
    //初始化table组件
    this.instance.bootstrapTable({
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
            var querys = opts.queryParamsCallback();
            return $.extend({}, {
                search: params.search,
                sort: params.sort,
                order: params.order,
                offset: params.offset,  //偏移量（跳过的记录数）
                limit: params.limit,    //页记录大小
            }, querys);
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
    this.getSelecteds = function () {
        return this.instance.bootstrapTable("getSelections");
    }
    /**
     * 设置table组件额外查询参数
     * @param {object} params 参数对象
     */
    this.setQueryParams = function (querys) {
        return querys;
    }
    /**
     * 设置table组件数据列
     * @param {array} dataColumns
     */
    this.setDataColumns = function (dataColumns) {
        return dataColumns;
    }
    /**
     * 刷新table组件
     * */
    this.setRefresh = function () {
        this.instance.bootstrapTable("refresh");
    }
    return this;
}