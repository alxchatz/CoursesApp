using CoursesApp.DAO.TeacherDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.Model;
using CoursesApp.Service;
using System.Runtime.CompilerServices;

namespace CoursesApp.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService teacherService;

        internal List<Teacher> teachers = new();

        public IndexModel()
        {
            teacherService = new TeacherServiceImpl(teacherDAO);
        }

        public void OnGet()
        {

            teachers = teacherService.GetAllTeachers();
            //return Page(); //in case the method is void, return is implied
        }

    }
}
