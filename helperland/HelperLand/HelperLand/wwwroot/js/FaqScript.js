var customer = document.getElementsByClassName("customer")[0];
var service = document.getElementsByClassName("service")[0];
customer.addEventListener("click", () => {


    document.getElementsByClassName("service")[0].classList.remove("active");
    document.getElementsByClassName("customer")[0].classList.add("active");
    document.getElementById("need").style.display = "block";
    document.getElementById("helper").style.display = "none";


});
service.addEventListener("click", () => {

    document.getElementById("need").style.display = "none";
    document.getElementById("helper").style.display = "block";
    document.getElementsByClassName("service")[0].classList.add("active");
    document.getElementsByClassName("customer")[0].classList.remove("active");


});
