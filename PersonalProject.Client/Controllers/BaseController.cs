using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalProject.Data.DTO;

namespace PersonalProject.Client.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        public UserDTO? userDTO => (UserDTO?)HttpContext.Items["UserData"];
    }
}