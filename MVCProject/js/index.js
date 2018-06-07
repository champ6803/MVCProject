$(function () {
    getCustomer();
    create_bootstrap_table();
});

function getCustomer() {
    $.ajax({
        type: 'GET',
        url: base_path + 'Home/GetCustomerList',
        async: false,
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

function createTable(data) {
    if (data) {
        $('#myTable > tbody').empty();
        $.each(data, function () {
            var tr = "<tr>";
            tr = tr + "<td>" + this.cus_id + "</td>";
            tr = tr + "<td>" + this.cus_name + "</td>";
            tr = tr + "<td>" + this.cus_age + "</td>";
            tr = tr + "<td>" + this.cus_address + "</td>";
            tr = tr + "</tr>";
            $('#myTable > tbody:last').append(tr);
        });
    }
}

function addCustomer() {
    var cus_name = $('#cus_name').val();
    var cus_age = $('#cus_age').val();
    var cus_address = $('#cus_address').val();

    if (cus_name && cus_age && cus_address) {
        $.ajax({
            type: 'POST',
            url: base_path + 'Home/AddCustomer',
            async: false,
            data: {
                'cus_name': cus_name,
                'cus_age': cus_age,
                'cus_address': cus_address
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

function create_bootstrap_table()
{
    $(function () {
        $('#table').bootstrapTable({
            columns: [{
                field: 'state',
                checkbox: true,
                align: 'center',
                valign: 'middle'
            }, {
                field: 'id',
                title: 'Item ID'
            }, {
                field: 'name',
                title: 'Item Name'
            }, {
                field: 'price',
                title: 'Item Price'
            }],
            data: [{
                id: 1,
                name: 'Item 1',
                price: '$1'
            }, {
                id: 2,
                name: 'Item 2',
                price: '$2'
            }]
        });


    });

    $('#table').on('click.bs.table', function (row, $element, field) {
        alert('Hi');
    });

}