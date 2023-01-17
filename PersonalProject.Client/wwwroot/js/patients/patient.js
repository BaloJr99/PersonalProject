$(document).ready(() => {
    $(document).on("click", "#btnAddNewPatient", showPatientModal);
    $(document).on("click", "#btnEditPatient", showPatientModal);
    $(document).on("click", "#btnSearchPatient", searchPatients);
    $(document).on("click", "#btnSavePatient", savePatientData);
    $(document).on("hidden.bs.modal", "#patientFormModal", clearModal);
})

var table = undefined;

/**
 * It takes the data from the form, sends it to the server, and then displays the results in a table.
 */
const searchPatients = () => {
    if($("#patientsForm").valid()){
        $("body").waitMe({text: "Getting Matching Patients"});
        var formData = $("#patientsForm").serialize();
        $.ajax({
            url: "/Patients/SearchPatients",
            data: formData
        }).done((patients) => {
            $("body").waitMe("hide");
            if(table != undefined){
                $("#patientsTable").empty();
                table.destroy();
            }
            table = $("#patientsTable").DataTable({
                data: patients,
                bFilter: false,
                pageLenght: 50,
                lengthChange: false,
                columns: [
                    { data: 'name', title:"Full Name", width: "30%", render:(data, type, row) => {
                        if(type == "display"){
                            return `${row.name} ${row.lastName}`
                        }
                        return data;
                    }},
                    { data: 'birthday', title:"Birthday", width: "auto", render:(data, type, row) => {
                        if(type == "display"){
                            return `${row.birthday.split("T")[0]}`
                        }
                        return data;
                    }},
                    { data: 'address', title:"Address"},
                    { data: 'idPatient', className:"text-center", title:"Action", width: "70px", render:(data, type, row) => {
                        if(type == "display"){
                            return `<button class="btn btn-sm btn-outline-primary d-flex justify-content-center align-items-center" id="btnEditPatient" data-id=${row.idPatient}>
                                <span class="material-symbols-outlined">edit</span> &nbspEdit</button>`
                        }
                        return data;
                    }},
                ]
            })
        });
    }
}

/**
 * It shows a modal with a form to create or edit a patient.
 */
const showPatientModal = e => {
    var id = $(e.currentTarget).data("id");
    if(id == undefined){
        $("#patientFormModal").modal("show");
    }else{
        $("body").waitMe({text: "Getting Patient Data"});
        $.ajax({url: `/Patients/GetPatient/${id}`}).done((patient) => {
            console.log(patient);
            $("#patientForm #IdPatient").val(patient.idPatient);
            $("#patientForm #Name").val(patient.name);
            $("#patientForm #LastName").val(patient.lastName);
            $("#patientForm #Birthday").val(patient.birthday.split("T")[0]);
            $("#patientForm #Gender").val(patient.gender);
            $("body").waitMe({text: "Getting Patient Address"});
            $.ajax({url: `/Address/GetAddress/${patient.idAddress}`}).done((address) => {
                $("#patientForm #IdAddress").val(address.idAddress);
                $("#patientForm #Street").val(address.street);
                $("#patientForm #Apartment").val(address.apartment);
                $("#patientForm #State").val(address.state);
                $("#patientForm #City").val(address.city);
                $("#patientForm #ZipCode").val(address.zipCode);
                $("#patientForm #Country").val(address.country);
                $("#patientFormModal").modal("show");
                $("body").waitMe("hide");
            });
        });
    }
}
/**
 * When the save button is clicked, prevent the default action, check if the form is valid, show a
 * loading message, create a formData object from the form, send the formData object to the server, and
 * if the server responds with a success message, hide the loading message and close the modal.
 */

const savePatientData = e => {
    e.preventDefault();
    if($("#patientForm").valid()){
        $("body").waitMe({text: "Saving Patient Data"});
        var formData = new FormData($("#patientForm")[0]);
        $.ajax({
            type: "POST",
            url: "/Patients/SavePatient",
            data: formData
        }).done((response) => {
            if(response.success){
                successAlert("Patient Saved");
                $("body").waitMe("hide");
                $("#patientFormModal").modal("hide");
            }
        });
    }
}

const clearModal = () => {
    $("#patientForm")[0].reset();
}