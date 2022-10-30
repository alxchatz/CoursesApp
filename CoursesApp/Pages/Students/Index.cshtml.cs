using CoursesApp.DAO.StudentDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.Model;
using CoursesApp.Service;
using System.Runtime.CompilerServices;

namespace CoursesApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService studentService;

        internal List<Student> students = new();

        public IndexModel()
        {
            studentService = new StudentServiceImpl(studentDAO);
        }

        public void OnGet()
        {

            students = studentService.GetAllStudents();
            //return Page(); //in case the method is void, return is implied
        }

    }
}
