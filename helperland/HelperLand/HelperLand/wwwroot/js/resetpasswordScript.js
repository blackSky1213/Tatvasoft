var pwd = document.getElementById("password");
var conf = document.getElementById("re-enter-password");
var submit = document.getElementById("registered");
var re_pwd_message = document.getElementById("re-enter-pwd-message");

conf.addEventListener("change", function () {

    if (pwd.value != conf.value) {
        submit.disabled = true;
        re_pwd_message.textContent = "password not match!"
    }
    else {
        submit.disabled = false;
        re_pwd_message.style.display = "none";
    }
});