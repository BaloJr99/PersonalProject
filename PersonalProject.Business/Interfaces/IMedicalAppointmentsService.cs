using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProject.Data.DTO;

namespace PersonalProject.Business.Interfaces
{
    public interface IMedicalAppointmentsService
    {
        Task CancelAppointment(Guid idAppointment);
        Task<PatientsAppointmentDTO> GetPatientAppointment(Guid idPatientsAppointments);
        Task<IEnumerable<PatientsAppointmentDTO>> GetTodayMedicalAppointments();
        Task SaveAppointment(PatientsAppointmentDTO appointmentDTO);
        Task<IEnumerable<PatientsAppointmentDTO>> SearchAppointments(SearchPatientsAppointments search);
    }
}