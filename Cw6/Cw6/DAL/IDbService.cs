
using Cw6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.DAL
{
    public interface IDbService
    {
        IEnumerable<Student> GetStudents();

        Student GetStudent(string studentID); 
    }
}
