using CoursesApp.DAO.StudentCourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.Model;
using CoursesApp.Service;
using System.Runtime.CompilerServices;

namespace CoursesApp.Pages.StudentCourses
{
    public class IndexModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService studentCourseService;

        internal List<StudentCourse_Joined> studentCourses = new();

        public IndexModel()
        {
            studentCourseService = new StudentCourseServiceImpl(studentCourseDAO);
        }

        public void OnGet()
        {

            studentCourses = studentCourseService.GetAllStudentCourses();
            //return Page(); //in case the method is void, return is implied
        }

    }
}
