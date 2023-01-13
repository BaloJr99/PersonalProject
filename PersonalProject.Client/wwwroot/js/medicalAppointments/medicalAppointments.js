$(document).ready(() => {
    loadMedicalAppointMents();
})

var table = undefined;

const loadMedicalAppointMents = () => {
    var formData = new FormData();
    $.ajax({
        url: "/MedicalAppointments/GetAppointments",
        data: formData,
    }).done((medicalData) => {
        
    });
}