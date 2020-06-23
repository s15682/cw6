
using Cw6.DAL;
using Cw6.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.DAL
{
    public class SqlDbService : IDbService
    {
        private const string ConString = "Data Source=DESKTOP-LVH8UIJ;Initial Catalog=APBD_DB;Integrated Security=True";

        public IEnumerable<Student> GetStudents()
        {
            List<Student> studentList = new List<Student>();
            using (var client = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = client;
                com.CommandText = " select Student.FirstName, Student.LastName, Student.IndexNumber, Student.IdEnrollment "
                                    + "From Student;";

                client.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    studentList.Add(new Student(dr["IndexNumber"].ToString(),
                                                dr["FirstName"].ToString(),
                                                dr["LastName"].ToString(),
                                                (int)dr["IdEnrollment"]
                                                ));
                }
            }
            return studentList;
        }
    }
}
