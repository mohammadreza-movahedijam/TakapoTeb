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
        spaceBetween: 200,
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


    var swiper = new Swiper('.mySwiperFeedback', {
        slidesPerView: 3, // حالت پیش‌فرض برای دسکتاپ
        spaceBetween: 30,
        loop: true,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        pagination: {
            el: '.mySwiperFeedback-pagination',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        breakpoints: {
            // وقتی عرض صفحه کمتر از 768 پیکسل (مثلا موبایل) باشد
            0: {
                slidesPerView: 1,
                spaceBetween: 10,
            },
            // وقتی عرض صفحه 768 پیکسل یا بیشتر باشد (مثلا تبلت و دسکتاپ)
            768: {
                slidesPerView: 3,
                spaceBetween: 30,
            },
        },
    });
    var swiper = new Swiper('.mySwiperNews', {
        slidesPerView: 3, // حالت پیش‌فرض برای دسکتاپ
        spaceBetween: 30,
        loop: true,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        pagination: {
            el: '.mySwiperFeedback-pagination',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        breakpoints: {
            // وقتی عرض صفحه کمتر از 768 پیکسل (مثلا موبایل) باشد
            0: {
                slidesPerView: 1,
                spaceBetween: 10,
            },
            // وقتی عرض صفحه 768 پیکسل یا بیشتر باشد (مثلا تبلت و دسکتاپ)
            768: {
                slidesPerView: 3,
                spaceBetween: 30,
            },
        },
    });

    //var swiper = new Swiper('.mySwiperNews', {
    //    slidesPerView: 3,
    //    spaceBetween: 30,
    //    loop: true,
    //    autoplay: {
    //        delay: 3000,
    //        disableOnInteraction: false,
    //    },
    //    pagination: {
    //        el: '.mySwiperNews-pagination',
    //        clickable: true,
    //    },
    //    navigation: {
    //        nextEl: '.swiper-button-next',
    //        prevEl: '.swiper-button-prev',
    //    },
    //});



});

function ShowText(title, text) {
    Swal.fire({
        title: title,
        text: text,
         showConfirmButton:false,
        showCloseButton: true,

    });
}