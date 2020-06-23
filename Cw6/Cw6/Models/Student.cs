using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdEnrollment { get; set; }


        public Student (string index, string name, string lastName, int idEnrollment)
        {
            IndexNumber = index;
            FirstName = name;
            LastName = lastName;
            IdEnrollment = idEnrollment;
        }

        public Student() { }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + IndexNumber + " " + IdEnrollment; 
        }

    }
}
