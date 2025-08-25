using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Prompt for weight
        decimal weight = ReadPositiveDecimal("Please enter the package weight:");
        if (weight > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }

        // Prompt for width, height, length (in this order)
        decimal width  = ReadPositiveDecimal("Please enter the package width:");
        decimal height = ReadPositiveDecimal("Please enter the package height:");
        decimal length = ReadPositiveDecimal("Please enter the package length:");

        // Dimension sum check
        if ((width + height + length) > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }

        // Quote: (height * width * length * weight) / 100
        decimal quote = (height * width * length * weight) / 100m;

        // Display as US dollar amount with two decimals
        string formatted = quote.ToString("C", CultureInfo.GetCultureInfo("en-US"));
        Console.WriteLine($"Your estimated total for shipping this package is: {formatted}");
        Console.WriteLine("Thank you!");
    }

    // Reads a positive decimal from the console, re-prompting on invalid input.
    static decimal ReadPositiveDecimal(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value) && value >= 0)
            {
                return value;
            }

            // If parsing fails, gently re-prompt without changing the required text.
            Console.WriteLine("Invalid number. Please try again using digits (e.g., 12.5).");
        }
    }
}
