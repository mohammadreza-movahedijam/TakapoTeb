$(document).ready(function () {
    var swiper = new Swiper(".mySwiperRelated", {
        slidesPerView: 'auto',
        spaceBetween: 30,
        centeredSlides: false,
        loop: true,
        grabCursor: true,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
    });
});