using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_Assignment
{
    // [Previous assignment] 3. Create another class called Employee and have it inherit from the Person class.
    public class Employee : Person, IQuittable
    {
        // [Previous assignment] 4. Implement the SayName() method inside of the Employee class.
        public override void SayName()
        {
            Console.WriteLine("Name: " + FirstName + " " + LastName);
        }

        // 2. Have your Employee class from the previous drill inherit that interface and implement
        // the Quit() method in any way you choose.
        public void Quit()
        {
            Console.WriteLine("I quit!");
        }
    }
}
