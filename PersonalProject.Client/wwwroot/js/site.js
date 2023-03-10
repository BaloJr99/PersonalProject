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
    var message = `<b>${xhr.responseText.split("\r")[0]} <br> ${errorThrown}</b>`;

    $.alert({
        title: `Error ${xhr.status}`,
        content: message,
        type: "red",
        theme: "modern",
        columnClass: 'medium'
    });
}

const successAlert = message => {
    $.alert({
        title: "Alert",
        content: message,
        type: "green"
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