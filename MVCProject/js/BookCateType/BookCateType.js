$(function () {
    getBookCateType();
});

function getBookCateType()
{
    alert('TEst');
    $.ajax({
        type: 'GET',
        url: base_path + 'BookCateType/GetBookCateType',
        async: false,
        success: function (data) {
            if (data) {
                var x = data;
            }
        },
        error: function (data) {
            alert('error');
        }
    });
}