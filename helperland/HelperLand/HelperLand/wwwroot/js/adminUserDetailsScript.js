

$("#mytable").on("click",".userActivation",(e) => {

    ActiveDeactiveUser(e.target.dataset.value);

});
   


function ActiveDeactiveUser(id) {
    var data = {};
    data.userId = id;
    $.ajax(
        {
            type: 'POST',
            url: '/Admin/ActiveDeactiveUser',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success:
                function (response) {
                    if (response.value == "true") {

                        dt.ajax.reload();
                    }



                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

}


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

                var lists = "";
                if (data.userStatus == true) {
                    lists = `<li><a role="button" class="dropdown-item userActivation" data-value="` + data.userId + `">Deactive</a></li>`;
                } else {
                    lists = ` <li><a role="button" class="dropdown-item userActivation" data-value="` + data.userId + `">Active</a></li>`;
                }
                return `<div class="dropdown text-center">
                    <button class="admin-table-actionbtn" type="button" id = "dropdownMenuButton`+data.userId+`"
                data-bs-toggle="dropdown" aria-expanded="false">
                    <i class="fa fa-ellipsis-v" aria-hidden="true" style="color:#646464"></i>
                            </button>
    <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton`+data.userId+`">
        `+lists+`
       

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

            
                var button = ``;
                if (data.status == 0 || data.status == 1) {
                    button = `btn disabled`;
                }
                if (data.status == 2) {

                }
                return `<div class="dropdown text-center">
                    <button class="admin-table-actionbtn `+button+` " type="button" id = "dropdownMenuButton`+ data.serviceRequestId + `"
                data-bs-toggle="dropdown" aria-expanded="false">
                    <i class="fa fa-ellipsis-v" aria-hidden="true" style="color:#646464"></i>
                            </button>
    <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton`+ data.serviceRequestId + `">
        <li><a class="dropdown-item EditServiceRequest" data-value="`+ data.serviceRequestId +`">Edit</a></li>
        <li><a class="dropdown-item CancelServiceRequest" data-value="`+ data.serviceRequestId +`">Cancel</a></li>
       
    </ul>
                        </div>`;
            }
        },
    ], "createdRow": function (row, data, dataIndex) {
        $(row).attr('data-value', data.serviceRequestId);
    },
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



$("#mytable2").click((e) => {

    var btnClass = e.target.classList;
    var service_request_id = e.target.closest('tr').getAttribute("data-value");
    var btn_class = e.target.closest('.admin-table-actionbtn')
    if (service_request_id != null && !btn_class && !Object.values(btnClass).includes("dropdown-item")) {
        console.log($(".conflict-btn").attr("data-value"));
       
        $(".btn-box").addClass("d-none");
        
        $(".btn-box1").addClass("d-none");
       
        document.getElementById("CustomerServiceSummery-btn").click();
        console.log(service_request_id);
        getServiceRequestAllDetails(service_request_id);

    }


    if (Object.values(btnClass).includes("CancelServiceRequest")) {

        CancelServiceRequest(service_request_id);
    }

    if (Object.values(btnClass).includes("EditServiceRequest")) {


        document.getElementById("ServiceRequestUpdateByAdminBtn").click();
        $(".addmin-edit-service-btn").attr("data-value", service_request_id);
        GetEditServiceRequestData(service_request_id);
    }

    

   

});


$(".addmin-edit-service-btn").click((e) => {
    var data = {};
    data.serviceRequestId = e.target.dataset.value;
    data.serviceStartDate = $("#date").val();
    data.startTime = $("#time").val();
    data.streetName = $("#streetname").val();
    data.houseNumber = $("#housenumber").val();
    data.postalCode = $("#postalcode").val();
    data.city = $("#city").val();

   

    if (data.serviceStartDate == "") {

        $(".update-alert").addClass("alert-danger ").removeClass("d-none").text("Please select valid date!").fadeIn().fadeOut(2000);

    } else if (data.startTime == "") {
        $(".update-alert").addClass("alert-danger ").removeClass("d-none").text("Please select valid time!").fadeIn().fadeOut(2000);

    } else if (data.streetName == "") {
        $(".update-alert").addClass("alert-danger ").removeClass("d-none").text("Please select valid Street Name!").fadeIn().fadeOut(2000);
    } else if (data.houseNumber == "") {
        $(".update-alert").addClass("alert-danger ").removeClass("d-none").text("Please select valid House Number!").fadeIn().fadeOut(2000);
    } else if (data.postalCode == "") {
        $(".update-alert").addClass("alert-danger ").removeClass("d-none").text("Please select valid Postal Code!").fadeIn().fadeOut(2000);
    } else if (data.city == "") {
        $(".update-alert").addClass("alert-danger ").removeClass("d-none").text("Please select valid City Name!").fadeIn().fadeOut(2000);
    } else {
      
        $.ajax(
            {
                type: 'POST',
                url: '/Admin/UpdateServiceRequest',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: data,
                success:
                    function (response) {
                        if (response.value == "true") {
                            $(".update-alert").addClass("alert-success ").removeClass("alert-danger d-none").text("successfully update data!").fadeIn().fadeOut(2000);
                            table2.ajax.reload();
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


function GetEditServiceRequestData(id) {
    var data = {};
    data.serviceRequestId = id;
    $.ajax(
        {
            type: 'GET',
            url: '/Admin/GetEditServiceRequestData',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success:
                function (response) {
                    if (response != null) {

                        console.log(response);
                        var dateTime = response.serviceStartDate.split("T");
                        var now = new Date(new Date().getTime() + 24 * 60 * 60 * 1000).toISOString().slice(0, 10);
                        console.log(response.serviceStartDate);
                        $("#date").attr("min", now);
                        $("#date").val(dateTime[0]);
                        $("#time").val(dateTime[1]);
                        $("#streetname").val(response.streetName);
                        $("#housenumber").val(response.houseNumber);

                        if (response.isTaken == true) {
                            $("#postalcode").prop('disabled', true);
                        } else {
                            $("#postalcode").prop('disabled', false);
                        }
                        $("#postalcode").val(response.postalCode);
                        $("#city").val(response.city);

                    }




                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });
}



function CancelServiceRequest(id) {


    var data = {};
    data.serviceRequestId = id;
    $.ajax(
        {
            type: 'POST',
            url: '/Admin/CancelServiceRequest',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success:
                function (response) {
                    if (response.value == "true") {

                        table2.ajax.reload();
                    }



                },
            error:
                function (response) {
                    console.error(response);
                    alert("fail");
                }
        });

}



function getServiceRequestAllDetails(service_request_id) {

    var data = {};
    data.serviceRequestId = service_request_id;
    $.ajax(
        {
            type: 'GET',
            url: '/Admin/showServiceRequestSummery',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
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
                        var endTime = new Date(date + " " + response.endTime);
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

document.getElementById("postalcode").addEventListener("focusout", () => {
    var zip = $("#postalcode").val();
    if (zip.length == 6) {
        getZipcodeCity(zip, "city", "state", "addmin-edit-service-btn");
    }
    else {
        $(".update-alert").addClass("alert-danger").removeClass("alert-success d-none").text("please enter valid postalcode!").fadeIn().fadeOut(2000);
        $(".addmin-edit-service-btn").addClass("btn disabled");

    }


});

