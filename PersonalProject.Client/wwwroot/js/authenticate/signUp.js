$(document).ready(() => {
    $(document).on("click", "#btnLogin", loginUser);
})

const loginUser = e => {
    e.preventDefault();
    var formData = new FormData($("#frmLogin")[0]);

    $("body").waitMe({text: "Logging"});
    $.ajax({
        type: "POST",
        url: "Login/LoginUser",
        data: formData,
        processData: false,
        contentType: false
    }).done(function(response){
        if(response.success){
            $("body").waitMe({text: "Logging Successful"});
            location.href = "http://localhost:5239"
        }else{
            errorAlert("Username/Password Incorrect");
        }
    });
}