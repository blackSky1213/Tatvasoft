
    $(document).ready(function () {
    $("#mytable1").DataTable();
    $("#mytable2").DataTable();
    $("#mytable3").DataTable();
    $("#mytable4").DataTable();

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
    columnDefs: [{orderable: false, targets: 4 }],
    });

    const table2 = new DataTable("#mytable2", {
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
    columnDefs: [{orderable: false, targets: 4 }],
    });

    const table3 = new DataTable("#mytable3", {
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
    columnDefs: [{orderable: false, targets: 2 }],
    });

    const table4 = new DataTable("#mytable4", {
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
    columnDefs: [{orderable: false, targets: 3 }],
    });

    var dashboard = document.getElementById("2");
    var UpcomingService = document.getElementById("3");

    var ServiceHistory = document.getElementById("5");
    var MyRating = document.getElementById("6");
    var mysetting = document.getElementsByClassName("my-setting-box")[0];

    function form2() {
        document.getElementById("Dashboard").classList.remove("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
    document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
    mysetting.classList.add("d-none");


    dashboard.style.background = "#146371";
    UpcomingService.style.background = "#1d7a8c";
    ServiceHistory.style.background = "#1d7a8c";
    MyRating.style.background = "#1d7a8c";
    }

    function form3() {
        document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.remove("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
    document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
    mysetting.classList.add("d-none");

    dashboard.style.background = "#1d7a8c";
    UpcomingService.style.background = "#146371";
    ServiceHistory.style.background = "#1d7a8c";
    MyRating.style.background = "#1d7a8c";
    }

    function form5() {
        document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.remove("d-none");
    document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
    mysetting.classList.add("d-none");

    dashboard.style.background = "#1d7a8c";
    UpcomingService.style.background = "#1d7a8c";
    ServiceHistory.style.background = "#146371";
    MyRating.style.background = "#1d7a8c";
    }


    function form6() {
    document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
    document.getElementById("serviceProviderCustomerRating").classList.remove("d-none");
    mysetting.classList.add("d-none");

    dashboard.style.background = "#1d7a8c";
    UpcomingService.style.background = "#1d7a8c";
    ServiceHistory.style.background = "#1d7a8c";
    MyRating.style.background = "#146371";
    }


    function opensetting() {

    document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
    document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
        document.getElementsByClassName("my-setting-box")[0].classList.remove("d-none");


        getUserdata();
    }

    var useroption = [
    document.getElementById("user-setting-option-1"),
    document.getElementById("user-setting-option-3"),
    ];
    var my_user_details =
    document.getElementsByClassName("my-setting-details")[0];
    var my_user_change_password = document.getElementsByClassName(
    "my-setting-change-password"
    )[0];
    var my_user_option_icon =
    document.getElementsByClassName("user-menu-icon");
    useroption[0].addEventListener("click", () => {
        useroption[0].classList.add("active-setting-option");
    useroption[1].classList.remove("active-setting-option");


    my_user_details.classList.remove("d-none");

    my_user_change_password.classList.add("d-none");

    my_user_option_icon[0].style.stroke = "#146371";
    my_user_option_icon[1].style.stroke = "#646464";

    });

    useroption[1].addEventListener("click", () => {
        useroption[0].classList.remove("active-setting-option");
    useroption[1].classList.add("active-setting-option");


    my_user_details.classList.add("d-none");

    my_user_change_password.classList.remove("d-none");

    my_user_option_icon[0].style.stroke = "#646464";
    my_user_option_icon[1].style.stroke = "#146371";
    });

$(".avtar").click(() => {
    var iconName = $(".avtar:checked").val();
    $("#profileAvtar").attr("src", "/image/" + iconName + ".jpg");
});




const urlSearchParams = new URLSearchParams(window.location.search);
if (urlSearchParams == "ProviderSetting=true") {
    opensetting();
}



function getUserdata() {
        $.ajax(
            {
                type: 'GET',
                url: '/ServiceProvider/getUserDetails',
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
                        if (response.userProfilePicture != null) {
                            $("#profileAvtar").attr("src", "/image/" + response.userProfilePicture + ".jpg");
                            $(".avtar").filter('[value="' + response.userProfilePicture+'"]').attr('checked', true);
                        }
                        if (response.gender != null) {
                            $("#gender").val(response.gender);
                        }
                        if (response["userAddresses"].length != 0) {
                            
                            $("#streetname").val(response["userAddresses"][0].addressLine2);
                            $("#housenumber").val(response["userAddresses"][0].addressLine1);
                            $("#postalcode").val(response["userAddresses"][0].postalCode);
                            $("#City").val(response["userAddresses"][0].city);
                        }

                    },
                error:
                    function (response) {
                        console.error(response);
                        alert("fail");
                    }
            });

}


document.getElementById("postalcode").addEventListener("focusout", () => {

    var zip = $("#postalcode").val();
    if (zip.length == 6) {
        getZipcodeCity(zip, "City", "State", "updateUserDatabtn");
    }
    else {
        $(".setting-address-details-alert").removeClass("d-none").text("please enter valid postalcode!").fadeIn().fadeOut(2000);
        $("#updateUserDatebtn").addClass("btn disabled");

    }

});

function getZipcodeCity(zipcode, tagidcity, tagidstate, tagiderror) {


    $.ajax({
        url: "https://api.postalpincode.in/pincode/" + zipcode,
        method: "GET",
        dataType: "json",
        cache: false,

        success: (data) => {

            console.log(data);
            if (data[0].Status == "Error") {
                console.log("err");
                $(".setting-address-details-alert").removeClass("d-none").text("please enter valid postalcode!").fadeIn().fadeOut(2000);
                $("#" + tagiderror).addClass("btn disabled");

                $("#" + tagidcity).val("");


            } else if (data[0].Status == "Success") {
                $("#" + tagidcity).val(data[0].PostOffice[0].District);
                $("#" + tagidstate).val(data[0].PostOffice[0].State);
                $(".setting-address-details-alert").addClass("d-none");
                $("#" + tagiderror).removeClass("btn disabled");

            }
        },
        error: (err) => {
            console.log(err);
        }

    });

}







document.getElementById("updateUserDatabtn").addEventListener("click", () => {
    updateUserDetails();
});



function updateUserDetails() {

 
    var data = {};
    var addressData = {}



        data.firstName = $("#firstname").val();
        data.lastName = $("#lastname").val();
        data.mobile = $("#mobile").val();
        var numbers = /^[0-9]+$/.test(data.mobile);
    data.gender = $(".gender:checked").val();
    data.userProfilePicture = $(".avtar:checked").val();
    addressData.addressLine1 = $("#streetname").val();
    addressData.addressLine2 = $("#housenumber").val();
    addressData.postalCode = $("#postalcode").val();
    addressData.city = $("#City").val();
    addressData.state = $("#State").val();
    data.userAddresses =[addressData];
   
    console.log(data);
        data.dateOfBirth = $(".month").val() + "/" + $(".day").val() + "/" + $(".year").val();
    if (data.firstName == "" && data.lastName == "" && data.mobile == "") {
        $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid value").fadeIn().fadeOut(7000);
    } else if (data.firstName == "") {
        $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid First Name").fadeIn().fadeOut(7000);
    }
    else
        if (data.lastName == "") {
            $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid Last Name").fadeIn().fadeOut(7000);
        } else

            if (data.mobile == "" || !numbers) {
                $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid moblie number").fadeIn().fadeOut(7000);
            } else if (data.gender == undefined) {
                $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please select gender").fadeIn().fadeOut(7000);

            } else if (data.userProfilePicture == undefined) {
                $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please select profile picture").fadeIn().fadeOut(7000);

            } else if (addressData.addressLine1 == "" || addressData.addressLine2 == "" || addressData.postalCode == "") {
                    $(".setting-address-details-alert").removeClass("d-none").text("please fill the address field");
                }
                else {
                    $.ajax(
                        {
                            type: 'POST',
                            url: '/ServiceProvider/updateUserDetails',
                            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                            data: data,
                            success:
                                function (response) {
                                    if (response.value == "true") {

                                        $(".setting-details-alert").removeClass("d-none alert-danger").addClass("alert-success").text("successfully data is update!").fadeIn().fadeOut(7000);
                                        $(".setting-address-details-alert").addlass("d-none");

                                        getUserdata();
                                    } else if (response.value == "mobileThere") {
                                        $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("mobile number already exist please use different number").fadeIn().fadeOut(7000);
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
        $(".user-update-password-alert").addClass("alert-danger").removeClass("d-none").text("please fill all field").fadeIn().fadeOut(2000);
    } else if (!IsvalidPass) {

        $(".user-update-password-alert").addClass("alert-danger").removeClass("d-none").text("Passwords must contain at least six characters, including uppercase, lowercase letters and numbers.").fadeIn().fadeOut(2000);

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
                            $(".user-update-password-alert").addClass("alert-success").removeClass("alert-danger d-none").text("Password successfully update!").fadeIn().fadeOut(2000);
                        } else {
                            $(".user-update-password-alert").addClass("alert-danger").removeClass("alert-success d-none").text("password is wrong please try again").fadeIn().fadeOut(2000);
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



