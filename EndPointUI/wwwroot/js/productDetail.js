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
async function TreatmentCenterModal(id) {
    var CurrentUICulture = document.getElementById("CurrentUICulture").value;
    var formData = new FormData();
    formData.append('Id', id);
    const response = await fetch('/Product/GetTreatmentCenterInformation', {
        method: 'POST',
        body: formData,

    });

    const data = await response.json();

    const modal = document.createElement('div');
    modal.className = 'modal fade show';
    modal.id = 'modalTreatmentCenterInfo';
    modal.tabIndex = '-1';
    modal.style.display = 'block';
    modal.setAttribute('aria-modal', 'true');
    modal.setAttribute('role', 'dialog');

    const modalDialog = document.createElement('div');
    modalDialog.className = 'modal-dialog modal-dialog-centered';
    modalDialog.setAttribute('role', 'document');

    const modalContent = document.createElement('div');
    modalContent.className = 'modal-content';

    const modalHeader = document.createElement('div');
    modalHeader.className = 'modal-header';

    const modalTitle = document.createElement('h5');
    modalTitle.className = 'modal-title secondary-font';
    modalTitle.id = 'modalCenterTitle';


    if (CurrentUICulture === "ltr") {
        modalTitle.innerText = data.titleEn;
    } else {
        modalTitle.innerText = data.titleFa;
    }



    const closeButton = document.createElement('button');
    closeButton.type = 'button';
    closeButton.className = 'btn-close';
    closeButton.setAttribute('data-bs-dismiss', 'modal');
    closeButton.setAttribute('aria-label', 'Close');
    closeButton.onclick = function () {
        var modal = document.getElementById("modalTreatmentCenterInfo");
        modal.remove();
    };
    // افزودن عنوان و دکمه بستن به سر(modalHeader)
    modalHeader.appendChild(modalTitle);
    modalHeader.appendChild(closeButton);

    const modalBody = document.createElement('div');
    modalBody.className = 'modal-body';
    modalBody.setAttribute("dir", CurrentUICulture);

    const productName = document.createElement("h4");
    const description = document.createElement("h4");
    const phoneNumber = document.createElement("h4");
    const link = document.createElement("a");
    const image = document.createElement("img");

    image.src = "/gallery/TreatmentCenter/" + data.image;
    image.setAttribute("style", "width: 100px;height: 80px;")
    image.classList.add("mb-4");
    if (CurrentUICulture === "ltr") {

        productName.innerText = "Product: " + data.productTitleEn;
        description.innerText = "Description: " + data.descriptionEn;
        phoneNumber.innerText = "Phone Number: " + data.phoneNumber;


    } else {

        productName.innerText = "محصول: " + data.productTitleFa;
        description.innerText = "توضیحات: " + data.descriptionFa;
        phoneNumber.innerText = "شماره تماس: " + data.phoneNumber;
    }
    link.innerText = data.link;
    link.setAttribute("href", data.link);





    modalBody.appendChild(image);
    modalBody.appendChild(productName);
    modalBody.appendChild(description);
    modalBody.appendChild(phoneNumber);
    modalBody.appendChild(link);





    const modalFooter = document.createElement('div');
    modalFooter.className = 'modal-footer';

    const closeModalButton = document.createElement('button');
    closeModalButton.type = 'button';
    closeModalButton.className = 'btn btn-label-secondary';
    closeModalButton.setAttribute('data-bs-dismiss', 'modal');


    if (CurrentUICulture === "ltr") {
        closeModalButton.innerText = 'Close';
    } else {
        closeModalButton.innerText = 'بستن';
    }

    closeModalButton.onclick = function () {
        var modal = document.getElementById("modalTreatmentCenterInfo");
        modal.remove();
    };

    // افزودن دکمه‌ها به فوتر
    modalFooter.appendChild(closeModalButton);


    // افزودن همه عناصر به محتویات مودال
    modalContent.appendChild(modalHeader);
    modalContent.appendChild(modalBody);
    modalContent.appendChild(modalFooter);

    modalDialog.appendChild(modalContent);
    modal.appendChild(modalDialog);

    // افزودن مودال به بدنه
    document.body.appendChild(modal);

}