using CoursesApp.DTO;
using CoursesApp.Model;

namespace CoursesApp.Service
{
    public interface ITeacherService
    {

        List<Teacher> GetAllTeachers();
        void InsertTeacher(TeacherDTO teacherDTO);
        void UpdateTeacher(TeacherDTO teacherDTO);
        Teacher? DeleteTeacher(TeacherDTO teacherDTO);
        Teacher? GetTeacher(int id);

    }
}
