function Delete(id) {
    Swal.fire({
        title: "آیا نقش کاربری حذف شود؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "بله حذف شود",
        cancelButtonText: "انصراف"
    }).then((result) => {
        if (result.isConfirmed) {
            var body = {
                id: id
            };
            rest.postAsync("/Home/SendContactMessage", null, body,
                function (isSuccess, response) {
                    if (isSuccess) {
                        Swal.fire({
                            title: "پیام شما ارسال شد",
                            icon: "success",
                            confirmButtonText: "متوجه شدم"
                        });
                    } else {
                        Swal.fire({
                            title: "پیام شما ارسال نشد",
                            icon: "warning",
                            confirmButtonText: "متوجه شدم"
                        });
                    }
                });
        }
    });
}