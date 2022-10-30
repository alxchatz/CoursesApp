using CoursesApp.DAO.StudentDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DTO;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;

namespace CoursesApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService studentService;

        public CreateModel()
        {
            studentService = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = string.Empty;

        public void OnGet()
        {

        }

        public void OnPost()
        {
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            errorMessage = ValidateStudent(studentDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

            try
            {
                studentService.InsertStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
