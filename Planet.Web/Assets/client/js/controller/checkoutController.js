jQuery(document).ready(function () {
    jQuery('#different-address').hide();
    if (jQuery("#ship-to-different-address-checkbox").change(function () {
        if (this.checked)
            jQuery('#different-address').show();
        else
            jQuery('#different-address').hide();
    }));

    if (jQuery("#autofill-billing").change(function () {
        if (this.checked)
            checkoutController.fillBillingInfo();
    }));
});

var checkoutController = {
    fillBillingInfo: function () {
        jQuery.ajax({
            url: '/Account/GetCurrentUser',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var user = response.user;
                    jQuery('#bill-first-name').val(user.FirstName);
                    jQuery('#bill-last-name').val(user.LastName);
                    jQuery('#bill-email').val(user.Email);
                    jQuery('#bill-phone-number').val(user.PhoneNumber);
                    jQuery('#bill-address').val(user.Address);
                    jQuery('#bill-district').val(user.District);
                    jQuery('#bill-province').val(user.Province);
                    jQuery('#bill-country').val(user.Country);
                   
                }
                
            }
        });
    }
}