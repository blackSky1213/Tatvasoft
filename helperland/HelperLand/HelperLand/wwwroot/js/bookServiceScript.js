var insideCabinet = document.getElementById("insideCabinetCheck");
var insideFridge = document.getElementById("insideFridgeCheck");
var insideOven = document.getElementById("insideOvenCheck");
var laundry = document.getElementById("laundryCheck");
var interior = document.getElementById("interiorCheck");



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




