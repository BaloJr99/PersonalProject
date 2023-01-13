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
            IEnumerable<PatientsAppointment> appointments = await _uok.GetRepository<PatientsAppointment>().GetWhereAsync(x => x.AssignationDate == DateTime.Today);
            return _mapper.Map<IEnumerable<PatientsAppointmentDTO>>(appointments);
        }
    }
}