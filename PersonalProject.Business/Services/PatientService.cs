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

        public async Task<PatientDTO> GetPatient(Guid idPatient)
        {
            Patient patient = await _uok.GetRepository<Patient>().GetByIdAsync(idPatient);
            return _mapper.Map<PatientDTO>(patient);
        }

        public async Task SavePatient(PatientDTO patientDTO, AddressDTO addressDTO)
        {
            try
            {
                await _uok.CreateTransactionAsync();

                Address address = _mapper.Map<Address>(addressDTO);
                await _uok.GetRepository<Address>().AddAsync(address);
                await _uok.SaveChangesAsync();
            
                Patient patient = _mapper.Map<Patient>(patientDTO);
                patient.IdAddress = address.IdAddress;
                await _uok.GetRepository<Patient>().AddAsync(patient);
                await _uok.SaveChangesAsync();

                await _uok.CommitAsync();
            }
            catch (System.Exception ex)
            {
                await _uok.RollbackAsync();
                throw new ApplicationException($"Ocurrio un error {ex.Message}");
            }
        }

        public async Task<IEnumerable<PatientDTO>> SearchPatient(SearchPatient searchPatient)
        {
            IEnumerable<Patient> patients = await _uok.GetRepository<Patient>().GetAsync(x => 
                (string.IsNullOrEmpty(searchPatient.Gender) ? true : x.Gender == searchPatient.Gender) &&
                (searchPatient.Birthday == null ? true : x.Birthday == searchPatient.Birthday) &&
                (string.IsNullOrEmpty(searchPatient.FullName) ? true : string.Concat(x.Name, " ", x.LastName).Contains(searchPatient.FullName)), includeProperties: "IdAddressNavigation");
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }
    }
}