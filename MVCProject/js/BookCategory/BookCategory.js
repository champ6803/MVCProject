$(function () {
    getBookCategory();   

    $('#remove').click(function () {
        var ids = $('#table').bootstrapTable('getSelections'); 
        $.each(ids, function (key, val) { 
            $('#table').bootstrapTable('removeByUniqueId', this.id);  
        });
        delelteBookCategory(ids);
    });
});

function getBookCategory()
{
    $.ajax({
        type: 'GET',
        url: base_path + 'BookCategory/GetBookCategoryList',
        async: false,  
        success: function (data)
        {
            if (data) {
                //book_category = data;
                //createTable(data);
                initTableBootstrap();
                $('#table').bootstrapTable('load', data);
            } 
        },
        error: function (data)
        {
            alert('error');
        }
    });
}

function createTable(data)
{
    if (data) {
        $('#myTableCategory > tbody').empty();
        $.each(data, function ()
        {
            var tr = "<tr>";

            tr = tr + "<td>" + this.book_category_id + "</td>";
            tr = tr + "<td>" + this.book_category_name + "</td>";
            ty = tr + "</tr>";
            $('#myTableCategory > tbody:last').append(tr);
        });
        
        
    }
}

function addBookCategory()
{
    var book_category_name = $('#book_category_name').val();

    if (book_category_name)
    {
        $.ajax({
            type: 'POST',
            url: base_path + 'BookCategory/AddBookCategory',
            async: false,
            data: {
                'book_category_name': book_category_name
            },
            success: function (data)
            {
                if (data) {
                    //createTable(data);
                    $('#table').bootstrapTable('load', data);
                }
            },
            error: function(data)
            {
                alert('error');
            }
        });
    }
}

function delelteBookCategory(del)
{
    if (del.length > 0) {
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: base_path + 'BookCategory/DeleteBookCategory',
            asyn: false,
            data: JSON.stringify({ 'bookCategoryList': del }),
            success: function (data) {
                if (data) {
                    $('#table').bootstrapTable('load', data);
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
        uniqueId: 'id',
        columns: [{
            field: 'state',
            checkbox: true,
            align: 'center',
            valign: 'middle'
        }, {
            field: 'id',
            title: 'id'
        }, {
            field: 'name',
            title: 'name'
        }]
    });
}