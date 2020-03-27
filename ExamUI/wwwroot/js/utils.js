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

//modal组件封装
var modalUtils = {
    /**********************************************************
     * 显示模态框
     * @param {object} opts 参数对象
     * @param {string} opts.remote：远程url
     * @param {string} opts.title：模态框标题
     * @param {function} opts.onOpenedEvent：窗口完成显示后触发事件
     * @param {function} opts.onClosedEvent：窗口关闭后回调事件
     * @param {function} opts.onSaveEvent：保存按钮回调事件
     **********************************************************/
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

    /**********************************************************
     * 警告模态框
     * @param {any} opts
     * @param {string} opts.title  标题文本
     * @param {string} opts.message  消息文本
     * @param {function} opts.onSureEvent    确定按钮事件的回调函数
     **********************************************************/
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
};

//form封装
var formUtils = {
    /*************************************
     * 清空表单
     * @param {object} frm 表单对象
     ************************************/
    clear: function (frm) {
        $(":input", frm)
            .not(":button", ":submit", ":reset", ":option").val('')
            .removeAttr("checked");
        frm.find("option: first-child").attr("selected", true);
        $(frm)[0].reset();
    },

    /****************************************************
     * 表单回显
     * @param {object} frm 表单对象
     * @param {JSON} json JSON对象
     * toLowerCase() ------ 将字符串中的所有字符都转换成小写；
     * toUpperCase() ------ 将字符串中的所有字符都转换成大写；
     ****************************************************/
    echo: function (frm, strJson) {
        if (frm == null || frm == 'undefined' || strJson == null || strJson == 'undefined') {
            layerUtils.info("表单对象或数据对象为空", 2);
            return;
        }
        for (var key in strJson) {
            if (key == "0" || strJson[key] == null)
                continue;
            var propName = key == "id" ?    //重新拼凑json属性名(parnetID=ParentID)
                key.toUpperCase() : key.substr(0, 1).toUpperCase() + key.substr(1, key.lenght);
            var dmEle = frm.find("*[name=" + propName + "]");

            if (dmEle == "undefined" || dmEle == null)
                continue;
            else if (dmEle.is("select") && $.type(strJson[key]) == "string")  //判断下拉列表框
                dmEle.find("option:contains(" + strJson[key] + ")").attr("selected", true);
            else if (dmEle.prop("type") == "checkbox" && strJson[key] == "启用")   //判断复选框
                dmEle.attr("checked", "checked");
            else
                dmEle.val(strJson[key]);
        }
    }
};

