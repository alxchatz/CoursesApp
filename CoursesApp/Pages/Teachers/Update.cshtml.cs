using CoursesApp.DAO.TeacherDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;

namespace CoursesApp.Pages.Teachers
{
    public class UpdateModel : PageModel
    {

        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService teacherService;

        public UpdateModel()
        {
            teacherService = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDTO = new();
        internal string errorMessage = string.Empty;
        public void OnGet()
        {

            try
            {
                Teacher? teacher;
                int id = int.Parse(Request.Query["id"]);

                teacher = teacherService.GetTeacher(id);
                if (teacher is not null) teacherDTO = ExtractTeacherDTO(teacher);
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
            teacherDTO.Id = int.Parse(Request.Form["id"]);
            teacherDTO.Firstname = Request.Form["firstname"];
            teacherDTO.Lastname = Request.Form["lastname"];

            //Validate
            errorMessage = ValidateTeacher(teacherDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

            try
            {
                teacherService.UpdateTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private TeacherDTO ExtractTeacherDTO(Teacher teacher)
        {
            return new TeacherDTO()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname
            };
        }
    }
}
