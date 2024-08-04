using System.Drawing;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharp_Assignments;

internal class Program {
    static void Main(string[] args) {
        // The first line of the program must be: “Welcome to Package Express. Please follow the instructions below.”
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // The user must then be prompted for the package weight.
        Console.WriteLine("Please enter the package weight: ");
        string? weightText = Console.ReadLine();
        bool res = decimal.TryParse(weightText, out decimal weight);

        // If the weight is greater than 50, display the error message,
        // "Package too heavy to be shipped via Package Express.Have a good day."
        // At this point the program would end.
        if (!res || weight > 50m)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }

        // The user must then be prompted for the package width.
        Console.WriteLine("Please enter the package width: ");
        string? widthText = Console.ReadLine();

        // Then the package height.
        Console.WriteLine("Please enter the package height: ");
        string? heightText = Console.ReadLine();

        // Then the package length.
        Console.WriteLine("Please enter the package length: ");
        string? lengthText = Console.ReadLine();

        // If the dimensions total greater than 50, display the error message,
        // "Package too big to be shipped via Package Express."
        // At this point the program would end.
        bool res1 = decimal.TryParse(widthText, out decimal width);
        bool res2 = decimal.TryParse(heightText, out decimal height);
        bool res3 = decimal.TryParse(lengthText, out decimal length);
        if (!res1 || !res2 || !res3 || width + height + length > 50) {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }

        // Next, multiply the three dimensions (height, width, & length) together,
        // and multiply the product by the weight.
        // Finally, divide the outcome by 100.
        // The result of that calculation is the quote.
        decimal quote = height * width * length * weight / 100m;

        // Display the quote to the user as a dollar amount.
        string quoteString = string.Format("Your estimated total for shipping this package is: ${0:F2}", quote);
        Console.WriteLine(quoteString);
    }
}
