$('#attachment').change(function () {
    var file = $('#attachment')[0].files[0].name;
    $('#filename').text(file);
});
var successsentbtn = document.getElementById("SuccessSent");
const urlSearchParams = new URLSearchParams(window.location.search);
if (urlSearchParams == "ContactModal=true") {
    successsentbtn.click();
}
