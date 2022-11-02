using CoursesApp.DAO.StudentCourseDAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using System.Reflection.PortableExecutable;

namespace CoursesApp.Service
{
    public class StudentCourseServiceImpl : IStudentCourseService
    {

        private readonly IStudentCourseDAO studentCourseDAO;

        public StudentCourseServiceImpl(IStudentCourseDAO studentCourseDAO)
        {
            this.studentCourseDAO = studentCourseDAO;
        }

        public StudentCourse? DeleteStudentCourse(StudentCourseDTO studentCourseDTO)
        {
            if (studentCourseDTO is null) return null;

            try
            {
                StudentCourse? studentCourse = ExtractStudentCourse(studentCourseDTO);

                return studentCourseDAO.Delete(studentCourse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<StudentCourse_Joined> GetAllStudentCourses()
        {
            try
            {
                return studentCourseDAO.GetAll();
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<StudentCourse_Joined>();
            }
        }

        public List<StudentCourse_Joined> GetAllStudentCoursesByStudent(int studentId)
        {
            try
            {
                return studentCourseDAO.GetAllByStudent(studentId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<StudentCourse_Joined>();
            }
        }

        public StudentCourse_Joined? GetStudentCourse(int studentId, int courseId)
        {
            try
            {
                return studentCourseDAO.GetStudentCourse(studentId, courseId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertStudentCourse(StudentCourseDTO studentCourseDTO)
        {
            if (studentCourseDTO is null) return;

            try
            {
                StudentCourse? studentCourse = ExtractStudentCourse(studentCourseDTO);

                studentCourseDAO.Insert(studentCourse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateStudentCourse(StudentCourseDTO currStudentCourseDTO, StudentCourseDTO newStudentCourseDTO)
        {
            if ((currStudentCourseDTO is null) || (newStudentCourseDTO is null)) return;

            try
            {
                StudentCourse? currStudentCourse = ExtractStudentCourse(currStudentCourseDTO);
                StudentCourse? newStudentCourse = ExtractStudentCourse(newStudentCourseDTO);

                studentCourseDAO.Update(currStudentCourse, newStudentCourse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private StudentCourse? ExtractStudentCourse(StudentCourseDTO studentCourseDTO)
        {
            if (studentCourseDTO is null) return null;

            StudentCourse studentCourse = new StudentCourse()
            {
                StudentId = studentCourseDTO.StudentId,
                CourseId = studentCourseDTO.CourseId
            };

            return studentCourse;
        }
    }
}
