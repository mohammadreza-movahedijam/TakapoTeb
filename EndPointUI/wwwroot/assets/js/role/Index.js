function Delete() {
    let body = {
        Id:9
    }
    rest.postAsync("/Admin/Role/Delete", null, body, function (isSuccess, response) {

        if (response.isSuccess) {
            Swal.fire({
                title: "درخواست ارسال شد",
                text: response.message[0],
                icon: "success",
                confirmButtonText: "متوجه شدم"
            });
        } else {

            Swal.fire({
                title: "درخواست ارسال نشد",
                text: response.message[0],
                icon: "warning",
                confirmButtonText: "متوجه شدم"
            });
        }
    });
}