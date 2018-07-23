jQuery(document).ready(function () {
    jQuery('.js-add-to-cart').on('click',
        function () {
            var productId = parseInt(jQuery(this).data('id'));
            commonController.addToCart(productId);
        });
});

var commonController = {
    addToCart: function (productId) {
        jQuery.ajax({
            url: '/ShoppingCart/AddToCart',
            data: {
                id: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
//                window.location.reload();
                
                toastr.info("Thêm giỏ hàng thành công.", "<i class='ec ec-shopping-bag'></i>     Xem chi tiết giỏ hàng");
               
            }
        });
    }
}