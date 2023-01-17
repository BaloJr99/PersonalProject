using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalProject.Business.Interfaces;
using PersonalProject.Business.IUnitOfWork.Interfaces;
using PersonalProject.Data.DTO;
using PersonalProject.Data.Models;

namespace PersonalProject.Business.Services
{
    public class MedicalAppointmentsService : IMedicalAppointmentsService
    {

        private readonly IUnitOfWorkPersonal _uok;
        private readonly IMapper _mapper;

        public MedicalAppointmentsService(IUnitOfWorkPersonal uok, IMapper mapper)
        {
            _uok = uok;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientsAppointmentDTO>> GetTodayMedicalAppointments()
        {
            var todayMorning = DateTime.Now.Date;
            var todayAfterNoon = todayMorning.AddHours(24);
            IEnumerable<PatientsAppointment> appointments = await _uok.GetRepository<PatientsAppointment>().GetAsync(x => x.AssignationDate >= todayMorning && x.AssignationDate <= todayAfterNoon && x.AppointmentStatus == true, includeProperties: "IdPatientNavigation");
            return _mapper.Map<IEnumerable<PatientsAppointmentDTO>>(appointments);
        }
        
        public async Task SaveAppointment(PatientsAppointmentDTO appointmentDTO){
            PatientsAppointment appointment = _mapper.Map<PatientsAppointment>(appointmentDTO);
            await _uok.GetRepository<PatientsAppointment>().AddAsync(appointment);
            await _uok.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientsAppointmentDTO>> SearchAppointments(SearchPatientsAppointments search)
        {
            IEnumerable<PatientsAppointment> appointments = await _uok.GetRepository<PatientsAppointment>().GetAsync(x => 
                (search.InitialAssignationDate != null ? x.AssignationDate >= search.InitialAssignationDate : true) &&
                (search.Status != null ? x.AppointmentStatus == search.Status : true) &&
                (search.FinalAssignationDate != null ? x.AssignationDate <= search.FinalAssignationDate.Value.AddHours(24) : true) &&
                (search.PatientFullName != null ? string.Concat(x.IdPatientNavigation.Name, " ", x.IdPatientNavigation.LastName).Contains(search.PatientFullName) : true), includeProperties: "IdPatientNavigation");
            return _mapper.Map<IEnumerable<PatientsAppointmentDTO>>(appointments);
        }
    }   
}