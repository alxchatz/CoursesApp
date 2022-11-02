using CoursesApp.DAO.CourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.Model;
using CoursesApp.Service;
using System.Runtime.CompilerServices;

namespace CoursesApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService courseService;

        internal List<Course_Joined> courses = new();

        public IndexModel()
        {
            courseService = new CourseServiceImpl(courseDAO);
        }

        public void OnGet()
        {

            courses = courseService.GetAllCourses();
            //return Page(); //in case the method is void, return is implied
        }

    }
}
