using CoursesApp.DTO;
using CoursesApp.Model;

namespace CoursesApp.Service
{
    public interface IStudentService
    {

        List<Student> GetAllStudents();
        void InsertStudent(StudentDTO studentDTO);
        void UpdateStudent(StudentDTO studentDTO);
        Student? DeleteStudent(StudentDTO studentDTO);
        Student? GetStudent(int id);

    }
}
