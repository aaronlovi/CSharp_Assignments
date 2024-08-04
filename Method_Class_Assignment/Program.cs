namespace Method_Class_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2. instantiate the class.
            MyClass myClass = new MyClass();

            // 3. Call the method in the class, passing in two numbers
            myClass.MyMethod(5, 10);

            // 4. Call the method in the class, specifying the parameters by name
            myClass.MyMethod(displayParam: 10, mathOperationParam: 5);
        }
    }

    internal class MyClass
    {
        public void MyMethod(int mathOperationParam, int displayParam)
        {
            // 1.a. do a math operation on the first integer
            int result = mathOperationParam * 2;

            // 1.b. display the second integer to the screen
            Console.WriteLine(displayParam);
        }
    }
}
