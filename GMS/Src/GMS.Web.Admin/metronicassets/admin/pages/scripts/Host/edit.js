
var Page = function () {

    var initTable3 = function () {
        var table = $('#sample_1');
        // begin: third table
        table.dataTable({
            "sAjaxSource": "/Loc/Tag/JsonForDT",
            "aoColumns": [{
                "mData": "",
                "mRender": function (data, type, full) {
                    return "<input type='checkbox' class='checkboxes' value='1'/>";
                },
            },{
                "mData": "Id",
                "sWidth": "0%",
                "sDefaultContent": ""
            }, {
                "mData": "TagName",
                "sWidth": "20%",//定义列宽度，以百分比表示  
                "sDefaultContent": "",
            }, {
                "mData": "WriteTime",
                "sTitle": "消息内容",
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

            var tableWrapper = jQuery('#sample_1_wrapper');

            table.find('.group-checkable').change(function () {
                //对生产的列表dom进行处理
               
                var set = jQuery(this).attr("data-set");
                var checked = jQuery(this).is(":checked");
                jQuery(set).each(function () {
                    if (checked) {
                        $(this).attr("checked", true);
                    } else {
                        $(this).attr("checked", false);
                    }
                });
                jQuery.uniform.update(set);
            });

            tableWrapper.find('.dataTables_length select').select2(); // initialize select2 dropdown
    }
    
    var initEvent = function () {
        function initTagShow(idList, nameList) {
            var str = "";
            for (var i = 0; i < idList.length; i++) {
                str += "<tr><td style='visibility:hidden'>" + idList[i] + "</td><td>" + nameList[i] + "</td></tr>"
                };
            $("#show_tag_table").empty().append(str);
            $("input[name='TagId']").val(idList[0]);
        };
        var addIdList = new Array();
        var addNameList = new Array();
        $("#sure_choose_tag_btn").on("click", function () {
            initTagShow(addIdList, addNameList);
            $("#TagBind_Modal").modal("hide");
        });
        function removeModel(id, name) {
            addIdList.pop(id);
            addNameList.pop(name);
            $("#tags").removeTag(name);
        }
        function addModel(id, name) {
            if ($.inArray(id, addIdList) == -1) {
                addIdList.push(id);
                addNameList.push(name);
                $("#tags").addTag(name);
            }
        }
        //搜索查询
        $("#searchBtn").on("click", function () {
            oTable.ajax.reload();
        });
        //标签编辑已选栏初始化
        $('#tags').tagsInput({
            width: 'auto',
            onRemoveTag: function (name) {
                var i = addNameList.indexOf(name);
                var id = addIdList[i];
                removeModel(id, name);
            },
            interactive: false
        });
        //标签编辑添加选择
        $("#choose_tag_btn").on("click", function () {
            var eb = {};
            $("#sample_1 input.checkboxes").each(function (index, item) {
                eb = {};
                if ($(this).attr("checked")) {
                    
                    //获得id
                    var $td = $(this).parents("td");
                    var id=$td.next().html();

                    //获得名称
                   var name = $td.next().next().html();
                    addModel(id, name);
                }
            });
        })


    }
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
