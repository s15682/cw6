using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "employee")]
    public class EnrollController : ControllerBase
    {
        [HttpGet]
        public IActionResult Enroll()
        {

            return Ok("Enroll ok");
        }
    }
}
