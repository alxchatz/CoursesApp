using CoursesApp.DTO;
using CoursesApp.Model;

namespace CoursesApp.Service
{
    public interface ICourseService
    {

        List<Course_Joined> GetAllCourses();
        void InsertCourse(CourseDTO courseDTO);
        void UpdateCourse(CourseDTO courseDTO);
        Course? DeleteCourse(CourseDTO courseDTO);
        Course_Joined? GetCourse(int id);

    }
}
