using CoursesApp.DAO.StudentDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;

namespace CoursesApp.Pages.Students
{
    public class UpdateModel : PageModel
    {

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService studentService;

        public UpdateModel()
        {
            studentService = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = string.Empty;
        public void OnGet()
        {

            try
            {
                Student? student;
                int id = int.Parse(Request.Query["id"]);

                student = studentService.GetStudent(id);
                if (student is not null) studentDTO = ExtractStudentDTO(student);
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
            studentDTO.Id = int.Parse(Request.Form["id"]);
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            //Validate
            errorMessage = ValidateStudent(studentDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

            try
            {
                studentService.UpdateStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private StudentDTO ExtractStudentDTO(Student student)
        {
            return new StudentDTO()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
        }
    }
}
