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
    "order": [0, 'desc'],
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
var serviceTimeTable = document.getElementById("3");
var blockfav = document.getElementById("4");

function form1() {
    document.getElementById("Dashboard").style.display = "block";
    document.getElementById("ServiceHistory").style.display = "none";
    document.getElementById("ServiceScheduleTable").classList.add("d-none");

    dashboard.style.background = "#146371";
    serviceRequest.style.background = "#1d7a8c";
    blockfav.style.background = "#1d7a8c";
    document.getElementById("blockCustomer").classList.add("d-none");

    document.getElementsByClassName("my-setting-box")[0].classList.add("d-none");
    document.getElementsByClassName("contant-right")[0].classList.remove("d-none");
    var url = new URL(window.location.href);
    url.search = "";
    window.location.replace(url.toString());
  
   
}

function form2() {
    document.getElementById("Dashboard").style.display = "none";
    document.getElementById("ServiceHistory").style.display = "block";
    document.getElementById("ServiceScheduleTable").classList.add("d-none");
    dashboard.style.background = "#1d7a8c";
    serviceRequest.style.background = "#146371";
    serviceTimeTable.style.background = "#1d7a8c";
    document.getElementsByClassName("my-setting-box")[0].classList.add("d-none");
    document.getElementsByClassName("contant-right")[0].classList.remove("d-none");
    blockfav.style.background = "#1d7a8c";
    document.getElementById("blockCustomer").classList.add("d-none");
    getServiceHistory();
}


function form3() {
    document.getElementById("Dashboard").style.display = "none";
    document.getElementById("ServiceHistory").style.display = "none";
    document.getElementById("ServiceScheduleTable").classList.remove("d-none");
    document.getElementsByClassName("contant-right")[0].classList.add("d-none");
    document.getElementsByClassName("my-setting-box")[0].classList.add("d-none");
    dashboard.style.background = "#1d7a8c";
    serviceRequest.style.background = "#1d7a8c";
    serviceTimeTable.style.background = "#146371";
    blockfav.style.background = "#1d7a8c";
    document.getElementById("blockCustomer").classList.add("d-none");
    timeTableData();
}


function form4() {
    document.getElementById("Dashboard").style.display = "none";
    document.getElementById("ServiceHistory").style.display = "none";
    document.getElementById("ServiceScheduleTable").classList.add("d-none");
    serviceTimeTable.style.background = "#1d7a8c";
    dashboard.style.background = "#1d7a8c";
    serviceRequest.style.background = "#1d7a8c";
    blockfav.style.background = "#146371";
    document.getElementById("blockCustomer").classList.remove("d-none");

    document.getElementsByClassName("my-setting-box")[0].classList.add("d-none");
    document.getElementsByClassName("contant-right")[0].classList.remove("d-none");


    getFavBlockDetails();
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

    dashboard.style.background = "#1d7a8c";
    serviceRequest.style.background = "#1d7a8c";

    my_user_details.classList.remove("d-none");
    my_user_address.classList.add("d-none");
    my_user_change_password.classList.add("d-none");

    my_user_option_icon[0].style.stroke = "#146371";
    my_user_option_icon[1].style.stroke = "#646464";
    my_user_option_icon[2].style.stroke = "#646464";
    getUserdata();
});

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


function my_user_setting() {

    document.getElementsByClassName("my-setting-box")[0].classList.remove("d-none");
    document.getElementsByClassName("contant-right")[0].classList.add("d-none");
    document.getElementById("ServiceScheduleTable").classList.add("d-none");

    getUserdata();



}

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


var calendarEl = document.getElementById('calendar');
var calendar;

