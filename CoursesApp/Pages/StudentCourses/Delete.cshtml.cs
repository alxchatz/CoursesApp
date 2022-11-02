using CoursesApp.DAO.StudentCourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using CoursesApp.Service;

namespace CoursesApp.Pages.StudentCourses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService studentCourseService;

        internal string errorMessage = string.Empty;

        public DeleteModel()
        {
            studentCourseService = new StudentCourseServiceImpl(studentCourseDAO);
        }

        
        public void OnGet()
        {

            try
            {
                StudentCourse? studentCourse;
                StudentCourseDTO studentCourseDTO = new StudentCourseDTO();
                int studentId = int.Parse(Request.Query["studentId"]);
                int courseId = int.Parse(Request.Query["courseId"]);

                studentCourseDTO.StudentId = studentId;
                studentCourseDTO.CourseId = courseId;
                studentCourse = studentCourseService.DeleteStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentCourses/Index/");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }
    }
}
