namespace Lambda_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2. In the Main() method, create a list of at least 10 employees.
            // At least two employees should have the first name “Joe”.
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Joe", LastName = "Smith" },
                new Employee { Id = 2, FirstName = "Joe", LastName = "Johnson" },
                new Employee { Id = 3, FirstName = "John", LastName = "Doe" },
                new Employee { Id = 4, FirstName = "Jane", LastName = "Doe" },
                new Employee { Id = 5, FirstName = "Jack", LastName = "Smith" },
                new Employee { Id = 6, FirstName = "Jill", LastName = "Johnson" },
                new Employee { Id = 7, FirstName = "Jim", LastName = "Smith" },
                new Employee { Id = 8, FirstName = "Jenny", LastName = "Johnson" },
                new Employee { Id = 9, FirstName = "Jill", LastName = "Smith" },
                new Employee { Id = 10, FirstName = "Joe", LastName = "Doe" }
            };

            // 3. Using a foreach loop, create a new list of all employees with the first name “Joe”.
            // In your comparison statement, remember to reference the property of the object you are checking.
            List<Employee> joes = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.FirstName == "Joe")
                {
                    joes.Add(employee);
                }
            }

            // 4. Perform the same action again, but this time with a lambda expression.
            List<Employee> joesLambda = employees.Where(e => e.FirstName == "Joe").ToList();

            // 5. Using a lambda expression, make a list of all employees with an Id number greater than 5.
            List<Employee> greaterThanFive = employees.Where(e => e.Id > 5).ToList();
        }
    }

    // 1. Create an Employee class with the following properties: Id, First Name, Last Name
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
