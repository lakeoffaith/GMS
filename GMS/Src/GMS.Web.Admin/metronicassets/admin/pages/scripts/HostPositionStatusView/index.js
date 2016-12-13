
var Page = function () {

    var initTable3 = function () {
        var table = $('#table_ijoy');
        // begin: third table
        table.dataTable({
            "sAjaxSource": "/Loc/HostPositionStatusView/JsonForDT",
            "aoColumns": [{
                "mData": "HostId",
                "sTitle": "",
                "sDefaultContent": "",
                "bVisible": false
            }, {
                "mData": "HostGroupId",
                "sTitle": "地图位置"
            }, {
                "mData": "HostName", //列标识，和服务器返回数据中的属性名称对应  
                "sTitle": "名称",//列标题  
                "sDefaultContent": "", //此列默认值为""，以防数据中没有此值，DataTables加载数据的时候报错  
                //"sClass" : "hidden"//定义列的class参数，隐藏列也可以通过这种方式设置  
            }, {
                "mData": "HostExternalId",
                "sTitle": "编号",
                "sWidth": "10%",//定义列宽度，以百分比表示  
                "sDefaultContent": "",
            }, {
                "mData": "TagId",
                "sTitle": "绑定标签",
                "sDefaultContent": "",
            }, {
                "mData": "WriteTime",
                "sTitle": "当前位置",
                "sDefaultContent": "",
                "bSortable": false   //此列不需要排序  
            }],
            "bProcessing": false, //DataTables载入数据时，是否显示‘进度’提示  
            "bServerSide": true, //是否启动服务器端数据导入  
            //"aLengthMenu" : [10, 20, 50], //更改显示记录数选项  
            "iDisplayLength": 10, //默认显示的记录数  
            "bPaginate": true, //是否显示（应用）分页器  
            "bInfo": true, //是否显示页脚信息，DataTables插件左下角显示记录数  
            "bSort": true, //是否启动各个字段的排序功能  
            "sDom": 'rt<"row-fluid"l<"span6"p>i>',//'<"top"iflp<"clear">>rt<"bottom"ilp<"clear">>',//"t<'row-fluid'<'span6'i><'span6'p>>",//定义表格的显示方式  
            "aaSorting": [[0, "desc"]], //默认的排序方式，第0列，降序排列  
            "bFilter": true, //是否启动过滤、搜索功能  
            "oLanguage": { //国际化配置  
                "sProcessing": "正在获取数据，请稍后...",
                "sLengthMenu": "每页显示 _MENU_ 条记录   ",
                "sZeroRecords": "没有您要搜索的内容",
                "sInfo": "从 _START_ 到  _END_ 条记录 记录总数： _TOTAL_ 条",
                "sInfoEmpty": "记录数为0",
                "sInfoFiltered": "(共显示 _MAX_ 条数据)",
                "sInfoPostFix": "",
                "oPaginate": {
                    "sFirst": "第一页",
                    "sPrevious": "上一页",
                    "sNext": "下一页",
                    "sLast": "最后一页"
                }
            },
            "fnServerParams": function (aoData) {
                aoData.push({
                    "name": "HostName", "value": $("#HostName").val()},
                    {"name": "HostExternalId", "value": $("#HostExternalId").val()},
                    { "name": "tagBindingSelectedValue", "value": $("input[name='tagBindingSelectedValue']:checked").val() },
                    { "name": "tagOnlineSelectedValue", "value": $("input[name='tagOnlineSelectedValue']:checked").val() }
                        );
            },
            /* 
            * 修改状态值  
            */
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                if (aData.response_type == 'video')
                    $('td:eq(1)', nRow).html('视频回复');


                return nRow;
            },
            //服务器端，数据回调处理  
            "fnServerData": function (sSource, aDataSet, fnCallback) {
                $.ajax({
                    "dataType": 'json',
                    "type": "post",
                    "url": sSource,
                    "data": aDataSet,
                    "success": function (resp) {
                        fnCallback(resp);
                        $("input.checkboxes").uniform();
                    }
                });
            }
        });

          
    }
    
    var initEvent = function () {
        $("#searchBtn").on("click", function () {
            $('#table_ijoy').DataTable().ajax.reload();
        });
    };
    return {

        //main function to initiate the module
        init: function () {
            if (!jQuery().dataTable) {
                return;
            }

            initTable3();
            //绑定事件
            initEvent();
        }

    };

}();
