using MVCLab001.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MVCLab001.Services
{
    public class courseService
    {

        private readonly  IConfiguration config;
        public courseService(IConfiguration _config)
        {
            config = _config;
        }
        public List<CourseMdl> getCourses()
        {
            List<CourseMdl> courses = new List<CourseMdl>();

            using (SqlConnection cn = new SqlConnection(config.GetConnectionString("sqlcnn")))
            {
                cn.Open();
                string sql = "select courseID,cname,Rating from course";
                SqlCommand sqlCommand = new SqlCommand(sql, cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new CourseMdl() { courseID =reader.GetInt32(0), cname=reader.GetString(1), Rating=reader.GetInt32(2) });
                }

                reader.Close();
                cn.Close();
               
            }
            
            return courses;
        }
    }
}
