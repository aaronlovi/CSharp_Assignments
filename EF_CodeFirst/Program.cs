namespace EF_CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var ctx = new SchoolContext();

            var grade8a = new Grade() {
                GradeName = "Grade 8A",
                Section = "A",
                Students = new List<Student>()
            };

            var student = new Student()
            {
                StudentName = "Bill",
                DateOfBirth = new DateTime(1991, 1, 1),
                Grade = grade8a,
                Height = 5.9M,
                Photo = new byte[5] { 1, 2, 3, 4, 5 },
                Weight = 65.5F
            };

            grade8a.Students.Add(student);
            
            ctx.Grades.Add(grade8a);
            ctx.Students.Add(student);

            ctx.SaveChanges();

            Console.WriteLine("Student saved successfully.");
            Console.ReadLine();
        }
    }
}
