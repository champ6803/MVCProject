$(function () {
    var customerList = getCustomer();
});

function getCustomer() {
    var customer = "";
    $.ajax({
        type: 'GET',
        url: base_path + 'home/getCustomerList',
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
    return customer;
}

function createTable(data) {
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