function timeTableData() {

    $.ajax({
        type: "GET",
        url: '/Customer/GetDataForCalendar',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
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
        dataType: 'json',

        success: function (doc) {

            if (doc != "false") {
                var events = [];
                console.log(doc);
                for (var i = 0; i < doc.length; i++) {
                    var newDate = `${doc[i].serviceStartDate.split("/")[2]}-${doc[i].serviceStartDate.split("/")[1]}-${doc[i].serviceStartDate.split("/")[0]}`;
                
                    var labelColor = '#555';
                    if (doc[i].status == 0) {
                        labelColor = '#146371';
                    }
                  
                    events.push({
                        id: doc[i].serviceRequestId,
                        start: newDate,
                        title: doc[i].startTime + " - " + doc[i].endTime,
                        backgroundColor: labelColor,
                        borderColor: "#fff",
                        classNames: "work-label"
                    });
                }

                console.log(events);

            }


            calendar = new FullCalendar.Calendar(calendarEl, {
                eventClick: function (info) {
                    $(".btn-box").addClass("d-none");
                    $(".btn-box1").removeClass("d-none");

                    
                    document.getElementById("CustomerServiceSummery-btn").click();
                    console.log(info.event.id);
                    getServiceRequestAllDetails(info.event.id);
                },
                events: events,
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




function showUserAddress() {

    $.ajax(
        {
            type: 'GET',
            url: '/Customer/getAllAddressDetails',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            beforeSend:function () {
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
                    var list = $("#UserAddressList");
                    list.empty();

                    for (var i = 0; i < response.length; i++) {

                        list.append('<tr> <td class= "user-address-list" > <p><strong>Address : </strong>' + response[i].addressLine2 + '-' + response[i].addressLine1 + ', ' + response[i].city + ' </p > <p><strong>Phone number</strong> ' + response[i].mobile + ' </p> </td ><td><div class="user-address-btn"><a class="updateAddress" data-bs-toggle="modal" data-bs-target="#updateUserAddress"   data-value="' + response[i].id+'" > <svg xmlns="http://www.w3.org/2000/svg" class="edit-icon" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path></svg>   </a > <a data-bs-toggle="modal" data-bs-target="#staticBackdrop4" class="delete-user-address" data-value="' + response[i].id+'" > <svg xmlns="http://www.w3.org/2000/svg" class="delete-icon" fill="none" viewBox="0 0 24 24" stroke="currentColor"> <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path>  </svg> </a > </div ></td > <div></div></tr > ');

                    }

                    showMoreAddress();
    



            

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

}

function getUserdata() {
    $.ajax(
        {
            type: 'GET',
            url: '/Customer/getUserDetails',
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
                    console.table(response);
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



function updateUserData() {
    var data = {};

   

    data.firstName = $("#firstname").val();
    data.lastName = $("#lastname").val();
    data.mobile = $("#mobile").val();
    var numbers = /^[0-9]+$/.test(data.mobile);
    data.dateOfBirth = $(".month").val() + "/" + $(".day").val() + "/" + $(".year").val();
    if (data.firstName == "" && data.lastName == "" && data.mobile == "") {
        $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid value").fadeIn().fadeOut(2000);
    } else if (data.firstName == "") {
        $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid First Name").fadeIn().fadeOut(2000);
    }
    else
        if (data.lastName == "") {
            $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid Last Name").fadeIn().fadeOut(2000);
        } else

            if (data.mobile == "" || !numbers) {
                $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("please enter valid moblie number").fadeIn().fadeOut(2000);
            }
            else {
                $.ajax(
                    {
                        type: 'POST',
                        url: '/Customer/updateUserDetails',
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

                                    $(".setting-details-alert").removeClass("d-none alert-danger").addClass("alert-success").text("successfully data is update!").fadeIn().fadeOut(2000);
                                   
                                    getUserdata();
                                } else if (response.value == "mobileThere") {
                                    $(".setting-details-alert").addClass("alert-danger").removeClass("d-none").text("mobile number already exist please use different number").fadeIn().fadeOut(2000);
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

if (urlSearchParams == "SSchedule=true") {
    form3();
}
if (urlSearchParams == "Shistory=true") {
    form2();
}
if (urlSearchParams == "favPro=true") {
    form4();
}


if (urlSearchParams == "customerSetting=true") {
    my_user_setting();
}

var address_user_id = 0;
var service_request_id = 0;

document.addEventListener("click", (e) => {

    if (e.target.className == "cancel-btn") {
        console.log(e.target.className);
        document.getElementById("cancelId").value = e.target.value;
    }

    if (e.target.className == "reschedule-btn") {
        document.getElementById("rescheduleID").value = e.target.value;
        getscheduleDataTime(e.target.value);

    }
    var address_id = e.target.closest('a');
    if (address_id != null) {
        if (address_id.className == "delete-user-address") {
            address_user_id=address_id.getAttribute('data-value');
        }
        if (address_id.className == "updateAddress") {

            address_user_id = address_id.getAttribute('data-value');
            getAddressField();
            console.log("class :" + address_id.className + ". " + " value: " + address_user_id);
        }

    }

});


function getscheduleDataTime(id) {
    var data = {};
    data.serviceRequestId = id;
    $.ajax(
        {
            type: 'GET',
            url: '/Customer/getscheduleDataTime',
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

                        var dateTime = response.split("T");
                        var now = new Date(new Date().getTime() + 24 * 60 * 60 * 1000).toISOString().slice(0, 10);
                        $("#rescheduledate").attr("min", now);
                        $("#rescheduledate").val(dateTime[0]);
                        $("#rescheduletime").val(dateTime[1]);

                    }


                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

    

}

document.getElementById("Updatepostalcode").addEventListener("focusout", () => {

    var zip = $("#Updatepostalcode").val();
    if (zip.length == 6) {
        getZipcodeCity(zip, "Updatecity", "UpdateState", "user-address-update-btn");
    } else {
        $(".addAddress-error").removeClass("d-none").text("please enter valid postalcode!").fadeIn().fadeOut(2000);

    }

});
document.getElementById("postalcode").addEventListener("focusout", () => {

    var zip = $("#postalcode").val();
    if (zip.length == 6) {
        getZipcodeCity(zip, "city", "State","user-address-add-btn");
    }
    else {
        $(".addAddress-error").removeClass("d-none").text("please enter valid postalcode!").fadeIn().fadeOut(2000);

    }

});

function getZipcodeCity(zipcode,tagidcity,tagidstate,tagiderror) {
   

    $.ajax({
        url: "https://api.postalpincode.in/pincode/" + zipcode,
        method: "GET",
        dataType: "json",
        cache: false, beforeSend: function () {
            $("html").css("overflow", "hidden");
            $(".lds-roller").css("display", "inline-block");
            $(".overlayer").css("display", "block");
            $(".user-address-update-btn ").addClass("btn disabled");

        },
        complete: function () {
            setTimeout(function () {
                $("html").css("overflow", "auto");

                $(".lds-roller").css("display", "none");
                $(".overlayer").css("display", "none");
                $(".user-address-update-btn ").removeClass("btn disabled");
            }, 500);
        },
       
        success: (data) => {

            console.log(data);
            if (data[0].Status == "Error") {
                console.log("err");
                $(".addAddress-error").removeClass("d-none").text("please enter valid postalcode!").fadeIn().fadeOut(2000);
             
                $("#" + tagidcity).val("");


            } else if (data[0].Status == "Success") {
                $("#" + tagidcity).val(data[0].PostOffice[0].District);
                $("#" + tagidstate).val(data[0].PostOffice[0].State);
                $(".addAddress-error").addClass("d-none");
                $("." + tagiderror).removeClass("btn disabled");

            }
        }, 
        error: (err) => {
            console.log(err);
        }

    });

}



function getAddressField() {
    var data = {};
    data.addressId = address_user_id;

    $.ajax(
        {
            type: 'GET',
            url: '/Customer/getAddressFieldData',
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

                        console.table(response);

                        $("#Updatestreetname").val(response.addressLine2);
                        $("#Updatehousenumber").val(response.addressLine1);
                        $("#Updatepostalcode").val(response.postalCode);
                        $("#Updatecity").val(response.city);
                        $("#UpdateMobile").val(response.mobile);
                        $("#UpdateState").val(response.state);
                    }


                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });
}


$("#mytable1").click((e) => {

    service_request_id = e.target.closest('tr').getAttribute("data-value");

    if (service_request_id != null && (e.target.className != "cancel-btn" && e.target.className != "reschedule-btn")) {
        $(".btn-box").removeClass("d-none");
        document.getElementById("CustomerServiceSummery-btn").click();
        $("#rescheduleID").val(service_request_id);
        console.log(service_request_id);
        getServiceRequestAllDetails(service_request_id);
       
    }

  

});


$("#mytable2").click((e) => {

    service_request_id = e.target.closest('tr').getAttribute("data-value");

    if (service_request_id != null && (e.target.className != "rateSP-btn")) {
        $(".btn-box").addClass("d-none");
        document.getElementById("CustomerServiceSummery-btn").click();
        console.log(service_request_id);
        getServiceRequestAllDetails(service_request_id);

    } 

    if (e.target.className == "rateSP-btn") {
        var name = $("#serviceproviderId" + service_request_id + " .spName").text();
        var sprate = $("#serviceproviderId" + service_request_id + " .sprating").text();
        console.log(sprate);
        $(".service-provider-average-rating .RatingspName").text(name);
        $(".service-provider-average-rating .Ratingsprating").text(sprate);
        showRating(sprate,".average-rating-modal");
    }

});



function getServiceRequestAllDetails(id) {

    var data = {};
    data.serviceRequestId = id;
    $.ajax(
        {
            type: 'GET',
            url: '/Customer/showServiceRequestSummery',
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
                    if (response!=null) {
                        console.log(response);
                        $("#serviceRequestDateTime").text(response.date + " " + response.startTime + " - " + response.endTime);
                        $("#serviceRequestDuration").text(response.duration + " Hrs");
                        $("#ServiceRequestId").text(response.serviceRequestId);
                        $("#SerivceProviderCleaning").text(response.serviceProviderCleaning);
                        $(".Reschedule-btn").attr("value", response.serviceRequestId);
                        $(".Cancel-btn").attr("value", response.serviceRequestId);
                        console.log(response.hasPets);
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
                        if (response.serviceProviderName != null) {
                            showRating(response.serviceProviderRating, ".summaryrating");
                        }
                    }

                    


                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

}


$(".Reschedule-btn").click((e) => {

    getscheduleDataTime(e.target.value);

});

$(".Cancel-btn").click((e) => {

    document.getElementById("cancelId").value = e.target.value;

});

function deleteUserAddress() {
    var data = {};
    data.addressId = parseInt(address_user_id);
    console.log(address_user_id);

    $.ajax(
        {
            type: 'POST',
            url: '/Customer/deleteUserAddress',
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

                        $(".setting-address-details-alert").addClass("alert-success").removeClass("alert-danger d-none").text("successfully remove Address").fadeIn().fadeOut(2000);
                        showUserAddress();
                    }


                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

    
}


$(".delete-btn").click(() => {
    deleteUserAddress();
});


document.getElementById("rescheduleServiceRequestID").addEventListener("click", () => {


    console.log("date :- " + document.getElementById("rescheduledate").value);
    console.log("time :- " + document.getElementById("rescheduletime").value);

    var data = {}
    data.serviceRequestId = document.getElementById("rescheduleID").value;
    data.serviceStartDate = document.getElementById("rescheduledate").value;
    data.startTime = document.getElementById("rescheduletime").value;
    console.log(data);

    if (data.serviceStartDate == "") {
        $(".Reschedule-alert").addClass("alert-danger").removeClass("alert-success d-none").text("please enter date!");
       
    } else if (data.startTime == "") {
        $(".Reschedule-alert").addClass("alert-danger").removeClass("alert-success d-none").text("please enter time!");
       
    } else {
        $.ajax(
            {
                type: 'POST',
                url: '/Customer/UpdateServiceRequest',
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
                            $(".Reschedule-alert").addClass("d-none");
                            $(".updateTimeModal ").modal('hide');
                            $("#successId").text("successfully reschedule service id:- " + data.serviceRequestId);
                            $("#SuccessModal").modal("show");
                        }
                        else if (response.value == "conflict") {
                            $(".Reschedule-alert").addClass("alert-danger").removeClass("alert-success d-none").text("Service provider already book on this date and time!");
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
                        $("#successId").text("successfully cancel service id:- " + data.serviceRequestId);
                        $("#SuccessModal").modal('show');


                    }


                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });



});

$("#SuccessDoneBtn").click(() => {
    window.location.reload();
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
    if ($("#currentPassword").val() == "" || $("#NewPassword").val() == "" || $("#confirmPassword").val() == "") {
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




$(".user-address-add-btn").click(() => {
    var data = {};
    data.addressLine1 = $("#housenumber").val();
    data.addressLine2 = $("#streetname").val();
    data.postalCode = $("#postalcode").val();
    data.city = $("#city").val();
    data.mobile = $("#Mobile").val();
    data.state = $("#State").val();
    var numbers = /^[0-9]+$/.test(data.mobile);
    console.log(data);
    var flag = 1;
    if (data.addressLine1 == "" && data.addressLine2 == "" && data.mobile == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value!").fadeIn().fadeOut(2000);
       
        flag = 0;
    }
    else if (data.addressLine1 == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of house!").fadeIn().fadeOut(2000);
        
        flag = 0;
    } else if (data.addressLine2 == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of street!").fadeIn().fadeOut(2000);
       
        flag = 0;
    } else if (data.mobile == "" || !numbers) {
        $(".addAddress-error").removeClass("d-none").text("please enter valid value of mobile!").fadeIn().fadeOut(2000);
      
        flag = 0;
    } else if (data.postalCode.length < 6 || data.postalCode=="") {
        $(".addAddress-error").removeClass("d-none").text("please enter valid postalCode!").fadeIn().fadeOut(2000);

        flag = 0;
    }
    else {
        $('#staticBackdrop3').modal('hide');
        $(".addAddress-error").addClass("d-none").fadeIn().fadeOut(2000);
        flag = 1;
    }

    if (flag == 1) {
        $.ajax(
            {
                type: 'POST',
                url: '/Customer/UserAddAddress',
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
                            showUserAddress();
                            $(".setting-address-details-alert").addClass("alert-success").removeClass("alert-danger d-none").text("successfully add Address!").fadeIn().fadeOut(2000);
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





$(".user-address-update-btn").click(() => {

    var data = {};
    data.addressId = address_user_id;
    data.addressLine1 = $("#Updatehousenumber").val();
    data.addressLine2 = $("#Updatestreetname").val();
    data.postalCode = $("#Updatepostalcode").val();
    data.city = $("#Updatecity").val();
    data.mobile = $("#UpdateMobile").val();
    data.state = $("#UpdateState").val();
    var numbers = /^[0-9]+$/.test(data.mobile);
    console.log(data);
    var flag = 1;
    if (data.addressLine1 == "" && data.addressLine2 == "" && data.mobile == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value!").fadeIn().fadeOut(2000);
      
        flag = 0;
    }
    else if (data.addressLine1 == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of house!").fadeIn().fadeOut(2000);
       
        flag = 0;
    } else if (data.addressLine2 == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of street!").fadeIn().fadeOut(2000);
     
        flag = 0;
    } else if (data.mobile == "" || !numbers) {
        $(".addAddress-error").removeClass("d-none").text("please enter valid value of mobile!").fadeIn().fadeOut(2000);

        flag = 0;
    } else if (data.postalCode.length < 6 || data.postalCode == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter valid postalcodes!").fadeIn().fadeOut(2000);
        flag = 0;

    }
    else {
      
        $('#updateUserAddress').modal('hide');
        $(".addAddress-error").addClass("d-none").fadeIn().fadeOut(2000);
            flag = 1;
    }

    if (flag == 1) {
        $.ajax(
            {
                type: 'POST',
                url: '/Customer/UserUpdateAddress',
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
                            showUserAddress();
                            $(".setting-address-details-alert").addClass("alert-success").removeClass("alert-danger d-none").text("successfully add Address!").fadeIn().fadeOut(2000);
                           
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

function getServiceHistory() {

    $.ajax(
        {
            type: 'GET',
            url: '/Customer/ServiceHistory',
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
                    if (response!=null) {
                        console.table(response);
                        $("#CustomerServiceHistoryTable").empty();
                        for (var i = 0; i < response.length; i++) {
                            var sp = "";
                            var Ratesp = "";
                            var customerStatus = "";
                            if (response[i].status == 0) {
                                if (response[i].alreadyRated == false) {
                                    Ratesp = '<button  class="rateSP-btn" data-bs-toggle="modal" data-bs-target="#myRatingModal">Rate SP</button>';
                                } else {
                                    Ratesp = '<button  class="rateSP-btn btn disabled" data-bs-toggle="modal" data-bs-target="#myRatingModal">Rate SP</button>';
                                }
                                
                                customerStatus = '<span class="completed-label">Completed</span>';
                             
                            } else if (response[i].status == 1) {
                                customerStatus = '<span class="cancel-label">Canceled</span>';
                                Ratesp = '<button  class="rateSP-btn btn disabled" data-bs-toggle="modal" data-bs-target="#myRatingModal">Rate SP</button>';
                            }
                            if (response[i].serviceProvider != null) {

                                sp = ' <div class="service-provider-average-rating" id="serviceproviderId' + response[i].serviceRequestId + '"><div><img class="cap-icon" src="/image/cap.png" alt="cap" /></div ><div><div><span class="spName">' + response[i].serviceProvider + '</span></div><div class="d-flex align-items-center"><div class="average-rating" id="spratingId' + response[i].serviceRequestId + '"><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span><span class=" half-star"></span></div><div style="padding-top: 4px; padding-left: 3px"><span class="sprating">' + response[i].spRatings + '</span></div></div></div></div>';
                                
                            } 

                            $("#CustomerServiceHistoryTable").append('<tr data-value="' + response[i].serviceRequestId + '"><td class="dtr-control sorting_1" tabindex="0">' + response[i].serviceRequestId + '</td> <td> <img src="/image/calendar.png" alt="calendar"><strong> ' + response[i].serviceStartDate + '</strong ><span> <img src="/image/layer-712.png" alt=""> ' + response[i].startTime + ' - ' + response[i].endTime + '</span> </td><td>' + sp + '</td><td><span class="payment-td">€<strong style="font-size: 24px">' + response[i].totalCost + '</strong></span></td><td>' + customerStatus + '</td><td>' + Ratesp + '</td> </tr>');

                            if (response[i].serviceProvider != null) {
                                showRating(response[i].spRatings, "#spratingId"+response[i].serviceRequestId);
                            }
                           

                        }

                        $("#mytable2").DataTable({
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




$("#ServiceProviderRatingBtn").click(() => {

    var data = {};
    data.onTimeArrival = $("#OnTimeArrival input:checked").val();
    data.friendly = $("#friendly input:checked").val();
    data.qualityOfService = $("#qualityOfService input:checked").val();
    data.ratings = (parseFloat(data.onTimeArrival) + parseFloat(data.friendly) + parseFloat(data.qualityOfService)) / 3;
    data.serviceRequestId = service_request_id;
    data.comments = $("#feedback-label").val();



    $.ajax(
        {
            type: 'POST',
            url: '/Customer/addServiceProviderRating',
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
                        getServiceHistory();

                    }
                    else {
                        alert("not well");
                    }
                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

});

var numShown = 5;


function showMoreAddress() {
  
   
    numShown = 5;

    var $table = $(".my-addresses-table").find('tbody');
    var numRows = $table.find('tr').length;
    console.log("numrows :- " + numRows);
    if (numShown > numRows) {
        numShown = numRows;
    }
    $table.find('tr:gt(' + (numShown - 1) + ')').hide();

    $("#shownRow").text(numShown);
    $("#totalRow").text(numRows);
}

$(".user-show-address-btn").click(function () {

    numShown += 5;

    var $table = $(".my-addresses-table").find('tbody');
    var numRows = $table.find('tr').length;

    console.log(numShown);

    if (numShown > numRows) {
        numShown = numRows;
    }

    $("#shownRow").text(numShown);
    $table.find('tr:lt(' + numShown + ')').show();
});


function showRating(rating,id) {
  
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



function getFavBlockDetails() {

    $.ajax(
        {
            type: 'GET',
            url: '/Customer/GetCompleteServiceUserList',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
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
            success:
                function (response) {
                   
                    if (response!= "false") {
                        console.table(response);
                        $("#mytable5 tbody").empty();
                       
                        for (var i = 0; i < response.length; i++) {
                            var favbtn = `<button class="favourite-btn" data-value="${response[i].userIdTo}">favourite</button>`;
                            var blockbtn = ` <button class="block-btn" data-value="${response[i].userIdTo}">Block</button>`;
                            if (response[i].isFavourite == true) {
                                favbtn = `<button class="favourite-btn" data-value="${response[i].userIdTo}">Remove</button>`;
                                var blockbtn = ` <button class="block-btn btn disabled" data-value="${response[i].userIdTo}">Block</button>`;
                            }
                            if (response[i].isBlock == true) {
                                favbtn = `<button class="favourite-btn btn disabled" data-value="${response[i].userIdTo}">favourite</button>`;
                                var blockbtn = ` <button class="block-btn" data-value="${response[i].userIdTo}">Unblock</button>`;
                            }
                            $("#mytable5 tbody").append(`<tr class="block">
                <td>
                    <div><img class="cap-icon cap-upgrade" src="/image/cap.jpg" alt="cap"></div>
                </td>
                <td>
                    <div class="block-icon">
                        <p>${response[i].customerName}</p>
                    </div>
                </td>
                <td>
                    <div class="d-flex align-items-center"><div id="spratings${response[i].userIdTo}" class="average-rating"><span class="half-star "></span><span class="half-star "></span><span class="half-star "></span><span class="half-star "></span><span class="half-star "></span><span class="half-star "></span><span class="half-star "></span><span class="half-star"></span><span class="half-star"></span><span class="half-star"></span></div><div style="padding-top: 4px; padding-left: 3px"><span class="sprating">${response[i].spRatings}</span></div></div>
                    <p>${response[i].serviceProviderCleaning} cleaning</p>

                </td>
                <td>
                   ${favbtn}
                   ${blockbtn}
                   
                </td>
            </tr>`);
                            showRating(response[i].spRatings, `#spratings${response[i].userIdTo}`)
                        }


                        const table5 = new DataTable("#mytable5", {
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




$("#mytable5").click((e) => {

    var btnClass = e.target.classList;

    if (Object.values(btnClass).includes("block-btn")) {

        blockCustomer(e.target.dataset.value);
    }

    

    if (Object.values(btnClass).includes("favourite-btn")) {

        favouriteCustomer(e.target.dataset.value);
    }
});

function blockCustomer(id) {

    var data = {};
    data.userIdTo = id;
    $.ajax(
        {
            type: 'POST',
            url: '/Customer/BlockProvider',
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
                        getFavBlockDetails();

                    }

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });



}

function favouriteCustomer(id) {
    var data = {};
    data.userIdTo = id;
    $.ajax(
        {
            type: 'POST',
            url: '/Customer/FavouriteProvider',
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
                        getFavBlockDetails();

                    }

                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });


}