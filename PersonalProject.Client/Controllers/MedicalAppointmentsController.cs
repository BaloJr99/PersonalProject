using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalProject.Business.Interfaces;
using PersonalProject.Data.DTO;

namespace PersonalProject.Client.Controllers
{
    [Authorize(Roles = "Admin, Medical Services")]
    public class MedicalAppointmentsController : Controller
    {
        private readonly ILogger<MedicalAppointmentsController> _logger;
        private readonly IMedicalAppointmentsService _medical;

        public MedicalAppointmentsController(ILogger<MedicalAppointmentsController> logger, IMedicalAppointmentsService medical)
        {
            _logger = logger;
            _medical = medical;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTodayAppointments()
        {
            IEnumerable<PatientsAppointmentDTO> patients = await _medical.GetTodayMedicalAppointments();
            return Ok(patients);
        }

        [HttpGet]
        [Route("/MedicalAppointments/CancelAppointment/{idAppointment}")]
        public async Task<IActionResult> CancelAppointment(Guid idAppointment)
        {
            await _medical.CancelAppointment(idAppointment);
            return Ok(new { success = true });
        }

        [HttpGet]
        [Route("/MedicalAppointments/GetPatientAppointment/{idPatientsAppointments}")]
        public async Task<IActionResult> GetPatientAppointment(Guid idPatientsAppointments)
        {
            PatientsAppointmentDTO patientsAppointment = await _medical.GetPatientAppointment(idPatientsAppointments);
            return Ok(patientsAppointment);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAppointment([FromForm]PatientsAppointmentDTO appointmentDTO)
        {
            appointmentDTO.AppointmentStatus = true;
            await _medical.SaveAppointment(appointmentDTO);
            return Ok(new {success = true});
        }

        [HttpPost]
        public async Task<IActionResult> SearchAppointments([FromForm]SearchPatientsAppointments search)
        {
            IEnumerable<PatientsAppointmentDTO> appointments = await _medical.SearchAppointments(search);
            return Ok(appointments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}