//layer组件封装
var layerUtils = {
    //弹窗
    alert: function (msg) {
        layer.alert(msg, { icon: 1, closeButton: 0 }, function (index) {
            layer.close(index);
        });
    },
    //消息框
    info: function (msg, iconId) { layer.msg(msg, { icon: iconId }); },
    //提示
    tips: function (msg, elementId) { layer.tips(msg, elementId); },
    //询问
    confirm: function (msg, callback) {
        layer.confirm(msg, { icon: 3, title: '警告' }, function (index) {
            callback();
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
};

//表组件
window.tableView = {
    /****************************************************************
    * bootstrapTable表组件封装
    * @param {object} opts 参数对象
    * @param {string} opts.tableId 表格ID
    * @param {string} opts.toolbarId 工具条ID，默认"tab_toolbar"
    * @param {bool} opts.showDetail 显示详细视图，默认false
    * @param {bool} opts.paging 开启分页，默认true
    * @param {string} opts.paginator 分页器，默认"server"
    * @param {string} opts.ajaxUrl ajax请求地址
    * @param {string} opts.ajaxMethod ajax请求方法，默认"get"
    * @param {object} opts.queryParamsCallback 自定义ajax查询参数回调函数
    * @param {array} opts.dataColumns 需绑定的数据列
    * @param {function} opts.onExpandRowCallback 行展开事件回调函数
    *****************************************************************/
    manageTable: function (opts) {
        //参数初始化
        opts = opts || {};
        opts.tableId = opts.tableId || "";
        opts.toolbarId = opts.toolbarId || "tab_toolbar"; 
        opts.showDetail = opts.showDetail || false;
        opts.paging = opts.paging || true;
        opts.paginator = opts.paginator || "server";
        opts.ajaxUrl = opts.ajaxUrl || "";
        opts.ajaxMethod = opts.ajaxMethod || "get";
        opts.queryParamsCallback = opts.queryParamsCallback || Function;
        opts.dataColumns = opts.dataColumns || [];
        opts.onExpandRowCallback = opts.onExpandRowCallback || Function;
        //父表实列
        this.instance = $("#" + opts.tableId);
        //初始化table组件
        this.instance.bootstrapTable({
            //theadClasses: "thead-blue",
            classes:"table table-hover",
            theadClasses: "thead-light",
            uniqueId: "id",
            toolbar: "#" + opts.toolbarId,
            showHeader: true,
            showLoading: true,
            striped: true,
            clickToSelect: true,
            search: false,
            //searchOnEnterKey: true,
            detailView: opts.showDetail,
            showColumns: true,
            showRefresh: true,
            showToggle: true,
            cache: false,
            url: opts.ajaxUrl,
            method: opts.ajaxMethod,
            queryParams: function (params) {
                return $.extend({}, params, opts.queryParamsCallback());
            },
            paginationLoop: false,
            pagination: opts.paging,
            onlyInfoPagination: true,
            sidePagination: opts.paginator,
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
            },
            onExpandRow: function (index, row, $detail) {
                opts.onExpandRowCallback(index, row, $detail)
            }
        });
        //获取table组件已选择行
        this.getSelecteds = function () {
            return this.instance.bootstrapTable("getSelections");
        };
        //刷新table组件
        this.setRefresh = function () {
            this.instance.bootstrapTable("refresh");
        };
        return this;
    },

    /******************************************************************
     * bootstrapTable子表组件封装
     * @param {object} parms 参数对象
     * @param {json} parms.rowCode 主表行数据
     * @param {object} parms.detail 主表行装载详细视图的容器对象
     * @param {bool} parms.showDetail 显示详细视图，默认false
     * @param {string} parms.ajaxUrl ajax请求地址
     * @param {string} parms.ajaxMethod ajax请求类型
     * @param {function} parms.queryParamsCallback ajax请求参数回调方法
     * @param {function} parms.onExpandRowCallback 行展开回调方法
     * @param {array} parms.dataColumns 数据列数组
     ******************************************************************/
    detailTable: function (parms) {
        //参数初始化
        parms = parms || {};
        parms.data = parms.data || {};
        parms.rowCode = parms.rowCode || null;
        parms.detail = parms.detail || null;
        parms.showDetail = parms.showDetail || false;
        parms.ajaxUrl = parms.ajaxUrl || "";
        parms.ajaxMethod = parms.ajaxMethod || "get";
        parms.queryParamsCallback = parms.queryParamsCallback || Function;
        parms.dataColumns = parms.dataColumns || [];
        parms.onExpandRowCallback = parms.onExpandRowCallback || Function;
        //实例
        this.instance = parms.detail.html("<table></table>").find("table");
        //初始化
        this.instance.bootstrapTable({
            classes: "table table-bordered table-striped table-borderless table-sm",
            uniqueId: "id",
            showHeader: false,
            showLoading: true,
            clickToSelect: true,
            data: parms.data,
            detailView: parms.showDetail,
            cache: false,
            url: parms.ajaxUrl,
            method: parms.ajaxMethod,
            queryParams: function (params) {
                return $.extend({}, params, parms.queryParamsCallback());
            },
            columns: parms.dataColumns,
            responseHandler: function (data) {
                console.log(data);
                return data;
            },
            onLoadSuccess: function () {
                console.log("行table组件数据已加载");
            },
            onExpandRow: function (index, row, $detail) {
                parms.onExpandRowCallback(index, row, $detail)
            }
        });
        //获取已选中的checkbox集合 
        this.getSelecteds = function () {
            return this.instance.find("input[type='checkbox']: checked");
        };
        //刷新从表
        this.setRefresh = function () {
            this.instance.bootstrapTable("refresh");
        };
        return this;
    }
}