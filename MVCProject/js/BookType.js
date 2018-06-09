$(function () {
    getBookType();

    $('#remove').click(function () {
        var ids = $('#bootstrapTable').bootstrapTable('getSelections'); // method of bootstrap-table
        $.each(ids, function (key, val) { // loop remove
            $('#bootstrapTable').bootstrapTable('removeByUniqueId', this.id);  //ตรงนี้ลบแค่หน้าจอ
        });
        deleteBookType(ids); //ตรงนี้ลบใน db 
    });
});

function getBookType() {
    var book_type = "";
    $.ajax({
        type: 'GET',
        url: base_path + 'BookType/GetBookTypeList',
        async: false,
        success: function (data) {
            if (data) {
                book_type = data;
                createTable(data);

                creatTableBootstrap();
                $('#bootstrapTable').bootstrapTable('load', data);
            } else {
                alert('fail');
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}

function createTable(data) {
    if (data) {
        $('#myBookTypeTable > tbody').empty();
        $.each(data, function () {
            var tr = "<tr>";
            tr = tr + "<td>" + this.book_type_id + "</td>";
            tr = tr + "<td>" + this.book_type_name + "</td>";           
            tr = tr + "</tr>";
            $('#myBookTypeTable > tbody:last').append(tr);
        });
    }
}

function addBookType() {
    var book_type_name = $('#book_type_name ').val();
    if (book_type_name) {
        $.ajax({
            type: 'POST',
            url: base_path + 'BookType/AddBookType',
            async: false,
            data: {
                'book_type_name': book_type_name
            },
            success: function (data) {
                if (data) {
                    createTable(data);
                    creatTableBootstrap()
                    $('#bootstrapTable').bootstrapTable('load', data); //โหลดข้อมูลเข้า
                } else {
                    alert('fail');
                }
            },
            error: function (data) {
                alert('error');
            }
        });
    }
}

function deleteBookType(del) {
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json', 
        type: 'POST',
        url: base_path + 'BookType/DeleteBookType',
        async: false,
        data: JSON.stringify({ 'book_typeList': del }),
        success: function (data) {
            if (data) {
                $('#bootstrapTable').bootstrapTable('load', data);
            } else {
                alert('fail');
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}

function creatTableBootstrap() {
    $('#bootstrapTable').bootstrapTable({
        uniqueId: 'id',
        columns: [{
            field: 'state',
            checkbox: true,
            align: 'center',
            valign: 'middle'
        }, {
            field: 'id',
            title: 'Book Type ID',
            uniqueId: 'book_type_id'
        }, {
            field: 'name',
            title: 'Book Type Name'
        }]
    });
}