(function($) {
"use strict";

/* ==============================================
FIXED MENU -->
=============================================== */

$(".header-section").affix({
offset: {
top: 100, 
bottom: function () {
return (this.bottom = $('.copyrights').outerHeight(true))
}
}
})

/* ==============================================
MENU HOVER -->
=============================================== */

    $('.dropdown').hover(function() {
    $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeIn(300);
    }, function() {
    $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeOut(300);
    });

/* ==============================================
ANIMATION -->
=============================================== */

    new WOW({
    boxClass:     'wow',      // default
    animateClass: 'animated', // default
    offset:       0,          // default
    mobile:       true,       // default
    live:         true        // default
    }).init();

/* ==============================================
PARALLAX
=============================================== */

    $.stellar({
    horizontalScrolling: false,
    verticalOffset: 100
    });

/* ==============================================
MODAL -->
=============================================== */

    $(window).load(function() {
    $('.modalexample').modal('handleUpdate')
    })

/* ==============================================
BACK TOP -->
=============================================== */

    jQuery(window).scroll(function(){
    if (jQuery(this).scrollTop() > 1) {
    jQuery('.backtotop').css({bottom:"25px"});
    } else {
    jQuery('.backtotop').css({bottom:"-100px"});
    }
    });
    jQuery('.backtotop').click(function(){
    jQuery('html, body').animate({scrollTop: '0px'}, 800);
    return false;
    });

/* ==============================================
BACK TOP -->
=============================================== */

    $('#basic-timepicker-1').datetimepicker({
    prevText: '<i class="icon-arrow-left8"></i>',
    nextText: '<i class="icon-arrow-right8"></i>'
    });
    
/* ==============================================
    Progress Bar (Skills Bar)
=============================================== */

    $('.progress .progress-bar').progressbar({transition_delay: 800});

/* ==============================================
LOADER
=============================================== */

    jQuery(window).load( function() {
    setTimeout( function() {
    jQuery("#loader").delay(300).fadeOut(600);
    jQuery(".loader-back-text").fadeOut(1000);
    }, 3200 );
    });

/* ==============================================
TOOLTIP -->
=============================================== */

    $('body').tooltip({
    selector: "[data-tooltip=tooltip]",
    container: "body"
    });

})(jQuery);