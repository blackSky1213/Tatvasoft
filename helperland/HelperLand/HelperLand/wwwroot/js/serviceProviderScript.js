
    $(document).ready(function () {
    $("#mytable1").DataTable();

        });

$(window).on('load', function () {

    $("html").css("overflow", "auto");

    $(".lds-roller").css("display", "none");
    $(".overlayer").css("display", "none");
    
}
);


    


    const dt = new DataTable("#mytable1", {
        dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
    responsive: true,
    pagingType: "full_numbers",
    "order": [0, 'desc'],
    'ordering': true,
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



$("#havepetCheck").change(() => {

    if ($("#havepetCheck").is(":checked")) {
        dt.search("").draw();
    } else {
        dt.search("nopets").draw();
    }
});

   

    var dashboard = document.getElementById("2");
    var UpcomingService = document.getElementById("3");

    var ServiceHistory = document.getElementById("5");
    var MyRating = document.getElementById("6");
var mysetting = document.getElementsByClassName("my-setting-box")[0];
var ServiceScheduleTable = document.getElementById("4");

    function form2() {
        document.getElementById("Dashboard").classList.remove("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
        document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
        document.getElementById("blockCustomer").classList.add("d-none");
        document.getElementById("7").style.background = "#1d7a8c";
        mysetting.classList.add("d-none");


        document.getElementById("ServiceScheduleTable").classList.add("d-none");
        ServiceScheduleTable.style.background = "#1d7a8c";

    dashboard.style.background = "#146371";
    UpcomingService.style.background = "#1d7a8c";
    ServiceHistory.style.background = "#1d7a8c";
        MyRating.style.background = "#1d7a8c";
        var url = new URL(window.location.href);
        url.search = "";
        window.location.replace(url.toString());
    }

    function form3() {
        document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.remove("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
        document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
        document.getElementById("blockCustomer").classList.add("d-none");
        document.getElementById("7").style.background = "#1d7a8c";
    mysetting.classList.add("d-none");

        document.getElementById("ServiceScheduleTable").classList.add("d-none");
        ServiceScheduleTable.style.background = "#1d7a8c";

    dashboard.style.background = "#1d7a8c";
    UpcomingService.style.background = "#146371";
    ServiceHistory.style.background = "#1d7a8c";
        MyRating.style.background = "#1d7a8c";

        getUpcomingService();
}
var calendarEl = document.getElementById('calendar');
var calendar;

function timeTableData() {
    
    $.ajax({
        type: "GET",
        url: '/ServiceProvider/GetDataForCalendar',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        beforeSend: function () {
            $("html").css("overflow", "hidden");
            $(".lds-roller").css("display", "inline-block");
            $(".overlayer").css("display", "block");

        },
        complete: function () {
            setTimeout(function () {
                $("html").css("overflow", "auto");

                $(".lds-roller").css("display", "none");
                $(".overlayer").css("display", "none");
            }, 500);
        },

        success: function (doc) {
           
            if (doc != "false") {
                var events = [];
                console.log(doc);
                for (var i = 0; i < doc.length; i++) {
                    var newDate = `${doc[i].serviceStartDate.split("/")[2]}-${doc[i].serviceStartDate.split("/")[1]}-${doc[i].serviceStartDate.split("/")[0]}`;
                    var date = doc[i].serviceStartDate.split("/")[2] + "/" + doc[i].serviceStartDate.split("/")[1] + "/" + doc[i].serviceStartDate.split("/")[0];
                    var now = new Date();
                    var endTime = new Date(date + " " + doc[i].endTime);
                    var labelColor = '#555';
                    if (now >= endTime) {
                        labelColor = "#146371";
                    }
                    events.push({
                        id: doc[i].serviceRequestId,
                        start: newDate,
                        title: doc[i].startTime + " - " + doc[i].endTime,
                        backgroundColor: labelColor,
                        borderColor: "#fff",
                        classNames:"work-label"
                    });
                }

                console.log(events);
                    
            }

            
            calendar = new FullCalendar.Calendar(calendarEl, {
                eventClick: function (info) {
                    $(".btn-box").addClass("d-none");
                    $(".btn-box1").addClass("d-none");

                    $("#CancelServiceModalbtn").attr("data-value", info.event.id );
                    $("#CompleteModalbtn").attr("data-value", info.event.id);
                    document.getElementById("CustomerServiceSummery-btn").click();
                  
                    getServiceRequestAllDetails(info.event.id);
                },
                events:events,
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next title',
                    center: '',
                    right: ''
                },

            });
            calendar.render();
        }
    });

    
}



function form4() {
    document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
    document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
    document.getElementById("ServiceScheduleTable").classList.remove("d-none");
    document.getElementById("blockCustomer").classList.add("d-none");
    document.getElementById("7").style.background = "#1d7a8c";

    mysetting.classList.add("d-none");

    dashboard.style.background = "#1d7a8c";
    ServiceScheduleTable.style.background = "#146371";
    UpcomingService.style.background = "#1d7a8c";
    ServiceHistory.style.background = "#1d7a8c";
    MyRating.style.background = "#1d7a8c";
    timeTableData();
    

}

    function form5() {
        document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.remove("d-none");
        document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
        document.getElementById("blockCustomer").classList.add("d-none");
        document.getElementById("7").style.background = "#1d7a8c";
        mysetting.classList.add("d-none");

        document.getElementById("ServiceScheduleTable").classList.add("d-none");
        ServiceScheduleTable.style.background = "#1d7a8c";

    dashboard.style.background = "#1d7a8c";
    UpcomingService.style.background = "#1d7a8c";
    ServiceHistory.style.background = "#146371";
        MyRating.style.background = "#1d7a8c";



        getServiceHistory();
    }


    function form6() {
    document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
        document.getElementById("serviceProviderCustomerRating").classList.remove("d-none");
        document.getElementById("blockCustomer").classList.add("d-none");
        document.getElementById("7").style.background = "#1d7a8c";
        mysetting.classList.add("d-none");


        document.getElementById("ServiceScheduleTable").classList.add("d-none");
        ServiceScheduleTable.style.background = "#1d7a8c";

    dashboard.style.background = "#1d7a8c";
    UpcomingService.style.background = "#1d7a8c";
    ServiceHistory.style.background = "#1d7a8c";
        MyRating.style.background = "#146371";

        getServiceProviderRating();
    }


function form7() {
    document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
    document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
    document.getElementById("blockCustomer").classList.remove("d-none");
    mysetting.classList.add("d-none");

    document.getElementById("ServiceScheduleTable").classList.add("d-none");
    ServiceScheduleTable.style.background = "#1d7a8c";

    dashboard.style.background = "#1d7a8c";
    UpcomingService.style.background = "#1d7a8c";
    ServiceHistory.style.background = "#1d7a8c";
    MyRating.style.background = "#1d7a8c";
    document.getElementById("7").style.background = "#146371";

    getCompleteServiceUserList();
}
    function opensetting() {

    document.getElementById("Dashboard").classList.add("d-none");
    document.getElementById("UpcomingService").classList.add("d-none");
    document.getElementById("ServiceProviderHistory").classList.add("d-none");
        document.getElementById("serviceProviderCustomerRating").classList.add("d-none");
        document.getElementById("ServiceScheduleTable").classList.add("d-none");
        
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

if (urlSearchParams == "spUpcoming=true") {
    form3();
}

if (urlSearchParams == "spSchedule=true") {
    form4();
}
if (urlSearchParams == "spHistory=true") {
    form5();
}

if (urlSearchParams == "spRating=true") {
    form6();
}
if (urlSearchParams == "spBlockCustomer=true") {
    form7();
}

function getUserdata() {
        $.ajax(
            {
                type: 'GET',
                url: '/ServiceProvider/getUserDetails',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8', beforeSend: function () {
                    $("html").css("overflow", "hidden");
                    $(".lds-roller").css("display", "inline-block");
                    $(".overlayer").css("display", "block");

                },
                complete: function () {
                    setTimeout(function () {
                        $("html").css("overflow", "auto");

                        $(".lds-roller").css("display", "none");
                        $(".overlayer").css("display", "none");
                    }, 500);
                },
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
                            $(".gender").filter('[value="' + response.gender + '"]').attr('checked', true);
                        }
                        if (response["userAddresses"].length != 0) {
                            
                            $("#streetname").val(response["userAddresses"][0].addressLine2);
                            $("#housenumber").val(response["userAddresses"][0].addressLine1);
                            $("#postalcode").val(response["userAddresses"][0].postalCode);
                            $("#City").val(response["userAddresses"][0].city);
                            $("#State").val(response['userAddresses'][0].state);
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
        cache: false, beforeSend: function () {
            $("html").css("overflow", "hidden");
            $(".lds-roller").css("display", "inline-block");
            $(".overlayer").css("display", "block");

        },
        complete: function () {
            setTimeout(function () {
                $("html").css("overflow", "auto");

                $(".lds-roller").css("display", "none");
                $(".overlayer").css("display", "none");
            }, 500);
        },

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
                            data: data, beforeSend: function () {
                                $("html").css("overflow", "hidden");
                                $(".lds-roller").css("display", "inline-block");
                                $(".overlayer").css("display", "block");

                            },
                            complete: function () {
                                setTimeout(function () {
                                    $("html").css("overflow", "auto");

                                    $(".lds-roller").css("display", "none");
                                    $(".overlayer").css("display", "none");
                                }, 500);
                            },
                            success:
                                function (response) {
                                    if (response.value == "true") {

                                        $(".setting-details-alert").removeClass("d-none alert-danger").addClass("alert-success").text("successfully data is update!").fadeIn().fadeOut(7000);
                                        $(".setting-address-details-alert").addClass("d-none");

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
                data: data, beforeSend: function () {
                    $("html").css("overflow", "hidden");
                    $(".lds-roller").css("display", "inline-block");
                    $(".overlayer").css("display", "block");

                },
                complete: function () {
                    setTimeout(function () {
                        $("html").css("overflow", "auto");

                        $(".lds-roller").css("display", "none");
                        $(".overlayer").css("display", "none");
                    }, 500);
                },
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







$("#mytable1").click((e) => {
 
    var btnClass = e.target.classList;
   var service_request_id = e.target.closest('tr').getAttribute("data-value");

    if (service_request_id != null && !Object.values(btnClass).includes("accept-btn")) {
        console.log($(".conflict-btn").attr("data-value"));
        if (e.target.closest('tr').getAttribute("conflict-value") == 0) {
            $(".btn-box").removeClass("d-none");
        } else {
            $(".btn-box").addClass("d-none");
        }
        $(".btn-box1").addClass("d-none");
        $("#AcceptModalbtn").attr("data-value", service_request_id);
        document.getElementById("CustomerServiceSummery-btn").click();
        console.log(service_request_id);
        getServiceRequestAllDetails(service_request_id);

    }

    console.log(Object.values(btnClass).includes("AcceptServiceBtn"));
    if (Object.values(btnClass).includes("AcceptServiceBtn")) {
        AcceptService(e.target.dataset.value);
    }

    if (Object.values(btnClass).includes("conflict-btn")) {
   
        console.log(e.target.dataset.value);
        $(".btn-box").addClass("d-none");
        $(".btn-box1").addClass("d-none");
        document.getElementById("CustomerServiceSummery-btn").click();
        getServiceRequestAllDetails(e.target.dataset.value);
    }


});



$("#mytable5").click((e) => {

    var btnClass = e.target.classList;
   
    if (Object.values(btnClass).includes("block-btn")) {
       
        blockCustomer(e.target.dataset.value);
    }



});

function blockCustomer(id) {
    
    var data = {};
    data.userIdTo= id;
    $.ajax(
        {
            type: 'POST',
            url: '/ServiceProvider/BlockCustomer',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data, beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response.value == "true") {
                        getCompleteServiceUserList();
                      
                    }

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });



}



$("#AcceptModalbtn").click(() => {
    AcceptService($("#AcceptModalbtn").attr("data-value"));
});


function AcceptService(serviceRequestId) {
    var data = {};
    data.serviceRequestId = serviceRequestId;
    $.ajax(
        {
            type: 'POST',
            url: '/ServiceProvider/AcceptServiceRequest',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data, beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response.value == "true") {
                      
                        $("#successId").text("Accepted service id:- " + serviceRequestId);
                        $("#SuccessModal").modal("show");
                    }

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

}




var map = L.map("issMap");

async function getlon_len(zipcode) {
  
   
    map.setView([0, 0], 1);
    const attribution = '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors';
    const tileUrl = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
    const tiles = L.tileLayer(tileUrl, { attribution });
    tiles.addTo(map);
    const response = await fetch('https://nominatim.openstreetmap.org/search?format=json&limit=1&q=india,' + zipcode);
    const data = await response.json();
    const { lat, lon } = data[0];
    map.flyTo([lat, lon], 15);
    L.marker([lat, lon]).addTo(map);
   

}


function getServiceRequestAllDetails(service_request_id) {

    var data = {};
    data.serviceRequestId = service_request_id;
    $.ajax(
        {
            type: 'GET',
            url: '/ServiceProvider/showServiceRequestSummery',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data, beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response != null) {
                        
                        
                        
                        $("#serviceRequestDateTime").text(response.date + " " + response.startTime + " - " + response.endTime);
                        $("#serviceRequestDuration").text(response.duration + " Hrs");
                        $("#ServiceRequestId").text(response.serviceRequestId);
                        $("#ServiceCustomerName").text(response.serviceProviderName);

                        var now = new Date();
                        
                       
                        console.log("now :- " + now);
                        var date = response.date.split("/")[2] + "/" + response.date.split("/")[1] + "/" + response.date.split("/")[0];
                        var endTime = new Date(date +" "+ response.endTime);
                        if (now >= endTime) {
                            $("#CompleteModalbtn").removeClass("d-none");
                        } else {
                            $("#CompleteModalbtn").addClass("d-none");
                        }
                        
                        if (response.hasPets == true) {
                            $(".havenot-pets").addClass("d-none");
                            $(".have-pets").removeClass("d-none");
                        } else {
                            $(".havenot-pets").removeClass("d-none");
                            $(".have-pets").addClass("d-none");
                        }
                        if (response.cabinet == true) {
                            $("#serviceExtra1").removeClass("d-none");
                        } else {
                            $("#serviceExtra1").addClass("d-none");
                        }
                        if (response.oven == true) {
                            $("#serviceExtra2").removeClass("d-none");
                        } else {
                            $("#serviceExtra2").addClass("d-none");
                        }
                        if (response.fridge == true) {
                            $("#serviceExtra3").removeClass("d-none");
                        } else {
                            $("#serviceExtra3").addClass("d-none");
                        }
                        if (response.laundry == true) {
                            $("#serviceExtra4").removeClass("d-none");
                        } else {
                            $("#serviceExtra4").addClass("d-none");
                        }
                        if (response.window == true) {
                            $("#serviceExtra5").removeClass("d-none");
                        } else {
                            $("#serviceExtra5").addClass("d-none");
                        }

                        $(".netAmountNo").html(response.totalCost + " &#8364;");
                        $("#serviceRequestAddress").text(response.address);
                        $("#ServiceRequestPhone").text(response.phoneNo);
                        $("#ServiceRequestEmail").text(response.email);

                        if (response.serviceProviderName != null) {
                            $("#ServiceProviderName").text(response.serviceProviderName);
                            $("#ServiceProviderRating").text(response.serviceProviderRating);
                            $(".service-request-provider-box").removeClass("d-none");
                            $(".serivce-request-summary-box").removeClass("d-block").addClass("d-flex");
                        } else {
                            $(".service-request-provider-box").addClass("d-none");
                            $(".serivce-request-summary-box").addClass("d-block").removeClass("d-flex");

                        }
                        
                        getlon_len(response.postalCode);
                    }




                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });



}

$("#CompleteModalbtn").click((e) => {

    CompleteService(e.target.dataset.value);

});



function CompleteService(id) {
    var data = {};
    data.serviceRequestId = id;


    $.ajax(
        {
            type: 'POST',
            url: '/ServiceProvider/CompleteService',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data, beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response.value == "true") {
                        $("#successId").text("completed  service id:- " + id);
                        $("#SuccessModal").modal("show");
                       

                    }

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });


}

function getUpcomingService() {

    
    $.ajax(
        {
            type: 'GET',
            url: '/ServiceProvider/GetUpcomingService',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8', beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response != null) {
                        console.log(response);
                        $("#UpcomingServiceTboady").empty();
                        for (var i = 0; i < response.length; i++) {

                            var now = new Date();


                            console.log("now :- " + now);
                            var date = response[i].serviceStartDate.split("/")[2] + "/" + response[i].serviceStartDate.split("/")[1] + "/" + response[i].serviceStartDate.split("/")[0];
                            var endTime = new Date(date + " " + response[i].endTime);
                            var completeButton = '';
                            if (now >= endTime) {
                                completeButton = '<button  class="complete-btn" data-value="' + response[i].serviceRequestId + '">Compeleted</button>';
                            } 

                            $("#UpcomingServiceTboady").append('<tr data-value="' + response[i].serviceRequestId + '"><td>' + response[i].serviceRequestId + '</td ><td><img src="/image/calendar2.png" alt="calendar" /><strong> ' + response[i].serviceStartDate + '</strong><span><img src="/image/layer-14.png" alt="" /> ' + response[i].startTime + ' - ' + response[i].endTime + '</span></td><td><div class="address-td-box"><div style="width: fit-content"><img src="/image/layer-15.png" alt="cap" /></div><div><span>' + response[i].customerName + '</span><span>' + response[i].customerAddress1 + '</span><span>' + response[i].customerAddress2 + '</span></div></div></td><td><span class="payment-td">&#8364;' + response[i].totalCost + '</span></td><td></td><td><div class="upcomingBtnBox">' + completeButton + '<button class="cancel-btn" data-value="' + response[i].serviceRequestId + '">cancel</button></div></td></tr >');
                        }
                        const table2 = new DataTable("#mytable2", {
                            dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
                            responsive: true,
                            retrieve: true,
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
                    }



                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });




}

document.getElementById("mytable2").addEventListener("click", (e) => {



    var btnClass = e.target.classList;
    var service_request_id = e.target.closest('tr').getAttribute("data-value");

    if (service_request_id != null && !Object.values(btnClass).includes("complete-btn") && !Object.values(btnClass).includes("cancel-btn")) {
        console.log($(".conflict-btn").attr("data-value"));

        $(".btn-box").addClass("d-none");
        $(".btn-box1").removeClass("d-none");

        $("#CancelServiceModalbtn").attr("data-value", service_request_id);
        $("#CompleteModalbtn").attr("data-value", service_request_id);
        document.getElementById("CustomerServiceSummery-btn").click();
        console.log(service_request_id);
        getServiceRequestAllDetails(service_request_id);

    }


    if (e.target.className == "cancel-btn") {
        RejectService(e.target.dataset.value);
    }

    if (e.target.className == "complete-btn") {
        CompleteService(e.target.dataset.value);
    }

});

$("#CancelServiceModalbtn").click((e) => {

    RejectService(e.target.dataset.value);
    
});


document.getElementById("mytable3").addEventListener("click", (e) => {



  
    var service_request_id = e.target.closest('tr').getAttribute("data-value");

    if (service_request_id != null) {
       

        $(".btn-box").addClass("d-none");
        $(".btn-box1").addClass("d-none");
        $("#AcceptModalbtn").attr("data-value", service_request_id);
        document.getElementById("CustomerServiceSummery-btn").click();
        console.log(service_request_id);
        getServiceRequestAllDetails(service_request_id);

    }



});



function RejectService(id) {
    var data = {};
    data.serviceRequestId = id;

   
    $.ajax(
        {
            type: 'POST',
            url: '/ServiceProvider/RejectService',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data, beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response.value == "true") {
                        $("#successId").text("successfully cancel service id:- " + id);
                        $("#SuccessModal").modal("show");
                      
                      
                    }

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });




}


$("#SuccessDoneBtn").click(() => {

    window.location.reload();
});



function getServiceHistory() {


    $.ajax(
        {
            type: 'GET',
            url: '/ServiceProvider/GetServiceHistory',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8', beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response != null) {
                        console.log(response);
                        $("#ServiceProviderHistoryTbody").empty();
                        for (var i = 0; i < response.length; i++) {

                            $("#ServiceProviderHistoryTbody").append('<tr data-value="' + response[i].serviceRequestId + '"><td>' + response[i].serviceRequestId + '</td ><td><img src="/image/calendar2.png" alt="calendar" /><strong> ' + response[i].serviceStartDate + '</strong><span><img src="/image/layer-14.png" alt="" /> ' + response[i].startTime + ' - ' + response[i].endTime + '</span></td><td><div class="address-td-box"><div style="width: fit-content"><img src="/image/layer-15.png" alt="cap" /></div><div><span>' + response[i].customerName + '</span><span>' + response[i].customerAddress1 + '</span><span>' + response[i].customerAddress2 + '</span></div></div></td>');
                        }
                        const table3 = new DataTable("#mytable3", {
                            dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
                            responsive: true,
                            retrieve: true,
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
                            columnDefs: [{ orderable: false, targets: 2 }],
                        });
                    }



                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });




}



function getServiceProviderRating() {


    $.ajax(
        {
            type: 'GET',
            url: '/ServiceProvider/GetRatingOfServiceProvider',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8', beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response != null) {
                        console.log(response);
                        $("#mytable4 tbody").empty();
                        for (var i = 0; i < response.length; i++) {

                            $("#mytable4 tbody").append(`<tr>
                    <td>
                        <p>`+ response[i].serviceRequestId + `</p>
                        <p>`+ response[i].customerName +`</p>
                    </td>
                    <td>
                        <img src="/image/calendar2.png" alt="date"><strong>
                             `+ response[i].serviceStartDate +`
                        </strong>
                        <p><img src="/image/layer-14.png" alt="time"> `+ response[i].startTime + ` - ` + response[i].endTime +`</p>
                    </td>
                    <td>


                        <div>
                            <div><span>Rating</span></div>
                            <div class="d-flex align-items-center ">
                                <div class="average-rating" id="spratingId`+ response[i].serviceRequestId +`">
                                    <span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span>
                                </div>
                                <div style="padding-top: 4px; padding-left: 3px">
                                    <span>Very Good</span>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td>
                        <p>`+(response[i].comments?response[i].comments:"")+`</p>
                    </td>
                </tr>`);
                            showRating(response[i].spRatings, "#spratingId" + response[i].serviceRequestId);
                        }
                        const table4 = new DataTable("#mytable4", {
                            dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
                            responsive: true,
                            retrieve: true,
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
                            columnDefs: [{ orderable: false, targets: 3 }],
                        });
                    }



                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });




}





function showRating(rating, id) {

    var rate = Math.ceil(rating * 2);
    var star = document.querySelector(id);
    var colorStart = star.querySelectorAll(".half-star");
    console.log(colorStart);
    colorStart.forEach((item) => {
        item.classList.add("half-start");
    });

    for (var i = rate; i < 10; i++) {
        colorStart[i].classList.remove("half-start");
    }




}



function html_table_to_excel(type,id) {
    var data = document.getElementById(id);

    var file = XLSX.utils.table_to_book(data, { sheet: "sheet1" });

    XLSX.write(file, { bookType: type, bookSST: true, type: "base64" });

    XLSX.writeFile(file, "file." + type);
}

const export_button = document.getElementById("export");

export_button.addEventListener("click", () => {
    html_table_to_excel("xlsx","mytable2");
});


document.getElementById("export1").addEventListener("click", () => {

    html_table_to_excel("xlsx", "mytable4");
});








function getCompleteServiceUserList() {


    $.ajax(
        {
            type: 'GET',
            url: '/ServiceProvider/GetCompleteServiceUserList',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8', beforeSend: function () {
                $("html").css("overflow", "hidden");
                $(".lds-roller").css("display", "inline-block");
                $(".overlayer").css("display", "block");

            },
            complete: function () {
                setTimeout(function () {
                    $("html").css("overflow", "auto");

                    $(".lds-roller").css("display", "none");
                    $(".overlayer").css("display", "none");
                }, 500);
            },
            success:
                function (response) {
                    if (response != null) {
                        console.table(response);
                        
                        $("#mytable5 tbody").empty();
                        for (var i = 0; i < response.length; i++) {
                            var block_btn = ' <button  class="block-btn " data-value="' + response[i].userIdTo + '">Block</button>';
                            if (response[i].isBlock == true) {
                                block_btn = ` <button class="block-btn " data-value="` + response[i].userIdTo + `">Unblock</button>`;
                            }

                            $("#mytable5 tbody").append(` <tr class="block">
                <td>
                    <div><img class="cap-icon cap-upgrade" src="/image/cap.jpg" alt="cap"></div>
                </td>
                <td>
                    <div class="block-icon">
                        <p>`+response[i].customerName+`</p>
                    </div>
                </td>
                <td>
                    `+block_btn+`
                </td>
            </tr>`)
                        }
                    }
                    const table5 = new DataTable("#mytable5", {
                        dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
                        responsive: true,
                        retrieve:true,
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
                        columnDefs: [{ orderable: false, targets: 2 }],
                    });


                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });




}




