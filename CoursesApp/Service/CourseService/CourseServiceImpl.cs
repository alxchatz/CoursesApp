using CoursesApp.DAO.CourseDAO;
using CoursesApp.DTO;
using CoursesApp.Model;

namespace CoursesApp.Service
{
    public class CourseServiceImpl : ICourseService
    {

        private readonly ICourseDAO courseDAO;

        public CourseServiceImpl(ICourseDAO courseDAO)
        {
            this.courseDAO = courseDAO;
        }

        public Course? DeleteCourse(CourseDTO courseDTO)
        {
            if (courseDTO is null) return null;

            try
            {
                Course? Course = ExtractCourse(courseDTO);

                return courseDAO.Delete(Course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return courseDAO.GetAll();
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }

        public Course? GetCourse(int id)
        {
            try
            {
                return courseDAO.GetCourse(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertCourse(CourseDTO courseDTO)
        {
            if (courseDTO is null) return;

            try
            {
                Course? Course = ExtractCourse(courseDTO);

                courseDAO.Insert(Course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateCourse(CourseDTO courseDTO)
        {
            if (courseDTO is null) return;

            try
            {
                Course? Course = ExtractCourse(courseDTO);

                courseDAO.Update(Course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Course? ExtractCourse(CourseDTO courseDTO)
        {
            if (courseDTO is null) return null;

            Course course = new Course()
            {
                Id = courseDTO.Id,
                Description = courseDTO.Description,
                TeacherId = courseDTO.TeacherId
            };

            return course;
        }
    }
}
