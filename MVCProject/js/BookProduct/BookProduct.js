/// <reference path="D:\Workspace\MVCProject\MVCProject\Views/BookType/BookType.cshtml" />
$(function () {
    initTableBootstrap();
    getBookCategory();
    getBookType();
    getBookProduct()

    $('#add').click(function () {
      
    });
    $('#remove').click(function () {
        var ids = $('#table').bootstrapTable('getSelections');
        $.each(ids, function (key, val) {
            $('#table').bootstrapTable('removeByUniqueId', this.book_product_id);
        });
        delelteBookProduct(ids);
    });
  
    $('#table').on('click-row.bs.table', function (row, $element, field) {
       el = $element;
        //$('.modal-title').html('<span style="font-size:24px;color:#0A8DAB">Book_product_id: ' + el.book_product_id + '</span>');
       $('#name').val(el.book_product_name);
       $('#price').val(el.book_product_price);
       $('#editBookProduct').modal('show');
        
    });    
});


function updateBookProduct() {
    $('#editBookProduct').modal('hide');
    if (el) {
        var book_product_id = el.book_product_id;
        var book_product_name = $('#name').val();
        var book_product_price = $('#price').val();
        var book_product_qty = el.book_product_qty;
        var book_type_id = el.book_type_id;
        var book_category_id = el.book_category_id;
        $("name").val(book_product_name);
        //alert(id + " " + name + " " + price);
        if (book_product_id && book_product_name && book_product_price && book_product_qty && book_type_id && book_category_id) {
            $.ajax({
                type: 'POST',
                url: base_path + 'BookProduct/UpdateBookProduct',
                async: false,         
                data: {
                    'book_product_id': book_product_id,
                    'book_product_name': book_product_name,
                    'book_product_price': book_product_price,
                    'book_product_qty': book_product_qty,
                    'book_type_id': book_type_id,
                    'book_category_id': book_category_id
                },
                success: function (data) {
                    if (data) {
                        alert('success');
                        $('#table').bootstrapTable('load', data);
                    }
                },
                error: function (data) {
                    alert('error');
                }
            });
        }
    }
}
function getBookProduct() {
    $.ajax({
        type: 'GET',
        url: base_path + 'BookProduct/GetBookProductList',
        async: false,
        success: function (data) {
            if (data) {
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
                    alert('fail');
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
        }, {
            field: 'book_product_name',
            title: 'Book Product name',
            editable: true
        }, {
            field: 'book_product_price',
            title: 'Book Product Price',
            editable: false
        }, {
            field: 'book_product_qty',
            title: 'Book Product Quantity'
        }, {
            field: 'book_type_name',
            title: 'Book Product Type'
        }, {
            field: 'book_category_name',
            title: 'Book Product Category'
        }]
    });
}

function populateSelect(selector, options) {
    $.each(options, function (i, p) {
        selector.append($('<option></option>').val(this.id).html(this.name));
    });
}