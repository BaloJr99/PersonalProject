using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProject.Data.DTO;

namespace PersonalProject.Business.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatients();
        Task<PatientDTO> GetPatient(Guid idPatient);
        Task SavePatient(PatientDTO patientDTO, AddressDTO addressDTO);
        Task<IEnumerable<PatientDTO>> SearchPatient(SearchPatient searchPatient);
    }
}