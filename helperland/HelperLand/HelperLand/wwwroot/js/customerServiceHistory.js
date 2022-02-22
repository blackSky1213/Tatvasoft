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


function my_user_setting() {

    document.getElementsByClassName("my-setting-box")[0].classList.remove("d-none");
    document.getElementsByClassName("contant-right")[0].classList.add("d-none");

}



const urlSearchParams = new URLSearchParams(window.location.search);
if (urlSearchParams == "customerDashboard=true") {
    form1();
}


if (urlSearchParams == "customerSetting=true") {
    my_user_setting();
}