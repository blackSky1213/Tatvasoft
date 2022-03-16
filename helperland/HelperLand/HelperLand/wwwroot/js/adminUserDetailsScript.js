
$(document).ready(function () {
   



$("#userListSearch").click(() => {
    dt.ajax.reload();
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
        "data": function (data) {
            data.userName = $("#searchUserName").val(),
                data.userType = $("#searchUserTypeId").val(),
                data.mobile = $("#searchMobile").val(),
                data.postalCode = $("#searchZipCode").val()
        },
        "datatype": "json"
    }, "columnDefs": [{
        "targets": [0],
        "visible": false,
        "searchable": false
    }], "columns": [
        {
            "data":"userName","name":"UserName"
           
        }, {
            "data": "date",
            "name":"Date",
            "render": (data, row) => {
                return ` <img src="/image/calendar2.png" alt="" /> ` + data;
            }

            },
        {
            "data":"userType","name":"UserTypeId"
        },
        {
            "data":"mobile","name":"Mobile"
            
                     },

        { "data": "postalCode","name":"ZipCode" },
       
        { "data": "city","name":"City" },
        {
            "data": "userStatus",
            "name":"UserStatus",
            "render": (data, row) => {

                if (data == true) {
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
    columnDefs: [{ orderable: false, targets:7 }],
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

    $("#serviceRequestSearchBtn").click(() => {

        table2.ajax.reload();

    });


const table2 = new DataTable("#mytable2", {
    dom: 't<"table-bottom paging d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
    "retrieve": true,
    "processing": true,
    "serverSide": true,
    
    "filter": true,
    "ajax": {
        "url": "/Admin/GetSeviceList",
        "type": "POST",
        "data": function (data) {
            data.serviceRequestId = $("#searchServiceId").val();
            data.customerName = $("#searchCustomerName").val();
            data.serviceProvider = $("#searchServiceProviderName").val();
            data.fromDate = $("#searchFromDate").val();
            data.toDate = $("#searchToDate").val();
        },
        "datatype": "json"
    }, "columnDefs": [{
        "targets": [0],
        "visible": false,
        "searchable": false
    }], "columns": [
        {
            "data": "serviceRequestId", "name": "ServiceRequestId"

        }, {
            "data": {},"name":"Date",
            
            "render": (data, row) => {
                return `<img src="/image/calendar2.png" alt="calendar" />
                        <strong> `+ data.serviceStartDate+`</strong>
                        <p>
                            <img src="/image/layer-14.png" alt="" /> `+data.startTime+` - `+ data.endTime+` 
                        </p>`;
            }

        },
        {
            "data": {},"name":"CustomerName",
            "render": (data, row) => {
                return `<div class="address-td-box">
                                    <div style="width: fit-content">
                                        <img src="/image/layer-15.png" alt="cap">
                                    </div>
                                    <div>
                                        <span> `+ data.customerName +`</span>
                                        <span> `+ data.customerAddress1 + `</span>
                                        <span> `+ data.customerAddress2 +`</span>
                                    </div>
                                </div>`;
            }
        },
        {
            "data": "totalCost", "name": "TotalCost",
            "render": (data, raw) => {
                return `€ ` + data;
            }

        },

        {
            "data": {},"name":"ServiceProvider",
            "render": (data, row) => {

                if (data.serviceProvider != null) {

                    var stars = ``;
                    for (var i = 0; i < Math.ceil(data.spRatings*2); i++) {
                        stars += `<span class=" half-star half-start"></span>`;
                    }
                    for (var i = Math.ceil(data.spRatings*2); i < 10; i++) {
                        stars += `</span><span class=" half-star">`;
                    }
                    return `<div class="service-provider-average-rating" id="serviceproviderId">
                            <div>
                                <img class="cap-icon" src="/image/cap.png" alt="cap">
                            </div>
                            <div>
                                <div>
                                    <span class="spName"> `+ data.serviceProvider + `</span>
                                </div>
                                <div class="d-flex align-items-center">
                                    <div class="average-rating" id="spratingId">

                                        `+stars+`
                                    </div>
                                    <div style="padding-top: 4px; padding-left: 3px">
                                        <span class="sprating"> `+ data.spRatings + `</span>
                                    </div>
                                </div>
                            </div>
                        </div>`;
                }
                else {
                    return ``;
                }
               
            }
        },

    
        {
            "data": {},"name":"Status",
            "render": (data, row) => {

                if (data.status == 0) {
                    return `<p class="complete-label">complete</p>`;
                } else if (data.status == 1) {
                    return `<p class="cancel-label">cancel</p>`;
                } else if (data.status == 2 && data.serviceProvider != null) {
                    return `<p class="pending-label">pending</p>`;
                } else if (data.status == 2 && data.serviceProvider == null) {
                    return `<p class="new-label">new</p>`;
                }
            }
        },
        {
            "data": {},
            "render": function (data, row) {
                return `<div class="dropdown text-center">
                    <button class="admin-table-actionbtn" type="button" id = "dropdownMenuButton`+ data.serviceRequestId + `"
                data-bs-toggle="dropdown" aria-expanded="false">
                    <i class="fa fa-ellipsis-v" aria-hidden="true" style="color:#646464"></i>
                            </button>
    <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton`+ data.serviceRequestId + `">
        <li><a class="dropdown-item" href="#">Action</a></li>
        <li><a class="dropdown-item" href="#">Another action</a></li>
        <li><a class="dropdown-item" href="#">Something else here</a></li>
    </ul>
                        </div>`;
            }
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
    columnDefs: [{ orderable: false, targets: 6 }],
});


});