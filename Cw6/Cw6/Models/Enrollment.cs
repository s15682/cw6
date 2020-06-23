using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.Models
{
    //byt stworzony ponad potrzebę, ale przyda się pewnie później
    public class Enrollment
    {
        public int IdEnrollment { get; set; }
        public int Semester { get; set; }
        public Studies Studies { get; set; }
        public string StartDate { get; set; }

        public Enrollment() { }

        public Enrollment(int id, int semester, Studies studies, string startDate)
        {
            IdEnrollment = id;
            Semester = semester;
            Studies = studies;
            StartDate = startDate; 
        }



    }
}
