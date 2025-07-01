$(document).ready(function () {

    let lat = parseFloat(document.getElementById("lat").value);
    let lon = parseFloat(document.getElementById("lon").value);


   
    var map = L.map('contact-map').setView([lat, lon], 15);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    L.marker([lat, lon]).addTo(map)
       
        .openPopup();
    map.invalidateSize();

});
function SendMessage(language) {
    let fullname = document.getElementById("fullname").value;
    let email = document.getElementById("email").value;
    let phonenumber = document.getElementById("phonenumber").value;
    let subject = document.getElementById("subject").value;
    let text = document.getElementById("text").value;
    if (!fullname || !email || !phonenumber || !subject || !text)
    {
        Swal.fire({
            title: "خطای ارسال پیام",
            text: "لطفا فرم را تکمیل نمائید",
            icon: "warning",
            confirmButtonText:"متوجه شدم"
        });
        return;
    }

    let body = {
        fullname: fullname,
        email: email,
        phonenumber: phonenumber,
        subject: subject,
        text: text
    }

    rest.postAsync("/AddMessage", null, body, function (isSuccess, response) {
        if (response.isSuccess) {
            document.getElementById("fullname").value = "";
            document.getElementById("email").value = "";
            document.getElementById("phonenumber").value = "";
            document.getElementById("subject").value = "";
            document.getElementById("text").value = "";
            if (language === "en-US") {
                Swal.fire({
                    title: "The message was sent",
                    text: "Our experts will contact you soon.",
                    icon: "success",
                    confirmButtonText: "Ok"
                });

               
            } else {
                Swal.fire({
                    title: "پیام ارسال شد",
                    text: "کارشناسان ما به زودی با شما ارتباط برقرار خواهند کرد",
                    icon: "success",
                    confirmButtonText: "متوجه شدم"
                });
            }
          
        } else {

            Swal.fire({
                title: "حذف انجام نشد",
                text: response.message,
                icon: "warning",
                confirmButtonText: "متوجه شدم"
            });
        }
    });



}