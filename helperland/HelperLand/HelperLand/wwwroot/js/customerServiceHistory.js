$(document).ready(function () {
    $("#mytable1").DataTable();
    $("#mytable2").DataTable();
});

const dt = new DataTable("#mytable1", {
    dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
    responsive: true,
    pagingType: "full_numbers",
    language: {
        paginate: {
            first: '<img src="/image/first-page.png" alt="first" style= />',
            previous: '<img src="/image/previous.png" alt="previous" />',
            next: '<img src="/image/previous.png" alt="next" style="transform: rotate(180deg)" />',
            last: "<img src='/image/first-page.png' alt='first' style='transform: rotate(180deg)' />",
        },
        info: "Total Record: _MAX_",
        lengthMenu: "Show_MENU_Entries",
    },
    buttons: ["excel"],
    columnDefs: [{ orderable: false, targets: 4 }],
});

const dt1 = new DataTable("#mytable2", {
    dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
    responsive: true,
    pagingType: "full_numbers",
    language: {
        paginate: {
            first: '<img src="/image/first-page.png" alt="first" style= />',
            previous: '<img src="/image/previous.png" alt="previous" />',
            next: '<img src="/image/previous.png" alt="next" style="transform: rotate(180deg)" />',
            last: "<img src='/image/first-page.png' alt='first' style='transform: rotate(180deg)' />",
        },
        info: "Total Record: _MAX_",
        lengthMenu: "Show_MENU_Entries",
    },
    buttons: ["excel"],
    columnDefs: [{ orderable: false, targets: 4 }],
});

function html_table_to_excel(type) {
    var data = document.getElementById("mytable2");

    var file = XLSX.utils.table_to_book(data, { sheet: "sheet1" });

    XLSX.write(file, { bookType: type, bookSST: true, type: "base64" });

    XLSX.writeFile(file, "file." + type);
}

const export_button = document.getElementById("export");

export_button.addEventListener("click", () => {
    html_table_to_excel("xlsx");
});

var dashboard = document.getElementById("1");
var serviceRequest = document.getElementById("2");

function form1() {
    document.getElementById("Dashboard").style.display = "block";
    document.getElementById("ServiceHistory").style.display = "none";

    dashboard.style.background = "#146371";
    serviceRequest.style.background = "#1d7a8c";

    document.getElementsByClassName("my-setting-box")[0].classList.add("d-none");
    document.getElementsByClassName("contant-right")[0].classList.remove("d-none");
}

function form2() {
    document.getElementById("Dashboard").style.display = "none";
    document.getElementById("ServiceHistory").style.display = "block";

    dashboard.style.background = "#1d7a8c";
    serviceRequest.style.background = "#146371";

    document.getElementsByClassName("my-setting-box")[0].classList.add("d-none");
    document.getElementsByClassName("contant-right")[0].classList.remove("d-none");
}

var useroption = [
    document.getElementById("user-setting-option-1"),
    document.getElementById("user-setting-option-2"),
    document.getElementById("user-setting-option-3"),
];

var my_user_details =
    document.getElementsByClassName("my-setting-details")[0];
var my_user_address = document.getElementsByClassName(
    "my-setting-addresses"
)[0];
var my_user_change_password = document.getElementsByClassName(
    "my-setting-change-password"
)[0];
var my_user_option_icon =
    document.getElementsByClassName("user-menu-icon");

useroption[0].addEventListener("click", () => {
    useroption[0].classList.add("active-setting-option");
    useroption[1].classList.remove("active-setting-option");
    useroption[2].classList.remove("active-setting-option");

    my_user_details.classList.remove("d-none");
    my_user_address.classList.add("d-none");
    my_user_change_password.classList.add("d-none");

    my_user_option_icon[0].style.stroke = "#146371";
    my_user_option_icon[1].style.stroke = "#646464";
    my_user_option_icon[2].style.stroke = "#646464";
});


