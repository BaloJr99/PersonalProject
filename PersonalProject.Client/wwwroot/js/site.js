// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
    $(document).on("click", "#btnLogout", logOut)

    $.ajaxSetup({
        type: "GET",
        processData: false,
        contentType: false,
        error: errorMessage
    });
})

const errorMessage = (xhr, textStatus, errorThrown) => {
    $("body").waitMe("hide");
    var message = `<b>Fatal Error</b>`;

    $.alert({
        title: "Fatal Error",
        content: message,
        type: "red",
        theme: "modern",
    });
}

const successAlert = message => {
    $.alert({
        title: "Alert",
        content: "Simple Alert!"
    });
}

const errorAlert = message => {
    $("body").waitMe("hide");
    $.alert({
        title: "An error has occurred",
        content: message,
        type: "red",
    });
}

const logOut = () => {
    $.ajax({
        type: "POST",
        url: "Login/LogOut",
    }).done(() => {
        location.href = "/";
    });
}