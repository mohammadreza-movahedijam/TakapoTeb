function SendRequestEducation(dir) {
    let Center = document.getElementById("Center").value;
    let FullName = document.getElementById("FullName").value;
    let Mobile = document.getElementById("Mobile").value;
    let DeviceName = document.getElementById("DeviceName").value;
    let DeviceSerialNumber = document.getElementById("DeviceSerialNumber").value;
    let Description = document.getElementById("Description").value;
    let EducationType = document.getElementsByName("EducationType");
    let files = document.getElementById("FileAttachment").files; // اصلاح شده

    if (Center === "" || Center === null) {
        if (dir === "rtl") {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "نام مرکز را وارد نمائید",
                icon: "error",
                confirmButtonText: "متوجه شدم"
            });
        } else {
            Swal.fire({
                title: "Validation error",
                text: "Enter the name of the center",
                icon: "error",
                confirmButtonText: "Ok"
            });
        }
        return;
    }

    if (FullName === "" || FullName === null) {
        if (dir === "rtl") {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "نام و نام خانوادگی را وارد نمائید",
                icon: "error",
                confirmButtonText: "متوجه شدم"
            });
        } else {
            Swal.fire({
                title: "Validation error",
                text: "Enter your first and last name",
                icon: "error",
                confirmButtonText: "Ok"
            });
        }
        return;
    }

    if (Mobile === "" || Mobile === null) {
        if (dir === "rtl") {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "موبایل را وارد نمائید",
                icon: "error",
                confirmButtonText: "متوجه شدم"
            });
        } else {
            Swal.fire({
                title: "Validation error",
                text: "Enter your mobile phone",
                icon: "error",
                confirmButtonText: "Ok"
            });
        }
        return;
    }

    if (DeviceName === "" || DeviceName === null) {
        if (dir === "rtl") {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "نام دستگاه را وارد نمائید",
                icon: "error",
                confirmButtonText: "متوجه شدم"
            });
        } else {
            Swal.fire({
                title: "Validation error",
                text: "Enter the device name",
                icon: "error",
                confirmButtonText: "Ok"
            });
        }
        return;
    }

    let selectedValue = null;
    for (let i = 0; i < EducationType.length; i++) {
        if (EducationType[i].checked) {
            selectedValue = EducationType[i].value;
            break;
        }
    }

    let formData = new FormData();
    for (const file of files) { // اضافه کردن فایل‌ها به formData
        formData.append('attachments', file);
    }

    formData.append("TreatmentCenterName", Center);
    formData.append("FullName", FullName);
    formData.append("Mobile", Mobile);
    formData.append("DeviceSerialNumber", DeviceSerialNumber);
    formData.append("DeviceName", DeviceName);
    formData.append("EducationType", selectedValue);
    formData.append("Description", Description);

    fetch("/SendRequestEducation", {
        method: "POST",
        body: formData,
    })
        .then(response => response.json())
        .then(data => {
            document.getElementById("Center").value = "";
            document.getElementById("FullName").value = "";
            document.getElementById("Mobile").value = "";
            document.getElementById("DeviceName").value = "";
            document.getElementById("DeviceSerialNumber").value = "";
            document.getElementById("Description").value = "";
            document.getElementById("FileAttachment").value = "";


            let EducationTypes = document.getElementsByName("EducationType");
            for (let i = 0; i < EducationTypes.length; i++) {
                EducationTypes[i].checked = false;
            }









            if (data.isSuccess) {
                if (dir === "rtl") {
                    Swal.fire({
                        title: "درخواست ارسال شد",
                        icon: "success",
                        confirmButtonText: "متوجه شدم"
                    });
                } else {
                    Swal.fire({
                        title: "The request was sent",
                        icon: "success",
                        confirmButtonText: "Ok"
                    });
                }
            } else {
                if (dir === "rtl") {
                    Swal.fire({
                        title: "درخواست ارسال نشد",
                        icon: "warning",
                        confirmButtonText: "متوجه شدم"
                    });
                } else {
                    Swal.fire({
                        title: "The request was not sent",
                        icon: "warning",
                        confirmButtonText: "Ok"
                    });
                }
            }
        })
        .catch(error => {
            console.error('Error:', error);
            if (dir === "rtl") {
                Swal.fire({
                    title: "خطا در ارسال درخواست",
                    text: "لطفا دوباره تلاش کنید.",
                    icon: "error",
                    confirmButtonText: "متوجه شدم"
                });
            } else {
                Swal.fire({
                    title: "Error sending request",
                    text: "Please try again.",
                    icon: "error",
                    confirmButtonText: "Ok"
                });
            }
        });
}


