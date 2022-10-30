using CoursesApp.Model;

namespace CoursesApp.DAO.TeacherDAO
{
    public interface ITeacherDAO
    {

        void Insert(Teacher? Teacher);
        void Update(Teacher? Teacher);
        Teacher? Delete(Teacher? Teacher);
        Teacher? GetTeacher(int id);
        List<Teacher> GetAll();

    }
}
