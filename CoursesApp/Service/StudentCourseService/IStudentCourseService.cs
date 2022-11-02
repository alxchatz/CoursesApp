using CoursesApp.DTO;
using CoursesApp.Model;

namespace CoursesApp.Service
{
    public interface IStudentCourseService
    {

        List<StudentCourse_Joined> GetAllStudentCourses();
        List<StudentCourse_Joined> GetAllStudentCoursesByStudent(int studentId);
        void InsertStudentCourse(StudentCourseDTO studentCourseDTO);
        void UpdateStudentCourse(StudentCourseDTO currStudentCourseDTO, StudentCourseDTO newStudentCourseDTO);
        StudentCourse? DeleteStudentCourse(StudentCourseDTO studentCourseDTO);
        StudentCourse_Joined? GetStudentCourse(int studentId, int courseId);

    }
}
