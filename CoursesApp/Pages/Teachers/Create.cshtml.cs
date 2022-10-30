using CoursesApp.DAO.TeacherDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DTO;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoursesApp.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService teacherService;

        public CreateModel()
        {
            teacherService = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDTO = new();
        internal string errorMessage = string.Empty;

        public void OnGet()
        {

        }

        public void OnPost()
        {
            teacherDTO.Firstname = Request.Form["firstname"];
            teacherDTO.Lastname = Request.Form["lastname"];

            errorMessage = ValidateTeacher(teacherDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

            try
            {
                teacherService.InsertTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
