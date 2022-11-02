using CoursesApp.DAO.CourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoursesApp.DAO.TeacherDAO;

namespace CoursesApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService courseService;
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService teacherService;

        public UpdateModel()
        {
            courseService = new CourseServiceImpl(courseDAO);
            teacherService = new TeacherServiceImpl(teacherDAO);
        }

        internal CourseDTO courseDTO = new();
        internal string errorMessage = string.Empty;
        internal List<SelectListItem> teachersList = new();

        public void OnGet()
        {

            try
            {
                Course? course;
                int id = int.Parse(Request.Query["id"]);

                course = courseService.GetCourse(id);
                if (course is not null) courseDTO = ExtractCourseDTO(course);

                List<Teacher> teachers = teacherService.GetAllTeachers();
                teachersList = teachers.Select(x => new SelectListItem { Text = x.Firstname + " " + x.Lastname, Value = x.Id.ToString() }).ToList();

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
            
        }

        public void OnPost()
        {
            errorMessage = string.Empty;
            // Get DTO
            courseDTO.Id = int.Parse(Request.Form["id"]);
            courseDTO.Description = Request.Form["description"];
            courseDTO.TeacherId = int.Parse(Request.Form["teacherid"]);

            //Validate
            errorMessage = ValidateCourse(courseDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage)) 
            {
                List<Teacher> teachers = teacherService.GetAllTeachers();
                teachersList = teachers.Select(x => new SelectListItem { Text = x.Firstname + " " + x.Lastname, Value = x.Id.ToString() }).ToList();
                return; 
            }

            try
            {
                courseService.UpdateCourse(courseDTO);
                Response.Redirect("/Courses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private CourseDTO ExtractCourseDTO(Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                Description = course.Description,
                TeacherId = course.TeacherId
            };
        }
    }
}
