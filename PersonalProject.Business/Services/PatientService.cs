using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProject.Business.Interfaces;
using PersonalProject.Data.DTO;
using PersonalProject.Business.IUnitOfWork.Interfaces;
using AutoMapper;
using PersonalProject.Data.Models;

namespace PersonalProject.Business.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWorkPersonal _uok;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWorkPersonal uok, IMapper mapper)
        {
            _uok = uok;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PatientDTO>> GetAllPatients()
        {
            IEnumerable<Patient> patients = await _uok.GetRepository<Patient>().GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }
    }
}