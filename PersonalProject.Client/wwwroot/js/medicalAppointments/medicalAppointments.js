$(document).ready(() => {
    $(document).on("click", "#btnAppointmentModal", showAppointmentModal)
    loadMedicalAppointMents();
})

var table = undefined;

const showAppointmentModal = () => {
    $("#appointmentModal").modal("show");
    loadPatients();
}

const loadPatients = () => {
    $("body").waitMe({text: "Getting Patients"});
    $.ajax({
        type: "GET",
        url: "/Patients/GetAllPatients",
    }).done((patients) => {
        $("#IdPatient").empty();
        $("#IdPatient").append(`<option value="">Select...</option>`);
        patients.forEach(patient => {
            $("#IdPatient").append(`<option value="${patient.idEmployee}">${patient.name} ${patient.lastName}</option>`);
        });
        $("body").waitMe("hide");
    });
}

const loadMedicalAppointMents = () => {
    var formData = new FormData();
    $.ajax({
        url: "/MedicalAppointments/GetTodayAppointments",
        data: formData,
    }).done((medicalData) => {
        if(table != undefined){
            $("#appointmentsTable").empty();
            table.destroy();
        }
        table = $("#appointmentsTable").DataTable({
            data: medicalData,
            bFilter: false,
            columns: [
                { data: 'name' },
                { data: 'position' },
                { data: 'salary' },
                { data: 'office' }
            ]
        })
    });
}