using CoursesApp.DAO.StudentCourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DTO;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;
using CoursesApp.DAO.CourseDAO;
using CoursesApp.DAO.StudentDAO;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoursesApp.Model;

namespace CoursesApp.Pages.StudentCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService studentCourseService;

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService courseService;

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService studentService;

        public CreateModel()
        {
            studentCourseService = new StudentCourseServiceImpl(studentCourseDAO);
            courseService = new CourseServiceImpl(courseDAO);
            studentService = new StudentServiceImpl(studentDAO);
        }

        internal StudentCourseDTO studentCourseDTO = new();
        internal string errorMessage = string.Empty;
        internal List<SelectListItem> studentsList = new();
        internal List<SelectListItem> coursesList = new();

        public void OnGet()
        {
            List<Student> students = studentService.GetAllStudents();
            List<Course_Joined> courses = courseService.GetAllCourses();
            studentsList = students.Select(x => new SelectListItem { Text = x.Firstname + " " + x.Lastname, Value = x.Id.ToString() }).ToList();
            coursesList = courses.Select(x => new SelectListItem { Text = x.Description, Value = x.Id.ToString() }).ToList();
        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Request.Form["studentid"])) studentCourseDTO.StudentId = int.Parse(Request.Form["studentid"]);
            if (!string.IsNullOrEmpty(Request.Form["courseid"])) studentCourseDTO.CourseId = int.Parse(Request.Form["courseid"]);

            errorMessage = ValidateStudentCourse(studentCourseDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                List<Student> students = studentService.GetAllStudents();
                List<Course_Joined> courses = courseService.GetAllCourses();
                studentsList = students.Select(x => new SelectListItem { Text = x.Firstname + " " + x.Lastname, Value = x.Id.ToString() }).ToList();
                coursesList = courses.Select(x => new SelectListItem { Text = x.Description, Value = x.Id.ToString() }).ToList();
                return;
            }

            try
            {
                studentCourseService.InsertStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentCourses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
