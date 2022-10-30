using CoursesApp.DAO.TeacherDAO;
using CoursesApp.DTO;
using CoursesApp.Model;

namespace CoursesApp.Service
{
    public class TeacherServiceImpl : ITeacherService
    {

        private readonly ITeacherDAO teacherDAO;

        public TeacherServiceImpl(ITeacherDAO teacherDAO)
        {
            this.teacherDAO = teacherDAO;
        }

        public Teacher? DeleteTeacher(TeacherDTO teacherDTO)
        {
            if (teacherDTO is null) return null;

            try
            {
                Teacher? Teacher = ExtractTeacher(teacherDTO);

                return teacherDAO.Delete(Teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                return teacherDAO.GetAll();
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Teacher>();
            }
        }

        public Teacher? GetTeacher(int id)
        {
            try
            {
                return teacherDAO.GetTeacher(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertTeacher(TeacherDTO teacherDTO)
        {
            if (teacherDTO is null) return;

            try
            {
                Teacher? Teacher = ExtractTeacher(teacherDTO);

                teacherDAO.Insert(Teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateTeacher(TeacherDTO teacherDTO)
        {
            if (teacherDTO is null) return;

            try
            {
                Teacher? Teacher = ExtractTeacher(teacherDTO);

                teacherDAO.Update(Teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Teacher? ExtractTeacher(TeacherDTO teacherDTO)
        {
            if (teacherDTO is null) return null;

            Teacher Teacher = new Teacher()
            {
                Id = teacherDTO.Id,
                Firstname = teacherDTO.Firstname,
                Lastname = teacherDTO.Lastname
            };

            return Teacher;
        }
    }
}
