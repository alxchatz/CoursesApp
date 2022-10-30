using CoursesApp.DAO.CourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DTO;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using CoursesApp.DAO.TeacherDAO;
using CoursesApp.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoursesApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService courseService;

        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService teacherService;

        public CreateModel()
        {
            courseService = new CourseServiceImpl(courseDAO);
            teacherService = new TeacherServiceImpl(teacherDAO);
        }

        internal CourseDTO courseDTO = new();
        internal string errorMessage = string.Empty;
        internal List<SelectListItem> teachersList = new();

        public void OnGet()
        {
            List<Teacher> teachers = teacherService.GetAllTeachers();
            teachersList = teachers.Select(x => new SelectListItem { Text = x.Firstname + " " + x.Lastname, Value = x.Id.ToString() }).ToList();
        }

        public void OnPost()
        {
            courseDTO.Description = Request.Form["description"];
            if (!string.IsNullOrEmpty(Request.Form["teacherid"])) courseDTO.TeacherId = int.Parse(Request.Form["teacherid"]);

            errorMessage = ValidateCourse(courseDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

            try
            {
                courseService.InsertCourse(courseDTO);
                Response.Redirect("/Courses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
