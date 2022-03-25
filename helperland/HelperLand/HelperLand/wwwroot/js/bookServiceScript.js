var insideCabinet = document.getElementById("insideCabinetCheck");
var insideFridge = document.getElementById("insideFridgeCheck");
var insideOven = document.getElementById("insideOvenCheck");
var laundry = document.getElementById("laundryCheck");
var interior = document.getElementById("interiorCheck");


document.getElementById('continue4').addEventListener("click", () => {

    if ($("input[name=address1]:checked").val() == undefined || $("input[name=address1]:checked").val() == null || $("input[name=address1]:checked").val() == "") {

        $(".select-address-list-alert").removeClass("d-none").text("Please Select address").fadeIn().fadeOut(7000);

}
    else {
    form4();
}

});


$(window).on('load', function () {

    $("html").css("overflow", "auto");

    $(".lds-roller").css("display", "none");
    $(".overlayer").css("display", "none");
}
);
function onInsideCabinet() {
    if (insideCabinet.checked) {
        document.getElementById("insideCabinetImg").src = "/image/3-green.png";
    } else {
        document.getElementById("insideCabinetImg").src = "/image/3.png";
    }
}

function onInsideFridge() {
    if (insideFridge.checked) {
        document.getElementById("insideFridgeImg").src = "/image/5-green.png";
    } else {
        document.getElementById("insideFridgeImg").src = "/image/5.png";
    }
}

function onInsideOven() {
    if (insideOven.checked) {
        document.getElementById("insideOvenImg").src = "/image/4-green.png";
    } else {
        document.getElementById("insideOvenImg").src = "/image/4.png";
    }
}

function onLaundry() {
    if (laundry.checked) {
        document.getElementById("laundryImg").src = "/image/2-green.png";
    } else {
        document.getElementById("laundryImg").src = "/image/2.png";
    }
}

function onInterior() {
    if (interior.checked) {
        document.getElementById("interiorImg").src = "/image/1-green.png";
    } else {
        document.getElementById("interiorImg").src = "/image/1.png";
    }
}


var pincode_check = document.getElementsByClassName("pincode-check")[0];
var schedule_plan = document.getElementsByClassName("schedule-plan")[0];
var address_list = document.getElementById("address-list");
var make_payment = document.getElementById("make-payment");

var setup_service = document.getElementById("1");
var schedule = document.getElementById("2");
var address = document.getElementById("3");
var payment = document.getElementById("4");

var img1 = document.getElementById("img1");
var img2 = document.getElementById("img2");
var img3 = document.getElementById("img3");
var img4 = document.getElementById("img4");

schedule.style.pointerEvents = "none";
address.style.pointerEvents = "none";
payment.style.pointerEvents = "none";



function form1() {
    pincode_check.style.display = "block";
    schedule_plan.style.display = "none";
    address_list.style.display = "none";
    make_payment.style.display = "none";

    setup_service.classList.add("add");
    schedule.classList.remove("add");
    address.classList.remove("add");
    payment.classList.remove("add");

    setup_service.classList.add("add-color");
    schedule.classList.remove("add-color");
    address.classList.remove("add-color");
    payment.classList.remove("add-color");

    setup_service.style.color = "white";
    schedule.style.color = "#646464";
    address.style.color = "#646464";
    payment.style.color = "#646464";

    setup_service.classList.remove("add-color-noarrow");
    schedule.classList.remove("add-color-noarrow");
    address.classList.remove("add-color-noarrow");
    payment.classList.remove("add-color-noarrow");

    img1.src = "/image/setup-service-white.png";
    img2.src = "/image/schedule.png";
    img3.src = "/image/details.png";
    img4.src = "/image/payment.png";

    schedule.style.pointerEvents = "none";
    address.style.pointerEvents = "none";
    payment.style.pointerEvents = "none";
}

