using CoursesApp.DAO.TeacherDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using CoursesApp.Service;

namespace CoursesApp.Pages.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService teacherService;

        internal string errorMessage = string.Empty;

        public DeleteModel()
        {
            teacherService = new TeacherServiceImpl(teacherDAO);
        }

        
        public void OnGet()
        {

            try
            {
                Teacher? teacher;
                TeacherDTO teacherDTO = new TeacherDTO();
                int id = int.Parse(Request.Query["Id"]);

                teacherDTO.Id = id;
                teacher = teacherService.DeleteTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index/");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }
    }
}
