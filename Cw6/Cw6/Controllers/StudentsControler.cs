﻿using System;
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

            var claims = new[]
{
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "jan123"),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.Role, "student")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "Gakko",
                audience: "Students",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = Guid.NewGuid()
            });
        }

    }
}
