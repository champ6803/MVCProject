$(function () {
    getBookCategory();
    getBookType();

    $('#add').click(function () {
        alert($('#select_product_cate').val());
    });
});

function getBookCategory() {
    $.ajax({
        type: 'GET',
        url: base_path + 'BookCategory/GetBookCategoryList',
        async: false,
        success: function (data) {
            if (data) {
                populateSelect($('#select_product_cate'), data);
            }
            else {
                alert('fail');
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}

function getBookType() {
    var book_type = "";
    $.ajax({
        type: 'GET',
        url: base_path + 'BookType/GetBookTypeList',
        async: false,
        success: function (data) {
            if (data) {
                populateSelect($('#select_product_type'), data);
            } else {
                alert('fail');
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}

function populateSelect(selector, options) {
    $.each(options, function (i, p) {
        selector.append($('<option></option>').val(this.id).html(this.name));
    });
}