function form2() {

    var now = new Date(new Date().getTime() + 24 * 60 * 60 * 1000).toISOString().slice(0, 10);
    $("#Date").attr("min", now);

    pincode_check.style.display = "none";
    schedule_plan.style.display = "block";
    address_list.style.display = "none";
    make_payment.style.display = "none";

    setup_service.classList.remove("add");
    schedule.classList.add("add");
    address.classList.remove("add");
    payment.classList.remove("add");

    setup_service.classList.remove("add-color");
    schedule.classList.add("add-color");
    address.classList.remove("add-color");
    payment.classList.remove("add-color");

    setup_service.classList.add("add-color-noarrow");
    schedule.classList.remove("add-color-noarrow");
    address.classList.remove("add-color-noarrow");
    payment.classList.remove("add-color-noarrow");

    setup_service.style.color = "#646464";
    schedule.style.color = "white";
    address.style.color = "#646464";
    payment.style.color = "#646464";

    img1.src = "/image/setup-service-white.png";
    img2.src = "/image/schedule-white.png";
    img3.src = "/image/details.png";
    img4.src = "/image/payment.png";



    schedule.style.pointerEvents = "none";
    address.style.pointerEvents = "none";
    payment.style.pointerEvents = "none";

   
}

 function form3() {
    pincode_check.style.display = "none";
    schedule_plan.style.display = "none";
    address_list.style.display = "block";
    make_payment.style.display = "none";

    setup_service.classList.remove("add");
    schedule.classList.remove("add");
    address.classList.add("add");
    payment.classList.remove("add");

    setup_service.classList.remove("add-color");
    schedule.classList.remove("add-color");
    address.classList.add("add-color");
    payment.classList.remove("add-color");

    setup_service.classList.add("add-color-noarrow");
    schedule.classList.add("add-color-noarrow");
    address.classList.remove("add-color-noarrow");
    payment.classList.remove("add-color-noarrow");

    setup_service.style.color = "#646464";
    schedule.style.color = "#646464";
    address.style.color = "white";
    payment.style.color = "#646464";

    img1.src = "/image/setup-service-white.png";
    img2.src = "/image/schedule-white.png";
    img3.src = "/image/details-white.png";
    img4.src = "/image/payment.png";

    schedule.style.pointerEvents = "auto";
    address.style.pointerEvents = "auto";
    payment.style.pointerEvents = "none";

   getAddress();
   getFavProvider();
}

function form4() {
    pincode_check.style.display = "none";
    schedule_plan.style.display = "none";
    address_list.style.display = "none";
    make_payment.style.display = "block";

    setup_service.classList.remove("add");
    schedule.classList.remove("add");
    address.classList.remove("add");
    payment.classList.add("add");

    setup_service.classList.remove("add-color");
    schedule.classList.remove("add-color");
    address.classList.remove("add-color");
    payment.classList.add("add-color");

    setup_service.classList.add("add-color-noarrow");
    schedule.classList.add("add-color-noarrow");
    address.classList.add("add-color-noarrow");
    payment.classList.remove("add-color-noarrow");

    setup_service.style.color = "#646464";
    schedule.style.color = "#646464";
    address.style.color = "#646464";
    payment.style.color = "white";

    img1.src = "/image/setup-service-white.png";
    img2.src = "/image/schedule-white.png";
    img3.src = "/image/details-white.png";
    img4.src = "/image/payment-white.png";

    schedule.style.pointerEvents = "auto";
    address.style.pointerEvents = "auto";
    payment.style.pointerEvents = "auto";
}

var add_address_btn =
    document.getElementsByClassName("add-address-btn")[0];
add_address_btn.addEventListener("click", () => {
    document.getElementsByClassName("add-address-box")[0].style.display =
        "block";
    add_address_btn.style.display = "none";
   
});

const urlSearchParams = new URLSearchParams(window.location.search);
if (urlSearchParams == "scheduleService=true") {
    form2();
}

if (urlSearchParams == "address=true") {
    form3();
}

