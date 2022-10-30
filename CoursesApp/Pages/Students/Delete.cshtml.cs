using CoursesApp.DAO.StudentDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using CoursesApp.Service;

namespace CoursesApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService studentService;

        internal string errorMessage = string.Empty;

        public DeleteModel()
        {
            studentService = new StudentServiceImpl(studentDAO);
        }

        
        public void OnGet()
        {

            try
            {
                Student? student;
                StudentDTO studentDTO = new StudentDTO();
                int id = int.Parse(Request.Query["id"]);

                studentDTO.Id = id;
                student = studentService.DeleteStudent(studentDTO);
                Response.Redirect("/Students/Index/");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }
    }
}
