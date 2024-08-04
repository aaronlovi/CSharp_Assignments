namespace Operators_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3.A. In the "Program.cs" file, instantiate two objects of the Employee class
            // and assign values to their properties.
            Employee employee1 = new Employee() { Id = 1001, FirstName = "Edward", LastName = "Jones" };
            Employee employee2 = new Employee() { Id = 2001, FirstName = "Robert", LastName = "Smith" };
            
            // 3.B. Compare the two Employee objects using the newly overloaded operators and display the results.
            bool areEqual = employee1 == employee2;
            Console.WriteLine("Employee 1 and Employee 2 are equal? " + areEqual);
        }
    }

    // 1. Create an Employee class with Id, FirstName and LastName properties.
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // 2. In the Employee class, overload the “==” operator so it checks if two Employee objects
        // are equal by comparing their Id property.
        // Remember that comparison operators must be overloaded in pairs.
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            return employee1.Id == employee2.Id;
        }

        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return employee1.Id != employee2.Id;
        }
    }
}
