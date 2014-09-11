﻿$(document).ready(function () {
    $("#jqgBeverage").jqGrid({
        url: '@Url.Action("GetDataBeverage")',
        datatype: "json",
        colNames: ['Id', 'Название', 'Цена'],
        colModel: [
        { name: 'Id', index: 'Id', width: 30, stype: 'text', key: true },
        { name: 'Name', index: 'Name', editrules: { edithidden: true, required: true, maxValue: 100 }, editable: true, width: 150, sortable: true },
         { name: 'Cost', index: 'Cost', editrules: { edithidden: true, required: true, number: true }, editable: true, width: 150, sortable: true, stype: 'text' }
        ],
        rowNum: 5,
        rowList: [5, 10, 15],
        width: 800,
        pager: '#jpagerBeverage',
        loadonce: true,
        sortname: 'Id',
        sortorder: "desc",
        caption: "Список кофе"
    });

    $("#jqgBeverage").jqGrid('navGrid', '#jpagerBeverage', {

        search: true,
        searchtext: "Поиск",
        refresh: false,
        add: true,
        del: true,
        edit: true,
        view: true,
        viewtext: "Смотреть",
        viewtitle: "Выбранная запись",
        addtext: "Добавить",
        edittext: "Изменить",
        deltext: "Удалить"
    },
    update("edit"),
    update("add"),
    update("del")
     );

    function update(act) {
        return {
            closeAfterAdd: true,
            height: 250,
            width: 400,
            closeAfterEdit: true,
            reloadAfterSubmit: true,
            drag: true,
            onclickSubmit: function (params) {
                var list = $("#jqgBeverage");
                var selectedRow = list.getGridParam("selrow");
                rowData = list.getRowData(selectedRow);
                if (act === "add")
                    params.url = '@Url.Action("CreateBeverage")';
                else if (act === "del")
                    params.url = '@Url.Action("DeleteBeverage")';
                else if (act === "edit")
                    params.url = '@Url.Action("EditBeverage")';
            },
            afterSubmit: function (response, postdata) {
                // обновление грида
                $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid')
                return [true, "", 0]
            }
        };
    };

    $("#jqgCondiment").jqGrid({
        url: '@Url.Action("GetDataCondiment")',
        datatype: "json",
        colNames: ['Id', 'Название', 'Цена'],
        colModel: [
        { name: 'Id', index: 'Id', width: 30, stype: 'text', key: true },
        { name: 'Name', index: 'Name', editrules: { edithidden: true, required: true, maxValue: 100 }, editable: true, width: 150, sortable: true },
         { name: 'Cost', index: 'Cost', editrules: { edithidden: true, required: true, number: true }, editable: true, width: 150, sortable: true, stype: 'text' }
        ],
        rowNum: 5,
        rowList: [5, 10, 15],
        width: 800,
        pager: '#jpagerCondiment',
        loadonce: true,
        sortname: 'Id',
        sortorder: "desc",
        caption: "Список Добавок"
    });

    $("#jqgCondiment").jqGrid('navGrid', '#jpagerCondiment', {

        search: true,
        searchtext: "Поиск",
        refresh: false,
        add: true,
        del: true,
        edit: true,
        view: true,
        viewtext: "Смотреть",
        viewtitle: "Выбранная запись",
        addtext: "Добавить",
        edittext: "Изменить",
        deltext: "Удалить"
    },
   updateCondiment("edit"),
   updateCondiment("add"),
   updateCondiment("del")
    );

    function updateCondiment(act) {
        return {
            closeAfterAdd: true,
            height: 250,
            width: 400,
            closeAfterEdit: true,
            reloadAfterSubmit: true,
            drag: true,
            onclickSubmit: function (params) {
                var list = $("#jqgCondiment");
                var selectedRow = list.getGridParam("selrow");
                rowData = list.getRowData(selectedRow);
                if (act === "add")
                    params.url = '@Url.Action("CreateCondiment")';
                else if (act === "del")
                    params.url = '@Url.Action("DeleteCondiment")';
                else if (act === "edit")
                    params.url = '@Url.Action("EditCondiment")';
            },
            afterSubmit: function (response, postdata) {
                // обновление грида
                $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid')
                return [true, "", 0]
            }
        };
    };
});