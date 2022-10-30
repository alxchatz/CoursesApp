namespace CoursesApp.Model
{
    public class Course
    {

        public int Id { get; set; }
        public string? Description { get; set; }
        public int? TeacherId { get; set; }
        public string? TeacherFullName { get; set; }

    }
}
