using CoursesApp.DTO;

namespace CoursesApp.Validator
{
    public class Validator
    {
        //No instances of this class should be available.
        private Validator() { }

        public static string ValidateStudent(StudentDTO? studentDTO)
        {
            if (studentDTO is null || studentDTO.Firstname is null || studentDTO.Lastname is null)
            {
                return "Something is null";
            }


            if (studentDTO.Firstname.Length < 4 || studentDTO.Lastname.Length < 4)
            {
                return "Firstname or Lastname is less than 4 characters.";
            }

            return String.Empty;
        }

        public static string ValidateTeacher(TeacherDTO? teacherDTO)
        {
            if (teacherDTO is null || teacherDTO.Firstname is null || teacherDTO.Lastname is null)
            {
                return "Something is null";
            }


            if (teacherDTO.Firstname.Length < 4 || teacherDTO.Lastname.Length < 4)
            {
                return "Firstname or Lastname is less than 4 characters.";
            }

            return String.Empty;
        }

        public static string ValidateCourse(CourseDTO? courseDTO)
        {
            if (courseDTO is null || courseDTO.Description is null || courseDTO.TeacherId is null)
            {
                return "Something is null";
            }


            if (courseDTO.Description.Length < 4)
            {
                return "Course description is less than 4 characters.";
            }

            return String.Empty;
        }

        public static string ValidateStudentCourse(StudentCourseDTO? studentCourseDTO)
        {
            if (studentCourseDTO is null || studentCourseDTO.StudentId is null || studentCourseDTO.CourseId is null)
            {
                return "Something is null";
            }

            return String.Empty;
        }

    }
}
