$(function () {
    getBookCategory();
    create_bootstrap_table();

    $('#del').click(function () {
        //$('#table').bootstrapTable('load', data);
        var cusSel = $('#table').bootstrapTable('getSelections');
        alert("button");
    });
});

function getBookCategory()
{
    var book_category = "";
    $.ajax({
        type: 'GET',
        url: base_path + 'BookCategory/GetBookCategoryList',
        async: false,
        success: function (data)
        {
            if (data)
            {
                book_category = data;
                createTable(data);
            }
            else
            {
                alert('fail');
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
    if (data)
    {
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
                if (data) 
                {
                    createTable(data);
                }
                else
                {
                    alert('fail');
                }
            },
            error: function(data)
            {
                alert('error');
            }
        });
    }
}

function create_bootstrap_table(data) {
    $(function () {
        $('#table').bootstrapTable({
            type: 'GET',
            url: base_path + 'BookCategory/GetBookCategoryList',
            columns: [{
                field: 'state',
                checkbox: true,
                align: 'center',
                valign: 'middle'
            }, {
                field: 'book_category_id',
                title: 'id'
            }, {
                field: 'book_category_name',
                title: 'name'
            }]
        });
    });

    $(document).ready(function() {
        
         
    });

   /* $('#table').on('click.bs.table', function (row, $element, field) {
        alert('Hi');
    });*/

}