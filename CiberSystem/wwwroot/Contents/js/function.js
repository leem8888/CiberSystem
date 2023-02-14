var urlPathApi = "https://localhost:44341/";
$(document).ready(function () {
    var now = new Date();
    var month = (now.getMonth() + 1);
    var day = now.getDate();
    if (month < 10)
        month = "0" + month;
    if (day < 10)
        day = "0" + day;
    var today = now.getFullYear() + '-' + month + '-' + day;
    $('#orderDate').val(today);




});
$(document).on("click", "#createOrder", function () {
    var nameOrder = $("#nameOrder").val();
  
    var idProduct = $("#SelectedProduct :selected").attr('data-id');
    var nameProduct = $("#SelectedProduct :selected").text();
    if (nameOrder == '') {
        alert("Vui lòng nhập tên đơn hàng");
        return false;
    }
    var orderDate = $('#orderDate').val();
    var amountOrder = $("#amountOrder").val();
    if (amountOrder == '') {
        alert("Vui lòng nhập số lượng");
        return false;
    }

    $.post(urlPathApi + "Order/AddOrder", { nameOrder: nameOrder, idProduct: idProduct, nameProduct: nameProduct, orderDate: orderDate, amountOrder: amountOrder }, function (data) {
        if (data.error == false) {
            if (data.success == true) {
                alert("Đặt hàng thành công");
                location.reload();
            }
            else {
                alert("Đặt số lượng sản phẩm vượt mức tồn kho");
            }
        } else {
            alert("Có lỗi xảy ra, vui lòng thử lại sau");
        }
    });
});

$(document).on("click", "#logOut", function () {
    localStorage.removeItem('_CiberUserLogin');
    delete_cookie('_CiberUserLogin');
   
   location.reload();
});

function delete_cookie(name) {
    document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
}