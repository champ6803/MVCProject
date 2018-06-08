/// <reference path="D:\Workspace\MVCProject\MVCProject\Views/BookType/BookType.cshtml" />
$(function () {
    getBookCategory();
    getBookType();
    getBookProduct()

    $('#add').click(function () {
        alert($('#select_product_cate').val());
    });
    $('#remove').click(function () {
        var ids = $('#table').bootstrapTable('getSelections');
        $.each(ids, function (key, val) {
            $('#table').bootstrapTable('removeByUniqueId', this.id);
        });
        delelteBookProduct(ids);
    });
});

function getBookProduct() {
    $.ajax({
        type: 'GET',
        url: base_path + 'BookProduct/GetBookProductList',
        async: false,
        success: function (data) {
            if (data) {
                initTableBootstrap();
                $('#table').bootstrapTable('load', data);
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}

function getBookCategory() {
    $.ajax({
        type: 'GET',
        url: base_path + 'BookCategory/GetBookCategoryList',
        async: false,
        success: function (data) {
            if (data) {
                populateSelect($('#select_product_cate'), data);
                initTableBootstrap();
                $('#table').bootstrapTable('load', data);
            }
            else {
                alert('fail');
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}

function getBookType() {
    var book_type = "";
    $.ajax({
        type: 'GET',
        url: base_path + 'BookType/GetBookTypeList',
        async: false,
        success: function (data) {
            if (data) {
                populateSelect($('#select_product_type'), data);
                initTableBootstrap();
                $('#table').bootstrapTable('load', data);
            } else {
                alert('fail');
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}

function addBookProduct() {
    var book_product_name = $('#book_category_name').val();
    var book_product_price = $('#book_product_price').val();
    var book_product_qty = $('#book_category_qty').val();

    if (book_product_name && book_product_price && book_product_qty) {
        $.ajax({
            type: 'POST',
            url: base_path + 'BookProduct/AddBookProduct',
            async: false,
            data: {
                'book_product_name ': book_product_name,
                'book_product_price ': book_product_price,
                'book_product_qty ': book_product_qty
            },
            success: function (data) {
                if (data) {
                    //createTable(data);
                    $('#table').bootstrapTable('load', data);
                }
                else {
                    alert('fail');
                }
            },
            error: function (data) {
                alert('error');
            }
        });
    }
}

function delelteBookProduct(del) {
    if (del.length > 0) {
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: base_path + 'BookProduct/DeleteBookProduct',
            asyn: false,
            data: JSON.stringify({ 'bookProductList': del }),
            success: function (data) {
                if (data) {
                    $('#table').bootstrapTable('load', data);
                } else {
                    alert('false');
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    }
    else {
        alert('');
    }
}

function createTable(data) {
    if (data) {
        $('#myTabletest > tbody').empty();
        $.each(data, function () {
            var tr = "<tr>";
            tr = tr + "<td>" + this.book_product_id + "</td>";
            tr = tr + "<td>" + this.book_type_id + "</td>";
            tr = tr + "<td>" + this.book_category_id + "</td>";
            tr = tr + "<td>" + this.book_product_name + "</td>";
            tr = tr + "<td>" + this.book_product_price + "</td>";
            tr = tr + "<td>" + this.book_product_qty + "</td>";
            tr = tr + "</tr>";
            $('#myTabletest > tbody:last').append(tr);
        });
    }
}

function initTableBootstrap() {
    $('#table').bootstrapTable({
        uniqueId: 'id',
        columns: [{
            field: 'state',
            checkbox: true,
            align: 'center',
            valign: 'middle'
        }, {
            field: 'id',
            title: 'Book Product Id',
            uniqueId: 'id'
        }, {
            field: 'name',
            title: 'Book Product name'
        }, {
            field: 'price',
            title: 'Book Product Price'
        }, {
            field: 'qty',
            title: 'Book Product Quantity'
        }, {
            field: 'idType',
            title: 'Book Product Type'
        }, {
            field: 'idCate',
            title: 'Book Product Category'
        }]
    });
}

function populateSelect(selector, options) {
    $.each(options, function (i, p) {
        selector.append($('<option></option>').val(this.id).html(this.name));
    });
}