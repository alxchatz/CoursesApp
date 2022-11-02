using CoursesApp.DAO.DBUtil;
using CoursesApp.Model;
using System.Data.SqlClient;

namespace CoursesApp.DAO.StudentCourseDAO
{
    public class StudentCourseDAOImpl : IStudentCourseDAO
    {
        public StudentCourse? Delete(StudentCourse? studentCourse)
        {
            if (studentCourse is null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "DELETE FROM STUDENTCOURSE WHERE STUDENT_ID = @STUDENTID AND COURSE_ID = @COURSEID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@STUDENTID", studentCourse.StudentId);
                sqlCommand.Parameters.AddWithValue("@COURSEID", studentCourse.CourseId);

                int rowsAffected = sqlCommand.ExecuteNonQuery();

                return rowsAffected == 0 ? null : studentCourse;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

        }

        public List<StudentCourse_Joined> GetAll()
        {
            List<StudentCourse_Joined> studentCourses = new List<StudentCourse_Joined>();
            try
            {

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlStr = "SELECT STUDENTCOURSE.*," +
                                "       STUDENTS.FIRSTNAME AS STUDENTFIRSTNAME," +
                                "       STUDENTS.LASTNAME AS STUDENTLASTNAME," +
                                "       COURSES.DESCRIPTION AS COURSEDESCRIPTION " +
                                "FROM STUDENTCOURSE " +
                                "LEFT OUTER JOIN STUDENTS ON " +
                                "   STUDENTCOURSE.STUDENT_ID = STUDENTS.ID " +
                                "LEFT OUTER JOIN COURSES ON " +
                                "   STUDENTCOURSE.COURSE_ID = COURSES.ID";

                using SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    StudentCourse_Joined studentCourse = new StudentCourse_Joined()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1),
                        StudentFirstname = reader.GetString(2),
                        StudentLastName = reader.GetString(3),
                        CourseDescription = reader.GetString(4)
                    };

                    studentCourses.Add(studentCourse);
                }

                return studentCourses;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<StudentCourse_Joined> GetAllByStudent(int studentId)
        {
            List<StudentCourse_Joined> studentCourses = new List<StudentCourse_Joined>();
            try
            {

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlStr = "SELECT STUDENTCOURSE.*," +
                                "       STUDENTS.FIRSTNAME AS STUDENTFIRSTNAME," +
                                "       STUDENTS.LASTNAME AS STUDENTLASTNAME," +
                                "       COURSES.DESCRIPTION AS COURSEDESCRIPTION " +
                                "FROM STUDENTCOURSE " +
                                "LEFT OUTER JOIN STUDENTS ON " +
                                "   STUDENTCOURSE.STUDENT_ID = STUDENTS.ID " +
                                "LEFT OUTER JOIN COURSES ON " +
                                "   STUDENTCOURSE.COURSE_ID = COURSES.ID " +
                                "WHERE STUDENTCOURSE.STUDENT_ID = @STUDENTID";

                using SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);

                sqlCommand.Parameters.AddWithValue("@STUDENTID", studentId);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    StudentCourse_Joined studentCourse = new StudentCourse_Joined()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1),
                        StudentFirstname = reader.GetString(2),
                        StudentLastName = reader.GetString(3),
                        CourseDescription = reader.GetString(4)
                    };

                    studentCourses.Add(studentCourse);
                }

                return studentCourses;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public StudentCourse_Joined? GetStudentCourse(int studentId, int courseId)
        {
            try
            {
                StudentCourse_Joined? studentCourse = new();

                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlStr = "SELECT STUDENTCOURSE.*," +
                                "       STUDENTS.FIRSTNAME AS STUDENTFIRSTNAME," +
                                "       STUDENTS.LASTNAME AS STUDENTLASTNAME," +
                                "       COURSES.DESCRIPTION AS COURSEDESCRIPTION " +
                                "FROM STUDENTCOURSE " +
                                "LEFT OUTER JOIN STUDENTS ON " +
                                "   STUDENTCOURSE.STUDENT_ID = STUDENTS.ID " +
                                "LEFT OUTER JOIN COURSES ON " +
                                "   STUDENTCOURSE.COURSE_ID = COURSES.ID " +
                                "WHERE STUDENTCOURSE.STUDENT_ID = @STUDENTID AND STUDENTCOURSE.COURSE_ID = @COURSEID";

                using SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);

                sqlCommand.Parameters.AddWithValue("@STUDENTID", studentCourse.StudentId);
                sqlCommand.Parameters.AddWithValue("@COURSEID", studentCourse.CourseId);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    studentCourse = new StudentCourse_Joined()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1),
                        StudentFirstname = reader.GetString(2),
                        StudentLastName = reader.GetString(3),
                        CourseDescription = reader.GetString(4)
                    };

                }

                return studentCourse;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(StudentCourse? studentCourse)
        {
            if (studentCourse is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "INSERT INTO STUDENTCOURSE (STUDENT_ID, COURSE_ID)" +
                                 "VALUES (@STUDENTID, @COURSEID)";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@STUDENTID", studentCourse.StudentId);
                sqlCommand.Parameters.AddWithValue("@COURSEID", studentCourse.CourseId);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(StudentCourse? currStudentCourse, StudentCourse? newStudentCourse)
        {
            if ((currStudentCourse is null) || (newStudentCourse is null)) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sqlText = "UPDATE STUDENTCOURSE SET STUDENT_ID = @NEWSTUDENTID, COURSE_ID = @NEWCOURSEID WHERE STUDENT_ID = @CURRSTUDENTID AND COURSE_ID = @CURRCOURSEID";

                using SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                sqlCommand.Parameters.AddWithValue("@CURRSTUDENTID", currStudentCourse.StudentId);
                sqlCommand.Parameters.AddWithValue("@CURRCOURSEID", currStudentCourse.CourseId);
                sqlCommand.Parameters.AddWithValue("@NEWSTUDENTID", newStudentCourse.StudentId);
                sqlCommand.Parameters.AddWithValue("@NEWCOURSEID", newStudentCourse.CourseId);

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
