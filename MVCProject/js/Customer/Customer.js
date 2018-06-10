$(function () {
    getCustomer();

    $('#remove').click(function () {
        var ids = $('#table').bootstrapTable('getSelections'); // method of bootstrap-table
        $.each(ids, function (key, val) { // loop remove
            $('#table').bootstrapTable('removeByUniqueId', this.cus_id);  //ตรงนี้ลบแค่หน้าจอ
        });
        deleteCustomer(ids); //ตรงนี้ลบใน db 
    });
});

function deleteCus() {
    alert('test');
}

function getCustomer() {
    $.ajax({
        type: 'GET',
        url: base_path + 'Customer/GetCustomerList',
        async: false,
        success: function (data) {
            if (data) {
                //createTable(data);
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
            url: base_path + 'Customer/AddCustomer',
            async: false,
            data: {
                'cus_name': cus_name,
                'cus_age': cus_age,
                'cus_address': cus_address
            },
            success: function (data) {  //callback 
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
        url: base_path + 'Customer/DeleteCustomer',
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

function initTableBootstrap() {
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
}