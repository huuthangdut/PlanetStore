jQuery(document).ready(function () {
    jQuery('.js-remove-cart-item').on('click', function (e) {
        e.preventDefault();

        var productId = parseInt(jQuery(this).data('id'));
        cartController.deleteItem(productId);
    });

    jQuery('.js-remove-all-cart').on('click', function (e) {
        e.preventDefault();

        cartController.deleteAllItem();
    });

    jQuery('.js-change-quantity').on('textchange input', function (e) {
        e.preventDefault();

        var quantity = parseInt(jQuery(this).val());
        if (isNaN(quantity) || quantity < 1) {
            jQuery(this).val(1);
        }

        var productId = parseInt(jQuery(this).data('id'));
        cartController.updateItem(productId, quantity);
    });

    jQuery('.js-decrease-quantity').on('click', function (e) {
        e.preventDefault();
        var productId = parseInt(jQuery(this).data('id'));
        var quantity = parseInt(jQuery('#cart-quantity-' + productId).val());
        if (quantity > 1) {
            jQuery('#cart-quantity-' + productId).val(quantity - 1);
            cartController.updateItem(productId, quantity - 1);
        }
        
    });

    jQuery('.js-increase-quantity').on('click', function (e) {
        e.preventDefault();
        var productId = parseInt(jQuery(this).data('id'));
        var quantity = parseInt(jQuery('#cart-quantity-' + productId).val());
        jQuery('#cart-quantity-' + productId).val(quantity + 1);
        cartController.updateItem(productId, quantity + 1);
    });
});


var cartController = {
    deleteItem: function (productId) {
        jQuery.ajax({
            url: '/ShoppingCart/RemoveFromCart',
            data: {
                id: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.cartTotal === 0) {
                    window.location.reload();
                    window.scrollTo(0, 0);
                } else {
                    jQuery('#row-' + productId).fadeOut('slow');
                    jQuery('#mini-cart-row-' + productId).fadeOut('slow');
                    jQuery('.cart-total').text(numeral(response.cartTotal).format('0,0') + " đ");

                    // update minicart
                    jQuery('#cart-quantity').text(response.cartQuantity);
                }
            }
        });

    },
    deleteAllItem: function () {
        jQuery.ajax({
            url: '/ShoppingCart/EmptyCart',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    window.location.reload();
                    jQuery('html, body').animate({ scrollTop: 0 }, duration);
                }
            }
        });

    },
    updateItem: function (productId, quantity) {
        jQuery.ajax({
            url: '/ShoppingCart/UpdateCartItem',
            data: {
                id: productId,
                quantity: quantity
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                // update amount in row
                var amount = response.cartItem.Quantity * response.cartItem.Product.UnitPrice;
                jQuery('#item-amount-' + productId).text(numeral(amount).format('0,0') + " đ");
                jQuery('.cart-total').text(numeral(response.cartTotal).format('0,0') + " đ");

                // update minicart
                jQuery('#cart-quantity').text(response.cartQuantity);
            }
        });
    },
}