using CoursesApp.DAO.DBUtil;
using CoursesApp.Model;
using System.Data.SqlClient;

namespace CoursesApp.DAO.StudentDAO
{
    public class StudentDAOImpl : IStudentDAO
    {
        public Student? Delete(Student? student)
        {
            if (student is null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "DELETE FROM STUDENTS WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", student.Id);

                int rowsAffected = sqlCommand.ExecuteNonQuery();

                return rowsAffected == 0 ? null : student;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            try
            {

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlStr = "SELECT * FROM STUDENTS";

                using SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                    students.Add(student);
                }

                return students;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Student? GetStudent(int id)
        {
            try
            {
                Student? student = new();

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "SELECT * FROM STUDENTS WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", id);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                }

                return student;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Student? student)
        {
            if (student is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "INSERT INTO STUDENTS (FIRSTNAME, LASTNAME)" +
                                 "VALUES (@FIRSTNAME, @LASTNAME)";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@FIRSTNAME", student.Firstname);
                sqlCommand.Parameters.AddWithValue("@LASTNAME", student.Lastname);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Student? student)
        {
            if (student is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "UPDATE STUDENTS SET FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", student.Id);
                sqlCommand.Parameters.AddWithValue("@FIRSTNAME", student.Firstname);
                sqlCommand.Parameters.AddWithValue("@LASTNAME", student.Lastname);

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
