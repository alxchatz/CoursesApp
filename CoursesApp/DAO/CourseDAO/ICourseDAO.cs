using CoursesApp.Model;

namespace CoursesApp.DAO.CourseDAO
{
    public interface ICourseDAO
    {

        void Insert(Course? Course);
        void Update(Course? Course);
        Course? Delete(Course? Course);
        Course_Joined? GetCourse(int id);
        List<Course_Joined> GetAll();

    }
}
