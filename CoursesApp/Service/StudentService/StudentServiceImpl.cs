using CoursesApp.DAO.StudentDAO;
using CoursesApp.DTO;
using CoursesApp.Model;

namespace CoursesApp.Service
{
    public class StudentServiceImpl : IStudentService
    {

        private readonly IStudentDAO studentDAO;

        public StudentServiceImpl(IStudentDAO studentDAO)
        {
            this.studentDAO = studentDAO;
        }

        public Student? DeleteStudent(StudentDTO studentDTO)
        {
            if (studentDTO is null) return null;

            try
            {
                Student? student = ExtractStudent(studentDTO);

                return studentDAO.Delete(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                return studentDAO.GetAll();
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student>();
            }
        }

        public Student? GetStudent(int id)
        {
            try
            {
                return studentDAO.GetStudent(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertStudent(StudentDTO studentDTO)
        {
            if (studentDTO is null) return;

            try
            {
                Student? student = ExtractStudent(studentDTO);

                studentDAO.Insert(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            if (studentDTO is null) return;

            try
            {
                Student? student = ExtractStudent(studentDTO);

                studentDAO.Update(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Student? ExtractStudent(StudentDTO studentDTO)
        {
            if (studentDTO is null) return null;

            Student student = new Student()
            {
                Id = studentDTO.Id,
                Firstname = studentDTO.Firstname,
                Lastname = studentDTO.Lastname
            };

            return student;
        }
    }
}
