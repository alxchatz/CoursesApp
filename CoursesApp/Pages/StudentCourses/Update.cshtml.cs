using CoursesApp.DAO.StudentCourseDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoursesApp.DAO;
using CoursesApp.DTO;
using CoursesApp.Model;
using CoursesApp.Service;
using static CoursesApp.Validator.Validator;

namespace CoursesApp.Pages.StudentCourses
{
    public class UpdateModel : PageModel
    {

        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService studentCourseService;

        public UpdateModel()
        {
            studentCourseService = new StudentCourseServiceImpl(studentCourseDAO);
        }

        internal StudentCourseDTO studentCourseDTO = new();
        internal string errorMessage = string.Empty;
        public void OnGet()
        {

            try
            {
                StudentCourse? studentCourse;
                int studentId = int.Parse(Request.Query["studentId"]);
                int courseId = int.Parse(Request.Query["courseId"]);

                studentCourse = studentCourseService.GetStudentCourse(studentId, courseId);
                if (studentCourse is not null) studentCourseDTO = ExtractStudentCourseDTO(studentCourse);
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

            StudentCourseDTO currStudentCourseDTO = studentCourseDTO;
                        
            studentCourseDTO.StudentId = int.Parse(Request.Form["studentid"]);
            studentCourseDTO.CourseId = int.Parse(Request.Form["courseid"]);

            //Validate
            errorMessage = ValidateStudentCourse(studentCourseDTO);

            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

            try
            {
                studentCourseService.UpdateStudentCourse(currStudentCourseDTO, studentCourseDTO);
                Response.Redirect("/StudentCourses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private StudentCourseDTO ExtractStudentCourseDTO(StudentCourse studentCourse)
        {
            return new StudentCourseDTO()
            {
                StudentId = studentCourse.StudentId,
                CourseId = studentCourse.CourseId
            };
        }
    }
}