function SendRequestService(dir) {
    let Center =             document.getElementById("Center").value;
    let FullName =           document.getElementById("FullName").value;
    let Mobile =             document.getElementById("Mobile").value;
    let DeviceName =         document.getElementById("DeviceName").value;
    let DeviceSerialNumber = document.getElementById("DeviceSerialNumber").value;
    let Description =        document.getElementById("Description").value;
    let RequestType =        document.getElementsByName("RequestType");
    let files =              document.getElementById("FileAttachment").files; 

    if (Center === "" || Center === null) {
        if (dir === "rtl") {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "نام مرکز را وارد نمائید",
                icon: "error",
                confirmButtonText: "متوجه شدم"
            });
        } else {
            Swal.fire({
                title: "Validation error",
                text: "Enter the name of the center",
                icon: "error",
                confirmButtonText: "Ok"
            });
        }
        return;
    }

    if (FullName === "" || FullName === null) {
        if (dir === "rtl") {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "نام و نام خانوادگی را وارد نمائید",
                icon: "error",
                confirmButtonText: "متوجه شدم"
            });
        } else {
            Swal.fire({
                title: "Validation error",
                text: "Enter your first and last name",
                icon: "error",
                confirmButtonText: "Ok"
            });
        }
        return;
    }

    if (Mobile === "" || Mobile === null) {
        if (dir === "rtl") {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "موبایل را وارد نمائید",
                icon: "error",
                confirmButtonText: "متوجه شدم"
            });
        } else {
            Swal.fire({
                title: "Validation error",
                text: "Enter your mobile phone",
                icon: "error",
                confirmButtonText: "Ok"
            });
        }
        return;
    }

    if (DeviceName === "" || DeviceName === null) {
        if (dir === "rtl") {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "نام دستگاه را وارد نمائید",
                icon: "error",
                confirmButtonText: "متوجه شدم"
            });
        } else {
            Swal.fire({
                title: "Validation error",
                text: "Enter the device name",
                icon: "error",
                confirmButtonText: "Ok"
            });
        }
        return;
    }

    let selectedValue = null;
    for (let i = 0; i < RequestType.length; i++) {
        if (RequestType[i].checked) {
            selectedValue = RequestType[i].value;
            break;
        }
    }

    let formData = new FormData();
    for (const file of files) { // اضافه کردن فایل‌ها به formData
        formData.append('attachments', file);
    }

    formData.append("TreatmentCenterName", Center);
    formData.append("FullName", FullName);
    formData.append("Mobile", Mobile);
    formData.append("DeviceSerialNumber", DeviceSerialNumber);
    formData.append("DeviceName", DeviceName);
    formData.append("RequestType", selectedValue);
    formData.append("Description", Description);

    fetch("/SendRequestService", {
        method: "POST",
        body: formData,
    })
        .then(response => response.json())
        .then(data => {
            document.getElementById("Center").value = "";
            document.getElementById("FullName").value = "";
            document.getElementById("Mobile").value = "";
            document.getElementById("DeviceName").value = "";
            document.getElementById("DeviceSerialNumber").value = "";
            document.getElementById("Description").value = "";
            document.getElementById("FileAttachment").value = "";


            let requestTypes = document.getElementsByName("RequestType");
            for (let i = 0; i < requestTypes.length; i++) {
                requestTypes[i].checked = false;
            }

            if (data.isSuccess) {
                if (dir === "rtl") {
                    Swal.fire({
                        title: "درخواست ارسال شد",
                        icon: "success",
                        confirmButtonText: "متوجه شدم"
                    });
                } else {
                    Swal.fire({
                        title: "The request was sent",
                        icon: "success",
                        confirmButtonText: "Ok"
                    });
                }
            } else {
                if (dir === "rtl") {
                    Swal.fire({
                        title: "درخواست ارسال نشد",
                        icon: "warning",
                        confirmButtonText: "متوجه شدم"
                    });
                } else {
                    Swal.fire({
                        title: "The request was not sent",
                        icon: "warning",
                        confirmButtonText: "Ok"
                    });
                }
            }
        })
        .catch(error => {
            console.error('Error:', error);
            if (dir === "rtl") {
                Swal.fire({
                    title: "خطا در ارسال درخواست",
                    text: "لطفا دوباره تلاش کنید.",
                    icon: "error",
                    confirmButtonText: "متوجه شدم"
                });
            } else {
                Swal.fire({
                    title: "Error sending request",
                    text: "Please try again.",
                    icon: "error",
                    confirmButtonText: "Ok"
                });
            }
        });
}
