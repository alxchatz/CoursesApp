using CoursesApp.Model;

namespace CoursesApp.DAO.CourseDAO
{
    public interface ICourseDAO
    {

        void Insert(Course? Course);
        void Update(Course? Course);
        Course? Delete(Course? Course);
        Course? GetCourse(int id);
        List<Course> GetAll();

    }
}
