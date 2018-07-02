/// <reference path="D:\Workspace\MVCProject\MVCProject\Views/BookType/BookType.cshtml" />
$(function () {

    initTableBootstrap();
    getBookProduct();
    $("#saveOrder").hide();
    /*
    $('#table').on('click-row.bs.table', function (row, $element, field) {
        $('#productQty').modal('show');
        //getQuantity($element);
        el = $element;
    });

    $('#productQty').on('hidden.bs.modal', function () {
        $(this)
        .find("input,textarea,select")
        .val('')
        .end();
    })
    */
    $('#buy').click(function () {
        initTableBootstrapOrder();
        $("#saveOrder").show();
        ids = $('#table').bootstrapTable('getSelections');
        var order = [];
        $.each(ids, function () {
            var obj = {
                book_product_id: this.book_product_id,
                book_product_name: this.book_product_name,
                book_product_price: this.book_product_price,
                book_product_qty: this.book_product_qty,
                book_type_name: this.book_type_name,
                book_category_name: this.book_category_name,
                book_order: 1,
                book_amount: this.book_product_price
            }
            order.push(obj); //same Add
        });
        $('#tableOrder').bootstrapTable('load', order);
    })

    $('#tableOrder').on('click-row.bs.table', function (row, $element, field) {
        $('#modalQty').modal('show');
        el = $element;
        $('.modal-title').html('<span style="font-size:20px;">book_product_name:  ' + el.book_product_name + '</span>');
    });

    
    
    
});


function checkQty() {
    $('#modalQty').modal('hide');
    $('#save').show();
    if (el) {
        var qty = $('#qtyOrder').val();
        var getQty = el.book_product_qty;
        var Total=0;
        if (qty) {
            if (parseInt(qty) > parseInt(getQty)) {
                alert('please input agin !');
            }
            if (qty <= getQty && qty != 0) {
                book_product_qty = getQty - qty;
                if (book_product_qty >= 0) {
                    //alert('buy ' + '\n qty in stock: ' + book_product_qty);
                    var book_amount = calculateAmount(parseInt(qty));
                    var orderList = $('#tableOrder').bootstrapTable('getData');
                    $.each(orderList, function () {
                        if (this.book_product_id == el.book_product_id) {
                            this.book_order = qty;
                            this.book_amount = book_amount;
                        }
                        Total += parseFloat(this.book_amount);
                        $('#totol_txt').show();
                        $('#total').html(Total);
                    });
                    $('#tableOrder').bootstrapTable('load', orderList);
                }
                else {
                    alert("สินค้ามีจำนวนไม่เพียงพอ");
                }
            }
        }  
    }
    T = Total;
}


function AddOrder() {
    var Total = T;
    var today = new Date();
    var order = {
        'cus_id': 3,
        'book_status_code': 'WP',
        'book_order_total': Total,
        'book_order_date': today
    }

    var orderList = $('#tableOrder').bootstrapTable('getData');
    var detail = [];
    $.each(orderList, function () {
        var o = {
            'book_product_id': this.book_product_id,
            'book_order_detail_qty': this.book_order,
            'book_order_detail_price': (this.book_product_price * this.book_order)
        }
        detail.push(o);
    });

    var source = {
        'bookOrder': order,
        'bookDetail': detail
    }

    $.ajax({
        contentType: 'application/json',
        dataType: 'json',
        type: 'POST',
        url: 'BookOrder/AddBookOrder',
        asyn: false,
        data: JSON.stringify(source),
        success: function (data) {
            if (data) {
                alert("ทำรายการเรียบร้อยแล้ว");
            }
            else {
                alert('fail');
            }
        },
        error: function (data) {
            alert("error");
        }
    });

    //updateStockProduct(detail, book_product_qty);
}

function calculateAmount(qty) {
    var price = el.book_product_price;
    var calAmount = parseFloat(price) * parseInt(qty);
    return calAmount;
    //alert(parseFloat(price) + " * " + parseInt(qty) + " = " + calAmount);
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
            field: 'book_type_name',
            title: 'Book Product Type'
        }, {
            field: 'book_category_name',
            title: 'Book Product Category'
        }]
    });
}

function initTableBootstrapOrder() {
    $('#tableOrder').bootstrapTable({
        uniqueId: 'book_product_id',
        columns: [{
            field: 'state',
            checkbox: true,
            align: 'center',
            valign: 'middle'
        }, {
            field: 'book_product_id',
            title: 'Book Product Id'
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
            field: 'book_type_name',
            title: 'Book Type'
        }, {
            field: 'book_category_name',
            title: 'Book Category'
        }, {
            field: 'book_order',
            title: 'Book order'
        }, {
            field: 'book_amount',
            title: 'Book amount'
        }]
    });
}

function populateSelect(selector, options) {
    $.each(options, function (i, p) {
        selector.append($('<option></option>').val(this.id).html(this.name));
    });
}