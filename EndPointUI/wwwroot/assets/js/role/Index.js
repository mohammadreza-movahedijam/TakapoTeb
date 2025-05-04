﻿function Delete(id) {
    
    let body = {
        Id:id
    }
   
    Swal.fire({
        title: "آیا نقش حذف شود؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "انصراف",
        confirmButtonText: "بله حذف شود"
    }).then((result) => {
        if (result.isConfirmed) {
            rest.postAsync("/Admin/Role/Delete", null, body, function (isSuccess, response) {
                let role = document.getElementById("item_" + id);
                if (response.isSuccess) {

                    Swal.fire({
                        title: "نقش با موفقیت حذف شد",
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