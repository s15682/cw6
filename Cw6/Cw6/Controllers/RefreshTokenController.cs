using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cw6.DAL;
using Cw6.DTOs;
using Cw6.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshTokenController : ControllerBase
    {
        private readonly IDbService dbService;
        public IConfiguration Configuration { get; set; }

        public RefreshTokenController(IDbService dbService, IConfiguration configuration)
        {
            this.dbService = dbService;
            Configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(RefreshRequestDto refreshToken)
        {
            if (!dbService.CheckForCorrectRefreshToken(refreshToken))
            {
                return BadRequest("Wymagane ponowne zalogowanie");
            }

            return Ok(new
            {
                token = JWTCreator.CreateJWT(refreshToken.Login, Configuration),
                refreshToken = RefreshTokenCreator.CreateRefreshToken(dbService, refreshToken.Login)
            });
        }
    }
}
