$(function () {
    getBookType();
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