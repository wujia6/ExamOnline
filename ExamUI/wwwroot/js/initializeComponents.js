/**
 * 自定义 bootstrapTable 对象
 * @param {any} tableId
 * @param {any} dataUrl
 */
function initTable(table, dataUrl) {
    /**
     * 回调函数（设置自定义参数）
     * */
    this.setQueryParams = Function;
    /**
     * 回调函数（设置数据列）
     * */
    this.setDataColumns = Function;
    /**
     * 获取选中行
     * */
    this.getSelected = function () {
        var selectRows = this.instance.bootstrapTable("getSelections");
        if (selectRows.length == 0) {
            bt_dialog.error("请选择有效的数据行");
            return;
        }
        return selectRows;
    };
    /**
     * 刷新远程服务器数据
     * 您可以设置{silent：true}静默刷新数据，并设置{url：newUrl}来更改网址。
     * 要提供特定于此请求的查询参数，请设置{query：{foo：'bar'}}
     * @param {any} params 参数
     */
    this.refresh = function (params) {
        typeof params != 'undefined' ?
            this.instance.bootstrapTable('refresh') : this.instance.bootstrapTable('refresh', params);
    }
    /**
     * 组件实例对象
     * */
    this.instance = function () {
        return table.bootstrapTable({
            uniqueId: "ID",
            showHeader: true,
            showLoading: true,
            striped: true,
            toolbar: "#" + table.attr("id") + "_toolbar",  //工具栏(*)
            clickToSelect: true,
            //search: false,
            //searchOnEnterKey: true,
            showColumns: true,
            showRefresh: true,
            showToggle: true,
            cache: false, //缓存(*)
            url: dataUrl,  //数据请求地址(*)
            method: "get",    //请求方式(*)
            queryParams: this.setQueryParams,
            paginationLoop: false,  //是否无限循环
            pagination: true,       //启用分页（*）
            sidePagination: "server",   //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,              //当前页码初始化加载第一页，默认第一页
            pageSize: 10,               //每页的记录行数（*）
            pageList: [10, 25, 50],    //可供选择的每页的行数（*）
            columns: this.setQueryParams,
            icons: {
                refresh: 'glyphicon-repeat',
                toggle: 'glyphicon-list-alt',
                columns: 'glyphicon-list'
            },
            iconSize: 'outline'
        });
    }
    return this;
}
//window.manageTable = bsTable;