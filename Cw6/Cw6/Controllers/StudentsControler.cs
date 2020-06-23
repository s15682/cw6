using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Cw6.DAL;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace Cw6.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsControler : ControllerBase
    {
        private readonly IDbService dbService; 

        public StudentsControler(IDbService dbService)
        {
            this.dbService = dbService; 
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

    }
}
