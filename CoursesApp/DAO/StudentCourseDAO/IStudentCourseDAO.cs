using CoursesApp.Model;

namespace CoursesApp.DAO.StudentCourseDAO
{
    public interface IStudentCourseDAO
    {

        void Insert(StudentCourse? studentCourse);
        void Update(StudentCourse? currStudentCourse, StudentCourse? newStudentCourse);
        StudentCourse? Delete(StudentCourse? studentCourse);
        StudentCourse_Joined? GetStudentCourse(int studentId, int courseId);
        List<StudentCourse_Joined> GetAll();
        List<StudentCourse_Joined> GetAllByStudent(int studentId);

    }
}
