using CoursesApp.DAO.StudentCourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DTO;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;

namespace CoursesApp.Pages.StudentCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService studentCourseService;

        public CreateModel()
        {
            studentCourseService = new StudentCourseServiceImpl(studentCourseDAO);
        }

        internal StudentCourseDTO studentCourseDTO = new();
        internal string errorMessage = string.Empty;

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Request.Form["studentid"])) studentCourseDTO.StudentId = int.Parse(Request.Form["studentid"]);
            if (!string.IsNullOrEmpty(Request.Form["courseid"])) studentCourseDTO.CourseId = int.Parse(Request.Form["courseid"]);

            errorMessage = ValidateStudentCourse(studentCourseDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

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
