namespace Polymorphism_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3. Use polymorphism to create an object of type IQuittable
            // and call the Quit() method on it.
            // Hint: an object can be of an interface type if it implements that specific interface.
            IQuittable quittable = new Employee();
            quittable.Quit();
        }
    }
}
