document.addEventListener("DOMContentLoaded", () => {
    var swiper = new Swiper('.mySwiper', {
        loop: true,
        autoplay: {
            delay: 3000, // زمان توقف هر اسلاید به میلی‌ثانیه (اینجا 3 ثانیه)
            disableOnInteraction: false, // اجازه می‌دهد اسلایدر هنگام کلیک یا حرکت کاربر متوقف نشود
        },
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
    });

    var swiper = new Swiper(".mySwiperPartner", {
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