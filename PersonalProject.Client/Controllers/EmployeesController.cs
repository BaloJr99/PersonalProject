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
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employee;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employee)
        {
            _logger = logger;
            _employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(){
            IEnumerable<EmployeeDTO> employees = await _employee.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployee(EmployeeDTO employeeDTO, AddressDTO addressDTO){
            await _employee.SaveEmployee(employeeDTO, addressDTO);
            return Ok(new { success = true });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}