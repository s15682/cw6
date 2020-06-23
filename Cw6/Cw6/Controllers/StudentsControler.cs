using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Cw6.DAL;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using Cw6.DTOs;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Cw6.Handlers;

namespace Cw6.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsControler : ControllerBase
    {
        private readonly IDbService dbService;
        public IConfiguration Configuration { get; set; }
       
        public StudentsControler(IDbService dbService, IConfiguration configuration)
        {
            this.dbService = dbService;
            Configuration = configuration;
        }


        [HttpGet]
        [Authorize(Roles = "student")]
        public IActionResult GetStudents()
        {
            IEnumerable<Student> students = dbService.GetStudents();
            IEnumerable<String> studentsFullList = createResponseList(students); 
            return Ok(studentsFullList); 
        }

        private IEnumerable<string> createResponseList(IEnumerable<Student> students)
        {
            List<string> responseList = new List<string>();
            int i = 1; 
            foreach( Student st in students)
            {
                responseList.Add( "Lp: "+(i++)+" "+st.ToString());
            }
            return responseList; 
        }

        [HttpPost]
        public IActionResult Login(LoginRequestDto request)
        {
            if(!dbService.CheckForCorrectPassword(request))
            {
                return BadRequest("Hasło nie pasuje do wpisanego loginu");  
            }

            return Ok(new
            {
                token = JWTCreator.CreateJWT(request.Login, Configuration),
                refreshToken = RefreshTokenCreator.CreateRefreshToken(dbService, request.Login)
            });
        }

        
    }
}
