$(document).ready(() => {
    $(document).on("click", "#btnSaveUser", saveUser);
})

const saveUser = e => {
    e.preventDefault();
    if($("#frmUser").valid()){
        $("body").waitMe({text: "Guardando usuario"});
        var formData = new FormData($("#frmUser")[0]);
        $.ajax({
            url: "SaveUser",
            type: "POST",
            data: formData,
            processData: false,
            contentType: false
        }).done(function(response){
            if(response.success){
                
            }else{
                errorAlert("The user wasn't saved");
            }
        }).always(function(response){
            $("body").waitMe("hide");
        });
    }
}