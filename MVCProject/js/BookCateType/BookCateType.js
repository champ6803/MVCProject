$(function () {
<<<<<<< HEAD
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
=======
    getBookCateType();
>>>>>>> 8aaa0caf804e670995129b8f1e2c5b4e2c9aad62
});

function getBookCateType()
{
    alert('TEst');
    $.ajax({
        type: 'GET',
        url: base_path + 'BookCateType/GetBookCateType',
        async: false,
        success: function (data) {
            if (data) {
                var x = data;
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}