function checkZipcode() {


    var zip = $("#zipform");
    var numbers = /^[0-9]+$/.test($("#zip").val());
    console.log(typeof ($("#zip").val()));
    var jsonInput = zip.serialize();
    if ($("#zip").val().trim(" ") == "") {

        $(".postalcode-error").removeClass("d-none").text("please enter valid postal code!");
    } else if (!numbers) {
        $(".postalcode-error").removeClass("d-none").text("please enter numbers!");
    }
    else {
        $.ajax(
            {
                type: 'POST',
                url: '/Customer/IsValidZipcode',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: jsonInput, beforeSend: function () {
                    $("html").css("overflow", "hidden");
                    $(".lds-roller").css("display", "inline-block");
                    $(".overlayer").css("display", "block");
                    $(".spin-btn").addClass("btn").addClass("disabled");
                    $(".loading-text").text("checking...");
                    $(".spin-load").removeClass("d-none");

                },
                complete: function () {
                    setTimeout(function () {
                        $("html").css("overflow", "auto");

                        $(".lds-roller").css("display", "none");
                        $(".overlayer").css("display", "none");

                        $(".spin-btn").removeClass("btn").removeClass("disabled");
                        $(".spin-load").addClass("d-none");
                        $(".loading-text").text("check availability");
                    }, 500);
                },
                success:
                    function (response) {
                        console.log(response);
                       
                        if (response.value == "true") {
                            $(".postalcode-error").addClass("d-none");
                            $("#postalcode").val($("#zip").val());


                            getZipcodeCity($("#zip").val(), "city")

                            form2();
                        } else if (response.value == "isBlockByU") {

                            $(".postalcode-error").removeClass("d-none").text("Available service provider block by you!");

                        } else {


                            $(".postalcode-error").removeClass("d-none").text("service is not available in your area !");


                        }


                    },
                error:
                    function (response) {

                    }
            });
    }

}



function getZipcodeCity(zipcode, tagidcity) {


    $.ajax({
        url: "https://api.postalpincode.in/pincode/" + zipcode,
        method: "GET",
        dataType: "json",
        cache: false,

        success: (data) => {

            console.log(data);
            if (data[0].Status == "Error") {
                console.log("err");
                $(".addAddress-error").removeClass("d-none").text("please enter valid postalcode!").fadeIn().fadeOut(2000);

                $("#" + tagidcity).val("");


            } else if (data[0].Status == "Success") {
                $("#" + tagidcity).val(data[0].PostOffice[0].District);
               
                $(".addAddress-error").addClass("d-none");
               /* $("." + tagiderror).removeClass("btn disabled");*/

            }
        },
        error: (err) => {
            console.log(err);
        }

    });

}


