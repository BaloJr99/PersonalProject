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
            if(await validateAppointment(appointmentDTO)){
                PatientsAppointment appointment = _mapper.Map<PatientsAppointment>(appointmentDTO);
                if(appointment.IdPatientsAppointments != Guid.Empty){
                    _uok.GetRepository<PatientsAppointment>().Update(appointment, excludeProperties: "IdPatient");
                }else{
                    await _uok.GetRepository<PatientsAppointment>().AddAsync(appointment);
                }
                await _uok.SaveChangesAsync();
            }
        }

        private async Task<bool> validateAppointment(PatientsAppointmentDTO appointmentDTO)
        {
            if(appointmentDTO.IdPatientsAppointments != Guid.Empty){
                PatientsAppointment patient = await _uok.GetRepository<PatientsAppointment>().GetByIdAsync(appointmentDTO.IdPatientsAppointments);
                if(patient.AssignationDate.Date == appointmentDTO.AssignationDate.Date){
                    return true;
                }else{
                    int count = await _uok.GetRepository<PatientsAppointment>().CountWhere(x => x.IdPatient == patient.IdPatient && x.AssignationDate.Date == appointmentDTO.AssignationDate.Date && x.AppointmentStatus != false);
                    if(count > 0){
                        throw new ApplicationException("An appointment is already scheduled for this day");
                    }else{
                        return true;
                    }
                }
            }else{
                int count = await _uok.GetRepository<PatientsAppointment>().CountWhere(x => x.IdPatient == appointmentDTO.IdPatient && x.AssignationDate.Date == appointmentDTO.AssignationDate.Date && x.AppointmentStatus != false);
                if(count > 0){
                    throw new ApplicationException("An appointment is scheduled for this day, please cancel this appointment and reschedule the appointment of the selected date or change the date");
                }else{
                    return true;
                }
            }
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

        public async Task CancelAppointment(Guid idAppointment)
        {
            PatientsAppointment appointment = await _uok.GetRepository<PatientsAppointment>().GetByIdAsync(idAppointment);
            appointment.AppointmentStatus = false;
            _uok.GetRepository<PatientsAppointment>().Update(appointment);
            await _uok.SaveChangesAsync();
        }

        public async Task<PatientsAppointmentDTO> GetPatientAppointment(Guid idPatientsAppointments)
        {
            PatientsAppointment appointments = await _uok.GetRepository<PatientsAppointment>().GetByIdAsync(idPatientsAppointments);
            PatientsAppointmentDTO  patientsAppointment = _mapper.Map<PatientsAppointmentDTO>(appointments);
            Patient patient = await _uok.GetRepository<Patient>().GetByIdAsync(patientsAppointment.IdPatient);
            patientsAppointment.PatientFullName = string.Concat(patient.Name, " ", patient.LastName);
            return patientsAppointment;
        }
    }   
}