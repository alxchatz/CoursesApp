using CoursesApp.DAO.CourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using CoursesApp.Service;

namespace CoursesApp.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService courseService;

        internal string errorMessage = string.Empty;

        public DeleteModel()
        {
            courseService = new CourseServiceImpl(courseDAO);
        }

        
        public void OnGet()
        {

            try
            {
                Course? course;
                CourseDTO courseDTO = new CourseDTO();
                int id = int.Parse(Request.Query["id"]);

                courseDTO.Id = id;
                course = courseService.DeleteCourse(courseDTO);
                Response.Redirect("/Courses/Index/");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }
    }
}
