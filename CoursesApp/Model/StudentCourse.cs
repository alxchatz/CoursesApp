namespace CoursesApp.Model
{
    public class StudentCourse
    {

        public int StudentId { get; set; }
        public int CourseId { get; set; }

    }

    public class StudentCourse_Joined : StudentCourse
    {

        public string? StudentFirstname { get; set; }
        public string? StudentLastName { get; set; }
        public string? CourseDescription { get; set; }

    }
}
