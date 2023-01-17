using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalProject.Business.Interfaces;
using PersonalProject.Data.DTO;

namespace PersonalProject.Client.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly IPatientService _patient;

        public PatientsController(ILogger<PatientsController> logger, IPatientService patient)
        {
            _logger = logger;
            _patient = patient;
        }

        public IActionResult Index(){
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients(){
            IEnumerable<PatientDTO> patients = await _patient.GetAllPatients();
            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> SavePatient(PatientDTO patientDTO, AddressDTO addressDTO){
            await _patient.SavePatient(patientDTO, addressDTO);
            return Ok(new {success = true});
        }

        [HttpGet]
        public async Task<IActionResult> SearchPatients([FromQuery]SearchPatient searchPatient){
            IEnumerable<PatientDTO> patients = await _patient.SearchPatient(searchPatient);
            return Ok(patients);
        }

        [HttpGet]
        [Route("Patients/GetPatient/{idPatient}")]
        public async Task<IActionResult> GetPatient([FromRoute]Guid idPatient){
            PatientDTO patient = await _patient.GetPatient(idPatient);
            return Ok(patient);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}