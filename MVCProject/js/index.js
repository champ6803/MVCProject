$(function () {
   var data = getCustomer();
    $('#table').bootstrapTable({
        uniqueId: 'cus_id',
        columns: [{
            field: 'state',
            checkbox: true,
            align: 'center',
            valign: 'middle'
        }, {
            field: 'cus_id',
            title: 'Customer ID',
            uniqueId: 'cus_id'
        }, {
            field: 'cus_name',
            title: 'Customer Name'
        }, {
            field: 'cus_age',
            title: 'Customer Age'
        }, {
            field: 'cus_address',
            title: 'Customer Address'
        }]
    });
    $('#table').bootstrapTable('load', data);


    $('#remove').click(function () {
        var ids = $('#table').bootstrapTable('getSelections');
        $.each(ids, function (key, val) {
            $('#table').bootstrapTable('removeByUniqueId', this.cus_id);
        });
        deleteCustomer(ids);
    });
});

function getCustomer() {
    var cus_data = "";
    $.ajax({
        type: 'GET',
        url: base_path + 'Home/GetCustomerList',
        async: false,
        success: function (data) {
            if (data) {
                //createTable(data);
                cus_data = data;

            } else {
                alert('fail');
            }
        },
        error: function (data) {
            alert('error');
        }
    });
    return cus_data;
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
                    //createTable(data);
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
}

function deleteCustomer(del) {
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: base_path + 'Home/DeleteCustomer',
        async: false,
        data: JSON.stringify({ 'cusList': del }),
        success: function (data) {
            if (data) {
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