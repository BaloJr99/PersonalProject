using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProject.Data.DTO;

namespace PersonalProject.Business.Interfaces
{
    public interface IMedicalAppointmentsService
    {
        Task<IEnumerable<PatientsAppointmentDTO>> GetTodayMedicalAppointments();
        Task SaveAppointment(PatientsAppointmentDTO appointmentDTO);
        Task<IEnumerable<PatientsAppointmentDTO>> SearchAppointments(SearchPatientsAppointments search);
    }
}