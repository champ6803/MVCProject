/// <reference path="D:\Workspace\MVCProject\MVCProject\Views/BookType/BookType.cshtml" />
$(function () {
    getBookCategory();
    getBookType();
    getBookProduct()

    $('#table').on('click-row.bs.table', function (row, $element, field) {
        var ids = $('#table').bootstrapTable('getSelections');
        $.each(ids, function (key, val) {
            $('#productQty').modal('show');
            getQuantity(ids);
        });      
    });

    $('#productQty').on('hidden.bs.modal', function () {
        $(this)
        .find("input,textarea,select")
        .val('')
        .end();
    })
});

function getQuantity() {
    var getQty = 0;
    var result;
    var qty = $('#qty').val();
    var ids = $('#table').bootstrapTable('getSelections');
    $.each(ids, function (key, val) {        
        getQty = this.book_product_qty;
    });
    //alert("getQty: " + getQty);
    //alert("qty: " + qty);
    if (qty > getQty) {
        alert('please input agin !');
    }
    if (qty <= getQty && qty != 0) {
        book_product_qty = getQty - qty;
        $('#productQty').modal('hide');
        alert('buy ' + '\n qty in stock: ' + book_product_qty);
    }
}
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
    var book_product_name = $('#book_product_name').val();
    var book_product_price = $('#book_product_price').val();
    var book_product_qty = $('#book_product_qty').val();
    var book_type_id = $('#select_product_type').val();
    var book_category_id = $('#select_product_cate').val();

    if (book_product_name && book_product_price && book_product_qty && book_type_id && book_category_id) {
        $.ajax({
            type: 'POST',
            url: base_path + 'BookProduct/AddBookProduct',
            async: false,
            data: {
                'book_product_name': book_product_name,
                'book_product_price': book_product_price,
                'book_product_qty': book_product_qty,
                'book_type_id': book_type_id,
                'book_category_id': book_category_id
            },
            success: function (data) {
                if (data) {
                    //createTable(data);
                    $('#table').bootstrapTable('load', data);
                }
                else {
                    alert('no add');
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

function initTableBootstrap() {
    $('#table').bootstrapTable({
        uniqueId: 'book_product_id',
        columns: [{
            field: 'state',
            checkbox: true,
            align: 'center',
            valign: 'middle'
        }, {
            field: 'book_product_id',
            title: 'Book Product Id',
            uniqueId: 'id'
        }, {
            field: 'book_product_name',
            title: 'Book Product name'
        }, {
            field: 'book_product_price',
            title: 'Book Product Price'
        }, {
            field: 'book_product_qty',
            title: 'Book Product Quantity'
        }, {
            field: 'book_type_id',
            title: 'Book Product Type'
        }, {
            field: 'book_category_id',
            title: 'Book Product Category'
        }]
    });
}

function populateSelect(selector, options) {
    $.each(options, function (i, p) {
        selector.append($('<option></option>').val(this.id).html(this.name));
    });
}