function showUserAddress() {

    $.ajax(
        {
            type: 'GET',
            url: '/Customer/getAllAddressDetails',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success:
                function (response) {
                    console.log(response);
                    var list = $("#UserAddressList");
                    list.empty();

                    for (var i = 0; i < response.length; i++) {

                        list.append('<tr> <td class= "user-address-list" > <p><strong>Address : </strong>' + response[i].addressLine2 + '-' + response[i].addressLine1 + ', ' + response[i].city + ' </p > <p><strong>Phone number</strong> ' + response[i].mobile + ' </p> </td ><td><div class="user-address-btn"><a><svg xmlns="http://www.w3.org/2000/svg" class="edit-icon" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path></svg>   </a> <a> <svg xmlns="http://www.w3.org/2000/svg" class="delete-icon" fill="none" viewBox="0 0 24 24" stroke="currentColor"> <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path>  </svg> </a> </div></td> <div></div></tr > ');

                    }
                
    



            

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

}
useroption[1].addEventListener("click", () => {
    useroption[0].classList.remove("active-setting-option");
    useroption[1].classList.add("active-setting-option");
    useroption[2].classList.remove("active-setting-option");

    my_user_details.classList.add("d-none");
    my_user_address.classList.remove("d-none");
    my_user_change_password.classList.add("d-none");

    my_user_option_icon[0].style.stroke = "#646464";
    my_user_option_icon[1].style.stroke = "#146371";
    my_user_option_icon[2].style.stroke = "#646464";

    showUserAddress();
});




useroption[2].addEventListener("click", () => {
    useroption[0].classList.remove("active-setting-option");
    useroption[1].classList.remove("active-setting-option");
    useroption[2].classList.add("active-setting-option");

    my_user_details.classList.add("d-none");
    my_user_address.classList.add("d-none");
    my_user_change_password.classList.remove("d-none");

    my_user_option_icon[0].style.stroke = "#646464";
    my_user_option_icon[1].style.stroke = "#646464";
    my_user_option_icon[2].style.stroke = "#146371";
});

function getUserdata() {
    $.ajax(
        {
            type: 'GET',
            url: '/Customer/getUserDetails',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success:
                function (response) {
                    console.log(response);
                    $("#firstname").val(response.firstName);
                    $("#lastname").val(response.lastName);
                    $("#email").val(response.email);
                    $("#mobile").val(response.mobile);
                    if (response.dateOfBirth != null) {
                        var dateOfBirth = response["dateOfBirth"].split('T');
                        var dateOfBirthArray = dateOfBirth[0].split("-");
                        $(".day").val(dateOfBirthArray[2]);
                        $(".month").val(dateOfBirthArray[1]);
                        $(".year").val(dateOfBirthArray[0]);
                    }

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

}
function my_user_setting() {

    document.getElementsByClassName("my-setting-box")[0].classList.remove("d-none");
    document.getElementsByClassName("contant-right")[0].classList.add("d-none");

    getUserdata();



}


function updateUserData() {
    var data = {};

   

    data.firstName = $("#firstname").val();
    data.lastName = $("#lastname").val();
    data.mobile = $("#mobile").val();
    var numbers = /^[0-9]+$/.test(data.mobile);
    data.dateOfBirth = $(".month").val() + "/" + $(".day").val() + "/" + $(".year").val();
    if (data.firstName == "" && data.lastName == "" && data.mobile == "") {
        $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid value");
    } else if (data.firstName == "") {
        $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid First Name");
    }
    else
        if (data.lastName == "") {
            $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid Last Name");
        } else

            if (data.mobile == "" || !numbers) {
                $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid moblie number");
            }
            else {
                $.ajax(
                    {
                        type: 'POST',
                        url: '/Customer/updateUserDetails',
                        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                        data: data,
                        success:
                            function (response) {
                                if (response.value == "true") {

                                    $(".setting-details-alert").removeClass("d-none alert-danger").addClass("alert-success").text("successfully data is update!").fadeIn().fadeOut(500);
                                   
                                    getUserdata();
                                } else if (response.value == "mobileThere") {
                                    $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("mobile number already exist please use different number");
                                }
                                


                            },
                        error:
                            function (response) {
                                console.error(response);
                                alert("fail");
                            }
                    });
            }
}


$("#updateUserDatabtn").click(() => {

    updateUserData();
});



const urlSearchParams = new URLSearchParams(window.location.search);
if (urlSearchParams == "customerDashboard=true") {
    form1();
}


if (urlSearchParams == "customerSetting=true") {
    my_user_setting();
}



document.addEventListener("click", (e) => {

    if (e.target.className == "cancel-btn") {
        console.log(e.target.value);
        document.getElementById("cancelId").value = e.target.value;
    }

    if (e.target.className == "reschedule-btn") {
        document.getElementById("rescheduleID").value = e.target.value;
       
       
    }


});


document.getElementById("rescheduleServiceRequestID").addEventListener("click", () => {


    console.log("date :- " + document.getElementById("rescheduledate").value);
    console.log("time :- " + document.getElementById("rescheduletime").value);

    var data = {}
    data.serviceRequestId = document.getElementById("rescheduleID").value;
    data.serviceStartDate = document.getElementById("rescheduledate").value;
    data.startTime = document.getElementById("rescheduletime").value;
  
    $.ajax(
        {
            type: 'POST',
            url: '/Customer/UpdateServiceRequest',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success:
                function (response) {
                    if (response.value == "true") {
                        window.location.reload();
                    }


                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

});


document.getElementById("CancelRequestbtn").addEventListener("click", () => {

    console.log("id :- " + document.getElementById("cancelId").value);
    console.log("comment :- " + document.getElementById("comment").value);

    var data = {};
    data.serviceRequestId = document.getElementById("cancelId").value;
    data.comments = document.getElementById("comment").value;

    $.ajax(
        {
            type: 'POST',
            url: '/Customer/CancelServiceRequest',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success:
                function (response) {
                    if (response.value == "true") {
                        window.location.reload();
                    }


                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });



});


$("#confirmPassword").change(() => {

    if ($("#NewPassword").val() != $("#confirmPassword").val()) {

        $(".confirmpass").removeClass("d-none");
    } else {
        $(".confirmpass").addClass("d-none");
        $("#updateUserPassword").removeClass("btn disabled");
    }

});


$("#updateUserPassword").click(() => {
    var data = {};     
    data.newPassword = $("#NewPassword").val();
    data.password = $("#currenPassword").val();
    var IsvalidPass = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/.test(data.newPassword);
    console.log(data);
    if ($("#currentPassword").val() == "" || $("#NewPassword").val() == "" || $("#confirmpass").val() == "") {
        $(".user-update-password-alert").addClass("alert-danger").removeClass("d-none").text("please fill all field");
    } else if (!IsvalidPass) {

        $(".user-update-password-alert").addClass("alert-danger").removeClass("d-none").text("Passwords must contain at least six characters, including uppercase, lowercase letters and numbers.");

    } else {
        $.ajax(
            {
                type: 'POST',
                url: '/Customer/UpdateUserPassword',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: data,
                success:
                    function (response) {
                        if (response.value == "true") {
                            $(".user-update-password-alert").addClass("alert-success").removeClass("alert-danger d-none").text("Password successfully update!")
                        }
                      


                    },
                error:
                    function (response) {
                        console.error(response);
                        alert("fail");
                    }
            });

    }

});




$(".user-address-add-btn").click(() => {
    var data = {};
    data.addressLine1 = $("#housenumber").val();
    data.addressLine2 = $("#streetname").val();
    data.postalCode = $("#postalcode").val();
    data.city = $("#city").val();
    data.mobile = $("#Mobile").val();
    var numbers = /^[0-9]+$/.test(data.mobile);
    console.log(data);
    var flag = 1;
    if (data.addressLine1 == "" && data.addressLine2 == "" && data.mobile == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value!");
        $(".user-address-add-btn").remosveAttr("data-bs-dismiss", "modal");
        flag = 0;
    }
    else if (data.addressLine1 == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of house!");
        $(".user-address-add-btn").removeAttr("data-bs-dismiss", "modal");
        flag = 0;
    } else if (data.addressLine2 == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of street!");
        $(".user-address-add-btn").removeAttr("data-bs-dismiss", "modal");
        flag = 0;
    } else if (data.mobile == "" || !numbers) {
        $(".addAddress-error").removeClass("d-none").text("please enter valid value of mobile!");
        $(".user-address-add-btn").removeAttr("data-bs-dismiss", "modal");
        flag = 0;
    }
    else {
        $('#staticBackdrop3').modal('hide');
        $(".addAddress-error").addClass("d-none").
        flag = 1;
    }

    if (flag == 1) {
        $.ajax(
            {
                type: 'POST',
                url: '/Customer/UserAddAddress',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: data,
                success:
                    function (response) {
                        if (response.value == "true") {
                            showUserAddress();
                            $(".setting-address-details-alert").addClass("alert-success").removeClass("alert-danger d-none").text("successfully add Address!");
                        }
                    },
                error:
                    function (response) {
                        console.error(response);
                        alert("fail");
                    }
            });


    }
});