using CoursesApp.DAO.DBUtil;
using CoursesApp.DAO.CourseDAO;
using CoursesApp.Model;
using System.Data.SqlClient;

namespace CoursesApp.DAO.CourseDAO
{
    public class CourseDAOImpl : ICourseDAO
    {
        public Course? Delete(Course? course)
        {
            if (course is null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "DELETE FROM COURSES WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", course.Id);

                int rowsAffected = sqlCommand.ExecuteNonQuery();

                return rowsAffected == 0 ? null : course;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

        }

        public List<Course> GetAll()
        {
            List<Course> Courses = new List<Course>();
            try
            {

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlStr = "SELECT COURSES.*," +
                                "       TEACHERS.FIRSTNAME + ' ' + TEACHERS.LASTNAME AS TEACHERFULLNAME " +
                                "FROM COURSES " +
                                "LEFT OUTER JOIN TEACHERS ON" +
                                "   COURSES.TEACHER_ID = TEACHERS.ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Course Course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2),
                        TeacherFullName = reader.GetString(3)
                    };

                    Courses.Add(Course);
                }

                return Courses;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Course? GetCourse(int id)
        {
            try
            {
                Course? Course = new();

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "SELECT * FROM COURSES WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", id);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    Course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2)
                    };

                }

                return Course;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Course? course)
        {
            if (course is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "INSERT INTO COURSES (DESCRIPTION, TEACHER_ID)" +
                                 "VALUES (@DESCRIPTION, @TEACHERID)";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@DESCRIPTION", course.Description);
                sqlCommand.Parameters.AddWithValue("@TEACHERID", course.TeacherId);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Course? course)
        {
            if (course is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "UPDATE COURSES SET DESCRIPTION = @DESCRIPTION, TEACHER_ID = @TEACHERID WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", course.Id);
                sqlCommand.Parameters.AddWithValue("@DESCRIPTION", course.Description);
                sqlCommand.Parameters.AddWithValue("@TEACHERID", course.TeacherId);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
