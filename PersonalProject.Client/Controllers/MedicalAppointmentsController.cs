using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PersonalProject.Client.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MedicalAppointmentsController : Controller
    {
        private readonly ILogger<MedicalAppointmentsController> _logger;

        public MedicalAppointmentsController(ILogger<MedicalAppointmentsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}