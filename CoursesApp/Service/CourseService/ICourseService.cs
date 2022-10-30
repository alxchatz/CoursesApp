using CoursesApp.DTO;
using CoursesApp.Model;

namespace CoursesApp.Service
{
    public interface ICourseService
    {

        List<Course> GetAllCourses();
        void InsertCourse(CourseDTO courseDTO);
        void UpdateCourse(CourseDTO courseDTO);
        Course? DeleteCourse(CourseDTO courseDTO);
        Course? GetCourse(int id);

    }
}
