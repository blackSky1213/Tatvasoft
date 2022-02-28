window.addEventListener("scroll", () => {
    var nav = document.querySelector("nav");
    nav.classList.toggle("sticky", window.scrollY > 0);
 /*   var brand = document.getElementsByClassName("logo")[0];
    brand.classList.toggle("brand-img", window.scrollY > 0);*/

});
document.getElementById("ok-btn").onclick = function () {
    document.getElementById("policy-text").style.display = "none";

}

var loginbtn = document.getElementById("Login");
var forgetbtn = document.getElementById("forget");
var logoutbtn = document.getElementById("logout");
const urlSearchParams = new URLSearchParams(window.location.search);
if (urlSearchParams == "loginModal=true") {
    loginbtn.click();
}

if (urlSearchParams == "LogoutModal=true") {
    logoutbtn.click();
}
if (urlSearchParams == "ForgetModal=true") {
    forgetbtn.click();
}
