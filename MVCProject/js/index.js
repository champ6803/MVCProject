$(function () {
    getCustomer();
});

function getCustomer() {
    var customer = "";
    $.ajax({
        type: 'GET',
        url: base_path + 'Home/GetCustomerList',
        async: false,
        success: function (data) {
            if (data) {
                customer = data;
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