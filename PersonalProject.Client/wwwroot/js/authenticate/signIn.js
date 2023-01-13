$(document).ready(() => {
    $(document).on("click", "#btnSaveUser", saveUser);
    $(document).on("click", "#btnSignUp", moveToLogin);
    $(document).on("click", "#btnSaveEmployee", saveEmployee);
    $(document).on("change", "#IdEmployee", checkSelectedOption);
    $(document).on("hidden.bs.modal", "#employeeFormModal", clearModal);
    loadEmployees();
})

const moveToLogin = e => {
    e.preventDefault();
    location.href = "/Login";
}

const clearModal = () => {
    $("#employeeForm")[0].reset();
    $("#IdEmployee").val("");
}

const loadEmployees = () => {
    $("body").waitMe({text: "Getting Employees"});
    $.ajax({
        type: "GET",
        url: "/Employees/GetEmployees",
    }).done((employees) => {
        $("#IdEmployee").empty();
        $("#IdEmployee").append(`<option value="">Select...</option>`);
        employees.forEach(employee => {
            $("#IdEmployee").append(`<option value="${employee.idEmployee}">${employee.name} ${employee.lastName}</option>`);
        });
        $("#IdEmployee").append(`<option value="">+ Add</option>`);
        $("body").waitMe("hide");
    });
}

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
                location.href = "/";
            }else{
                errorAlert("The user wasn't saved");
            }
        }).always(function(response){
            $("body").waitMe("hide");
        });
    }
}

const checkSelectedOption = () => {
    var optSelected = $("#IdEmployee option:selected").text();
    if(optSelected == "+ Add")
        $("#employeeFormModal").modal("show");
}

const saveEmployee = e => {
    e.preventDefault();
    if($("#employeeForm").valid()){
        $("body").waitMe({text: "Saving employee"});
        var formData = new FormData($("#employeeForm")[0]);
        $.ajax({
            url: "/Employees/SaveEmployee",
            type: "POST",
            data: formData,
            processData: false,
            contentType: false
        }).done(function(response){
            if(response.success){
                $("#employeeFormModal").modal("hide");
                loadEmployees();
            }
        }).always(function(response){
            $("body").waitMe("hide");
        });
    }
}