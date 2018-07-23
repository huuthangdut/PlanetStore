jQuery(document).ready(function () {
    var offset = 250;
    var duration = 500;
    jQuery(window).scroll(function () {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('.back-to-top').fadeIn(duration);

        } else {
            jQuery('.back-to-top').fadeOut(duration);
        }
    });

    jQuery('.back-to-top').click(function (event) {
        event.preventDefault();
        jQuery('html, body').animate({ scrollTop: 0 }, duration);

        return false;
    });

    jQuery('#search').autocomplete({
        minLength: 2,
        source: function (request, response) {
            jQuery.ajax({
                url: "/Products/GetSuggestedProducts",
                dataType: "json",
                data: {
                    keyword: request.term
                },
                success: function (res) {
                    response(res.data);
                }
            });
        },
        focus: function (event, ui) {
            jQuery("#search").val(ui.item.Name);
            return false;
        },
        select: function (event, ui) {
            jQuery("#search").val(ui.item.Name);
            return false;
        }
    }).autocomplete("instance")._renderItem = function (ul, item) {
        return jQuery("<li>")
            .append("<div>" + item.Name + "</div>")
            .appendTo(ul);
        }

    toastr.options = {
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr.options.onclick = function () {
        window.location.href = 'http://localhost:5000/gio-hang';
    }

});

