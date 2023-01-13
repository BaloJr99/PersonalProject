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

        [HttpGet]
        public async Task<IActionResult> GetAllPatients(){
            IEnumerable<PatientDTO> patients = await _patient.GetAllPatients();
            return Ok(patients);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}