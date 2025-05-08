function Delete(id) {
    
    let body = {
        Id:id
    }
   
    Swal.fire({
        title: "آیا کاربر حذف شود؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "انصراف",
        confirmButtonText: "بله حذف شود"
    }).then((result) => {
        if (result.isConfirmed) {
            rest.postAsync("/Admin/User/Delete", null, body, function (isSuccess, response) {
                let role = document.getElementById("item_" + id);
                if (response.isSuccess) {

                    Swal.fire({
                        title: "کاربر با موفقیت حذف شد",
                        icon: "success",
                        confirmButtonText: "متوجه شدم"
                    });
                    role.remove();
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
    });
   
}
function SetPassword(id) {
    Swal.fire({
        title: "تنظیم گذرواژه",
        text: "گذرواژه را وارد کنید",
        input: "password",
        inputAttributes: {
            autocapitalize: "off"
        },
        showCancelButton: true,
        cancelButtonText: "انصراف",
        confirmButtonText: "ثبت",
        showLoaderOnConfirm: true,
        preConfirm: (password) => {
            if (!password || password.length < 6) {
                Swal.showValidationMessage("گذرواژه نمیتواند خالی باشد و حداقل باید ۶ کاراکتر داشته باشد");
                return false;
            }
           
            let body = {
                UserId: id,
                Password: password
            };
           
            rest.postAsync("/Admin/User/SetPassword", null, body, function (isSuccess, response) {
                if (response.isSuccess) {

                    Swal.fire({
                        title: "گذرواژه با موفقیت تنظیم شد",
                        icon: "success",
                        confirmButtonText: "متوجه شدم"
                    });
                  
                } else {

                    Swal.fire({
                        title: "عملیات ناموفق",
                        text: response.message,
                        icon: "warning",
                        confirmButtonText: "متوجه شدم"
                    });
                }
            })

        },
        allowOutsideClick: () => !Swal.isLoading()
    });
}