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
    public class AddressController : Controller
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _address;

        public AddressController(ILogger<AddressController> logger, IAddressService address)
        {
            _logger = logger;
            _address = address;
        }

        [HttpGet]
        [Route("Address/GetAddress/{idAddress}")]
        public async Task<IActionResult> GetAddressWithPatient([FromRoute]Guid idAddress){
            AddressDTO address = await _address.GetAddress(idAddress);
            return Ok(address);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}