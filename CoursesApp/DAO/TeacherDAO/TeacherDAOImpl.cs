using CoursesApp.DAO.DBUtil;
using CoursesApp.DAO.TeacherDAO;
using CoursesApp.Model;
using System.Data.SqlClient;

namespace CoursesApp.DAO.TeacherDAO
{
    public class TeacherDAOImpl : ITeacherDAO
    {
        public Teacher? Delete(Teacher? teacher)
        {
            if (teacher is null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "DELETE FROM TEACHERS WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", teacher.Id);

                int rowsAffected = sqlCommand.ExecuteNonQuery();

                return rowsAffected == 0 ? null : teacher;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

        }

        public List<Teacher> GetAll()
        {
            List<Teacher> Teachers = new List<Teacher>();
            try
            {

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlStr = "SELECT * FROM TEACHERS";

                using SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Teacher Teacher = new Teacher()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                    Teachers.Add(Teacher);
                }

                return Teachers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Teacher? GetTeacher(int id)
        {
            try
            {
                Teacher? Teacher = new();

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "SELECT * FROM TEACHERS WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", id);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    Teacher = new Teacher()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                }

                return Teacher;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Teacher? Teacher)
        {
            if (Teacher is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "INSERT INTO TEACHERS (FIRSTNAME, LASTNAME)" +
                                 "VALUES (@FIRSTNAME, @LASTNAME)";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@FIRSTNAME", Teacher.Firstname);
                sqlCommand.Parameters.AddWithValue("@LASTNAME", Teacher.Lastname);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Teacher? Teacher)
        {
            if (Teacher is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "UPDATE TEACHERS SET FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME WHERE ID = @ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@ID", Teacher.Id);
                sqlCommand.Parameters.AddWithValue("@FIRSTNAME", Teacher.Firstname);
                sqlCommand.Parameters.AddWithValue("@LASTNAME", Teacher.Lastname);

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
