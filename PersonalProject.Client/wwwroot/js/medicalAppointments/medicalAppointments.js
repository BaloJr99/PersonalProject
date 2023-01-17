$(document).ready(() => {
    $(document).on("click", "#btnAppointmentModal", showAppointmentModal)
    $(document).on("click", "#btnSearchAppointment", searchAppointments)
    $(document).on("click", "#btnSaveAppointment", saveAppointment)
    loadMedicalAppointMents();
})

var table = undefined;

const searchAppointments = e => {
    e.preventDefault();
    var formData = new FormData($("#appointmentsForm")[0]);
    $.ajax({
        type: "POST",
        url: "/MedicalAppointments/SearchAppointments",
        data: formData,
    }).done((appointments) => {
        if(table != undefined){
            $("#appointmentsTable").empty();
            table.destroy();
        }
        table = $("#appointmentsTable").DataTable({
            data: appointments,
            bFilter: false,
            lengthChange: false,
            columns: [
                { data: 'assignationDate', title:"Assignation Date", render:(data, type, row) => {
                    if(type == "display"){
                        return `${row.assignationDate.split("T")[0]}`
                    }
                    return data;
                },
                className:"text-center" },
                { data: 'assignationDate', title:"Assignation Date", render:(data, type, row) => {
                    if(type == "display"){
                        return `${row.assignationDate.split("T")[1].replace(/(:\d{2}| [AP]M)$/, "")}`
                    }
                    return data;
                },
                className:"text-center" },
                { data: 'patientFullName', title:"Patient Full Name", className:"text-center" },
                { data: 'appointmentStatus', title:"Status", render:(data, type, row) => {
                    if(type == "display"){
                        if(row.appointmentStatus){
                            return `<span class="badge bg-success text-light">Active</span>`
                        }else{
                            return `<span class="badge bg-danger text-light">Inactive</span>`
                        }
                    }
                    return data;
                },
                className:"text-center" },
                { data: 'idPatientsAppointments', width: "100px", title:"Action", render:(data, type, row) => {
                    if(type == "display"){
                        if(row.appointmentStatus){
                            return `<div class="d-flex justify-content-between"><button class="btn btn-sm btn-outline-dark d-flex justify-content-center align-items-center" id="btnReschedule" data-id=${row.idPatientsAppointments}>
                            <span class="material-symbols-outlined">Cancel</span> &nbspReschedule</button>
                            <button class="btn btn-sm btn-outline-danger d-flex justify-content-center align-items-center" id="btnCancel" data-id=${row.idPatientsAppointments}>
                            <span class="material-symbols-outlined">Cancel</span> &nbspCancel</button></div>`
                        }else{
                            return ``
                        }
                    }
                    return data;
                },
                className:"text-center" }
            ]
        })
    });
}

const saveAppointment = e => {
    e.preventDefault();
    if($("#appointmentForm").valid()){
        var formData = new FormData($("#appointmentForm")[0]);

        $("body").waitMe({text: "Getting Patients"});
        $.ajax({
            type: "POST",
            url: "/MedicalAppointments/SaveAppointment",
            data: formData,
        }).done((response) => {
            if(response.success){
                successAlert("Appointment Registered");
                $("#appointmentModal").modal("hide");
                $("#appointmentForm")[0].reset();
                $("body").waitMe("hide");
                loadMedicalAppointMents();
            }
        });
    }
    
}

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
            $("#IdPatient").append(`<option value="${patient.idPatient}">${patient.name} ${patient.lastName}</option>`);
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
            lengthChange: false,
            columns: [
                { data: 'assignationDate', title:"Date", render:(data, type, row) => {
                    if(type == "display"){
                        return `${row.assignationDate.split("T")[0]}`
                    }
                    return data;
                },
                className:"text-center" },
                { data: 'assignationDate', title:"Hour", render:(data, type, row) => {
                    if(type == "display"){
                        return `${row.assignationDate.split("T")[1].replace(/(:\d{2}| [AP]M)$/, "")}`
                    }
                    return data;
                },
                className:"text-center" },
                { data: 'patientFullName', title:"Patient Full Name", width: "auto", className:"text-center" },
                { data: 'appointmentStatus', title:"Status", render:(data, type, row) => {
                    if(type == "display"){
                        if(row.appointmentStatus){
                            return `<span class="badge bg-success text-light">Active</span>`
                        }else{
                            return `<span class="badge bg-danger text-light">Inactive</span>`
                        }
                    }
                    return data;
                },
                className:"text-center" },
                { data: 'idPatientsAppointments', title:"Action", width:"100px", render:(data, type, row) => {
                    if(type == "display"){
                        if(row.appointmentStatus){
                            return `<div class="d-flex justify-content-between"><button class="btn btn-sm btn-outline-dark d-flex justify-content-center align-items-center" id="btnCancel" data-id=${row.idPatientsAppointments}>
                            <span class="material-symbols-outlined">Cancel</span> &nbspReschedule</button>
                            <button class="btn btn-sm btn-outline-danger d-flex justify-content-center align-items-center" id="btnEditPatient" data-id=${row.idPatientsAppointments}>
                            <span class="material-symbols-outlined">Cancel</span> &nbspCancel</button></div>`
                        }else{
                            return ``
                        }
                    }
                    return data;
                },
                className:"text-center" }
            ]
        })
    });
}