$(document).ready(function () {
    $("#mytable").DataTable();
});

const dt = new DataTable("#mytable", {
    dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
    "processing": true,
    "serverSide": true,
    "retrive":true,
    "filter": true,
    "ajax": {
        "url": "/Admin/GetUserList",
        "type": "POST",
        "datatype": "json"
    }, "columnDefs": [{
        "targets": [0],
        "visible": false,
        "searchable": false
    }], "columns": [
        {
            "data":"userName",
           
        }, {
            "data": {},
            "render": (data, row) => {
                return ` <img src="/image/calendar2.png" alt="" /> ` + data.date;
            }

            },
        {
            "data":"userType"
        },
        {
            "data":"mobile"
            
                     },

        { "data": "postalCode" },
       
        { "data": "city" },
        {
            "data": {},
            "render": (data, row) => {

                if (data.userStatus == true) {
                    return `<p class="active-label ">active</p>`;
                } else {
                    return `<p class="inactive-label">inactive</p>`;
                }
            }},
        {
            "data": {},
            "render": function (data, row) {
                return `<div class="dropdown text-center">
                    <button class="admin-table-actionbtn" type="button" id = "dropdownMenuButton`+data.userId+`"
                data-bs-toggle="dropdown" aria-expanded="false">
                    <i class="fa fa-ellipsis-v" aria-hidden="true" style="color:#646464"></i>
                            </button>
    <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton`+data.userId+`">
        <li><a class="dropdown-item" href="#">Action</a></li>
        <li><a class="dropdown-item" href="#">Another action</a></li>
        <li><a class="dropdown-item" href="#">Something else here</a></li>
    </ul>
                        </div>`; }
        },
    ],
    responsive: true,
    pagingType: "full_numbers",
    language: {
        paginate: {
            first: '<img src="/image/first-page.png" alt="first" style="display:none" />',
            previous: '<img src="/image/previous.png" alt="previous" />',
            next: '<img src="/image/previous.png" alt="next" style="transform: rotate(180deg)" />',
            last: "<img src='/image/first-page.png' alt='first' style='display:none' />",
        },
        info: "Total Record: _MAX_",
        lengthMenu: "Show_MENU_Entries",
    },
    buttons: ["excel"],
    columnDefs: [{ orderable: false, targets: 4 }],
});

function html_table_to_excel(type) {
    var data = document.getElementById('mytable');

    var file = XLSX.utils.table_to_book(data, { sheet: "sheet1" });

    XLSX.write(file, { bookType: type, bookSST: true, type: 'base64' });

    XLSX.writeFile(file, 'file.' + type);
}

const export_button = document.getElementById('export');

export_button.addEventListener('click', () => {
    html_table_to_excel('xlsx');
});


var option1 = document.getElementById("1");
var option2 = document.getElementById("2");
var UserListBox = document.getElementById("UserList");
var ServiceRequestBox = document.getElementById("ServiceRequest");


option1.addEventListener("click", () => {
    form1();
});

option2.addEventListener("click", () => {
    form2();
});

function form1() {

    option1.classList.add("active");
    option2.classList.remove("active");


    UserListBox.classList.remove("d-none");
    ServiceRequestBox.classList.add("d-none");

}


function form2() {

    option1.classList.remove("active");
    option2.classList.add("active");


    UserListBox.classList.add("d-none");
    ServiceRequestBox.classList.remove("d-none");

}