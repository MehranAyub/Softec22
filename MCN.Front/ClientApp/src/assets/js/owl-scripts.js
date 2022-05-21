    (function($) { 
        "use strict";
    $(document).ready(function(){

        $('#owl-testimonial').owlCarousel({
            loop:true,
            margin:25,
            nav:false,
            dots:true,
            responsive:{
                0:{
                    items:1
                },
                600:{
                    items:1
                },
                1000:{
                    items:1
                }
            }
        })

    });
    })(jQuery);