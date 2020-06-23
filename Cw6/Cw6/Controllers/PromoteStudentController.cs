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
    public class PromoteStudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Promote()
        {

            return Ok("Promote ok");
        }
    }
}