function getServiceDetails() {

    var servicedetails = $("#scheduleService");
    var jsonInput = servicedetails.serialize();
    var scheduleDate = new Date($("#Date").val() + " " + $("#time").val()).getTime() / 1000;
    var todayDate = new Date().getTime() / 1000;

    if (scheduleDate <= todayDate) {

        $(".scheduleService-error").removeClass("d-none").text("please select valid date and time!");

    } else {

        $.ajax(
            {
                type: 'POST',
                url: '/Customer/getScheduleServiceDetails',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: jsonInput, beforeSend: function () {
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
                            $(".scheduleService-error").addClass("d-none");
                            form3();
                        } else {
                            console.log(response.value);
                            $(".scheduleService-error").removeClass("d-none").text("please select valid date and time!");
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


function getAddress() {



    $.ajax(
        {
            type: 'GET',
            url: '/Customer/getAddressDetails',
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
                    var AddressList = $("#AddressList");
                    AddressList.empty();
                    for (var i = 0; i < response.length; i++) {

                        if (response[i].isDefault == true) {
                            AddressList.append('<div class="address-check-box"><div><input type="radio" name="address1" id="addressId' + response[i].id + '"' + 'value ="' + response[i].id + '"' + 'checked /></div><div><p><strong>Address: </strong>' + response[i].addressLine2 + ', ' + response[i].addressLine1 + ', ' + response[i].city + ', ' + response[i].postalCode + '</p > <p><strong>Phone number: </strong>' + response[i].mobile + '</p> </div > </div > ')
                        } else {
                            AddressList.append('<div class="address-check-box"><div><input type="radio" name="address1" id="addressId' + response[i].id + '"' + 'value ="' + response[i].id + '"' + '/></div><div><p><strong>Address: </strong>' + response[i].addressLine2 + ', ' + response[i].addressLine1 + ', ' + response[i].city + ', ' + response[i].postalCode + '</p > <p><strong>Phone number: </strong>' + response[i].mobile + '</p> </div > </div > ')
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

function clearAddress() {

    $("#streetname").val("");
    $("#housename").val("");
    $("#city").val("");
    $("#phonenumber").val("");
    document.getElementsByClassName("add-address-box")[0].style.display =
        "none";
    add_address_btn.style.display = "block";
}


function AddAddress() {
    var addData = {};
    addData.AddressLine2 = $("#streetname").val().trim(" ");
    addData.AddressLine1 = $("#housename").val().trim(" ");
    addData.postalcode = $("#postalcode").val();
    addData.city = $("#city").val();
    addData.mobile = $("#phonenumber").val().trim(" ");
    var numbers = /^[0-9]+$/.test(addData.mobile);

    console.log(addData);
    if (addData.AddressLine1 == "" && addData.AddressLine2 == "" && addData.mobile == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of house!");
    }
    else if (addData.AddressLine1 == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of house!");
    } else if (addData.AddressLine2 == "") {
        $(".addAddress-error").removeClass("d-none").text("please enter value of street!");
    } else if (addData.mobile == "" || !numbers) {
        $(".addAddress-error").removeClass("d-none").text("please enter value of mobile!");
    }
    else {

        $.ajax(
            {
                type: 'POST',
                url: '/Customer/addAddress',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: addData, beforeSend: function () {
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
                            getAddress();
                            clearAddress()
                        } else {

                            alert("fails");
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
var d = "";
var date = $("#Date").change(() => {
    var addDate = $("#Date").val().split("-");
    d = addDate[2] + "/" + addDate[1] + "/" + addDate[0];

});

$("#time").change(() => {

    var t = new Date($("#Date").val() + " " + $("#time").val());
    var t1 = t.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true });

    $(".details p").empty();
    $(".details p").html(d + " " + t1);


});






function CreatePaySummery() {
    var dur = 0;
    var totalhour = 0;
    var cabinetValue = 0, ovenValue = 0, fridgeValue = 0, laundryValue = 0, windowValue = 0;
    if ($("#insideCabinetCheck").is(':checked')) {
        $(".extra1").removeClass("d-none");
        cabinetValue = 0.5;

    } else {
        $(".extra1").addClass("d-none");
        cabinetValue = 0;

    }


    if ($("#insideFridgeCheck").is(':checked')) {
        $(".extra2").removeClass("d-none");
        fridgeValue = 0.5;
    } else {
        $(".extra2").addClass("d-none");
        fridgeValue = 0;
    }


    if ($("#insideOvenCheck").is(':checked')) {
        $(".extra3").removeClass("d-none");
        ovenValue = 0.5;
    } else {
        $(".extra3").addClass("d-none");
        ovenValue = 0;
    }


    if ($("#laundryCheck").is(':checked')) {
        $(".extra4").removeClass("d-none");
        laundryValue = 0.5;
    } else {
        $(".extra4").addClass("d-none");
        laundryValue = 0;
    }


    if ($("#interiorCheck").is(':checked')) {
        $(".extra5").removeClass("d-none");
        windowValue = 0.5;
    } else {
        $(".extra5").addClass("d-none");
        windowValue = 0;
    }
    dur = parseFloat($("#Duration").val());
    $(".duration-print").text(dur + " Hrs");
    totalhour = cabinetValue + fridgeValue + ovenValue + laundryValue + windowValue + dur;
    $(".TotalHour").html('<strong>' + totalhour + ' Hrs</strong>');
    $(".PerCleanPay").text("$" + totalhour * 20);



}


function tConvert(time) {
    // Check correct time format and split into components
    time = time.toString().match(/^([01]\d|2[0-3])(:)([0-5]\d)(:[0-5]\d)?$/) || [time];

    if (time.length > 1) { // If time format correct
        time = time.slice(1);  // Remove full string match value
        time[5] = +time[0] < 12 ? ' AM' : ' PM'; // Set AM/PM
        time[0] = +time[0] % 12 || 12; // Adjust hours
    }
    return time.join(''); // return adjusted time or original string
}








function payDone() {
    var serviceRequestData = {};

    serviceRequestData.startDate = $("#Date").val();
    serviceRequestData.startTime = tConvert($("#time").val() + ":00");
    console.log(serviceRequestData.startTime);
    serviceRequestData.duration = $("#Duration").val();
    serviceRequestData.comment = $("#comment").val();
    serviceRequestData.havePet = $("#havePet").is(":checked");
    serviceRequestData.AddressId = $("#AddressList div input[type=radio]:checked").val();
    serviceRequestData.postalcode = $("#zip").val();
    serviceRequestData.serviceProviderId = favprovider;
    favprovider = "";
    serviceRequestData.extraHours = 0;

    var insideCabinetCheck = $("#insideCabinetCheck");
    if (insideCabinetCheck.is(':checked')) {
        serviceRequestData.extraHours += 0.5;
        serviceRequestData.cabinet = insideCabinetCheck.val();
    }
    var insideFridgeCheck = $("#insideFridgeCheck");

    if (insideFridgeCheck.is(':checked')) {
        serviceRequestData.extraHours += 0.5;
        serviceRequestData.fridge = insideFridgeCheck.val();
    }

    var insideOvenCheck = $("#insideOvenCheck");

    if (insideOvenCheck.is(':checked')) {
        serviceRequestData.extraHours += 0.5;
        serviceRequestData.oven = insideOvenCheck.val();
    }

    var laundryCheck = $("#laundryCheck");

    if (laundryCheck.is(':checked')) {
        serviceRequestData.extraHours += 0.5;
        serviceRequestData.laundry = laundryCheck.val();
    }

    var interiorCheck = $("#interiorCheck");

    if (interiorCheck.is(':checked')) {
        serviceRequestData.extraHours += 0.5;
        serviceRequestData.windows = interiorCheck.val();
    }

    console.log(serviceRequestData);


    $.ajax(
        {
            type: 'POST',
            url: '/Customer/PayDone',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: serviceRequestData, beforeSend: function () {
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

                    if (response.value == "false") {
                        $(".paydone-alert").removeClass("d-none").text("something is go wrong try again");


                    } else if (response.value == "conflict") {

                        $(".paydone-alert").removeClass("d-none").text("Service Provider already have schedule on given time and date!");

                    } else {
                        $(".paydone-alert").addClass("d-none")
                        $("#bookedId").text("service request id : " + response.value);
                        $("#completeBookModal").click();

                    }


                },
            error:
                function (response) {

                    console.error(response);
                    alert("fail");
                }
        });


}




function getFavProvider() {
    $.ajax(
        {
            type: 'GET',
            url: '/Customer/GetFavProvider',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: {
               
                zipCode: $("#zip").val()
            },
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
                        $(".favourite-worker").empty();
                        for (var i = 0; i < response.length; i++) {
                            $(".favourite-worker").append(`<div style="text-align: center; width: 20%">
                    <img class="favourite-worker-img" src="/image/cap.png" alt="cap">
                    <p class="mb-2">${response[i].serviceProviderName}</p>
                    <div>
                        <button class="fav-btn btn btn-outline-secondary" data-value="${response[i].userIdTo}" type="button">
                            Select
                        </button>
                    </div>
                </div>`);
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

var fav_btn = document.getElementsByClassName("fav-btn");


var favprovider;
document.querySelector(".favourite-worker").addEventListener("click", function (e) {
   
    if (e.target.classList.contains("fav-btn")) {
        for (var i = 0; i < fav_btn.length; i++) {
            if (fav_btn[i].getAttribute("data-value") != e.target.dataset.value) {
                fav_btn[i].classList.toggle("disabled");
            } else {
                fav_btn[i].classList.toggle("active");
            }
        }
    }
    
    if (e.target.classList.contains("fav-btn") && (e.target.classList.contains("active"))) {
        favprovider=e.target.dataset.value;
    }

});