$(function () {
    initTableBootstrapCate();
    initTableBootstrapType();
    getBookCate();
    getBookType();
    $('#removeCate').click(function () {
        var idSelect = $('#tableCate').bootstrapTable('getSelections');
        $.each(idSelect, function (key, val) {
            $('#tableCate').bootstrapTable('removeByUniqueId', this.book_category_id);
        });
        deleteBookCate(idSelect);
    })

    $('#removeType').click(function () {
        var idSelect = $('#tableType').bootstrapTable('getSelections');
        $.each(idSelect, function (key, val) {
            $('#tableType').bootstrapTable('removeByUniqueId', this.book_type_id);
        });
        deleteBookType(idSelect);
    })

    $('#tableCate').on('click-row.bs.table'), function (row, $element, field) {
        $('#modalCate').modal('show');
    }

    $('#tableCate').on('click-row.bs.table', function (row, $element, field) {
        elCate = $element;

        //$('.modal-title').html('<span style="font-size:24px;color:#0A8DAB">Book_Category_id: ' + elCate.book_category_id + '</span>');
        $('#nameCate').val(elCate.book_category_name);
        $('#modalCate').modal('show');
    });

    $('#tableType').on('click-row.bs.table', function (row, $element, field) {
        elType = $element;

       // $('.modal-title').html('<span style="font-size:24px;color:#0A8DAB">Book_Type_id: ' + elType.book_type_id + '</span>');
        $('#nameType').val(elType.book_type_name);
        $('#modalType').modal('show');
    });
});

function updateBookCate() {
    $('#modalCate').modal('hide');
    if (elCate){
        var book_category_id = elCate.book_category_id;
        var book_category_name = $('#nameCate').val();

        if (book_category_id && book_category_name) {
            $.ajax({
                type: 'POST',
                url: base_path + 'BookCateType/UpdateBookCate',
                async: false,
                data: {
                    'book_category_id': book_category_id,
                    'book_category_name': book_category_name
                },
                success: function (data) {
                    if (data) {
                        $('#tableCate').bootstrapTable('load', data);
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
}

function updateType() {
    $('#modalType').modal('hide');
    if (elType) {
        var book_type_id = elType.book_type_id;
        var book_type_name = $('#nameType').val();

        if (book_type_id && book_type_name) {
            $.ajax({
                type: 'POST',
                url: base_path + 'BookCateType/UpdateBookType',
                async: false,
                data: {
                    'book_type_id': book_type_id,
                    'book_type_name': book_type_name
                },
                success: function (data) {
                    if (data) {
                        $('#tableType').bootstrapTable('load', data);
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
}

function getBookCate() {
    $.ajax({
        type: 'GET',
        url: base_path + 'BookCateType/GetBookCateType',
        async: false,
        success: function (data) {
            if (data) {
                $('#tableCate').bootstrapTable('load', data.bookCateList);
            }
        },
        error: function (data) {
            alert("error");
        }
    });
}

function getBookType() {
    $.ajax({
        type: 'GET',
        url: base_path + 'BookCateType/GetBookCateType',
        async: false,
        success: function (data) {
            if (data) {
                $('#tableType').bootstrapTable('load', data.bookTypeList);
            }
        },
        error: function (data) {
            alert("error");
        }
    });
}

function addBookCate() {
    var book_category_name = $('#book_category_name').val();
    $('#book_category_name').val('');
    if (book_category_name) {
        $.ajax({
            type: 'POST',
            url: base_path + 'BookCateType/AddBookCate',
            async: false,
            data: {
                'book_category_name' : book_category_name
            },
            success: function (data) {
                if (data) {
                    $('#tableCate').bootstrapTable('load', data);
                }
                else {
                    alert('fail');
                }
            },
            error: function (data){
                alert('error');
            }
        });
    }
}

function addBookType() {
    var book_type_name = $('#book_type_name').val();
    $('#book_type_name').val('');
    $.ajax({
        type: 'POST',
        url: base_path + 'BookCateType/AddBookType',
        async: false,
        data: {
            'book_type_name': book_type_name
        },
        success: function (data) {
            if (data) {
                $('#tableType').bootstrapTable('load', data);
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

function deleteBookCate(del)
{
    if (del.length > 0) {
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: base_path + 'BookCateType/DeleteBookCate',
            async: false,
            data: JSON.stringify({'bookCateList' : del}),
            success: function (data) {
                $('#tableCate').bootstrapTable('load', data);
            },
            error: function (data) {
                alert('error');
            }
        });
    }
}

function deleteBookType(del) {
    if (del.length > 0) 
    {
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: base_path + 'BookCateType/DeleteBookType',
            async: false,
            data: JSON.stringify({'bookTypeList': del}),
            success: function (data) {
                if (data) {
                    $('tableType').bootstrapTable('load', data);
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

function initTableBootstrapCate() {
    $('#tableCate').bootstrapTable({
        uniqueId: 'book_category_id',
        columns: [{
            field: 'state',
            checkbox: true,
            algin: 'center',
            valign: 'middle'
        }, {
            field: 'book_category_id',
            title: 'book_category_id'
        }, {
            field: 'book_category_name',
            title: 'book_category_name'
        }]
    })
}
function initTableBootstrapType() {
    $('#tableType').bootstrapTable({
        uniqueId: 'book_type_id',
        columns: [{
            field: 'state',
            checkbox: true,
            algin: 'center',
            valign: 'middle'
        }, {
            field: 'book_type_id',
            title: 'book_type_id'
        }, {
            field: 'book_type_name',
            title: 'book_type_name'
        }]
    })
}