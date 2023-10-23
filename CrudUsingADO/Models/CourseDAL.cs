using System.Data.SqlClient;

namespace CrudUsingADO.Models
{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CourseDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            string qry = "select * from course";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Course course = new Course();
                    course.Id = Convert.ToInt32(dr["id"]);
                    course.Name = dr["name"].ToString();
                    course.Fees = Convert.ToDouble(dr["fees"]);
                    course.Duration = dr["duration"].ToString();


                    courses.Add(course);
                }
            }
            con.Close();
            return courses;
        }
        public Course GetCourseById(int id)
        {
            Course course = new Course();
            string qry = "select * from course where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    course.Id = Convert.ToInt32(dr["id"]);
                    course.Name = dr["name"].ToString();
                    course.Fees = Convert.ToDouble(dr["fees"]);
                    course.Duration = dr["duration"].ToString();

                }
            }
            con.Close();
            return course;
        }

        public int AddCourse(Course course)
        {
            int result = 0;
            string qry = "insert into course values(@name,@fees,@duration)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", course.Name);
            cmd.Parameters.AddWithValue("@fees", course.Fees);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateCourse(Course course)
        {
            int result = 0;
            string qry = "update course set name=@name,fees=@fees,duration=@duration where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", course.Name);
            cmd.Parameters.AddWithValue("@fees", course.Fees);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            cmd.Parameters.AddWithValue("@id", course.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCourse(int id)
        {
            int result = 0;
            string qry = "delete from course where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
