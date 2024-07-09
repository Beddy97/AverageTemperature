using System;

namespace ImprovedAverageTemperature
{
    internal static class Program
    {
        private const string StopWord = "stop";

        private static void Main()
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("Welcome to the average temperature calculator.");
                Console.WriteLine($"To end the program early, enter '{StopWord}' at any point.");

                if (TryGetTemperatures(out double high, out double low))
                {
                    double average = CalculateAverage(high, low);
                    Console.WriteLine($"The average temperature is: {average:F1}°C");
                }

                continueProgram = PromptToContinue();
            }

            Console.WriteLine("Thank you for using the average temperature calculator. Goodbye!");
        }

        private static bool TryGetTemperatures(out double high, out double low)
        {
            high = GetTemperature("high");
            if (double.IsNaN(high)) return false;

            low = GetTemperature("low");
            if (double.IsNaN(low)) return false;

            if (low > high)
            {
                Console.WriteLine("Error: The low temperature cannot be higher than the high temperature.");
                return false;
            }

            return true;
        }

        private static double GetTemperature(string highOrLow)
        {
            while (true)
            {
                Console.Write($"Enter the {highOrLow} temperature of the day (°C): ");
                string? input = Console.ReadLine()?.Trim();

                if (string.Equals(input, StopWord, StringComparison.OrdinalIgnoreCase))
                {
                    return double.NaN; // Signal to exit
                }

                if (double.TryParse(input, out double temperature))
                {
                    return temperature;
                }

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        private static double CalculateAverage(double high, double low)
        {
            return (high + low) / 2;
        }

        private static bool PromptToContinue()
        {
            while (true)
            {
                Console.Write("Do you want to calculate another average temperature? (Y/N): ");
                string? response = Console.ReadLine()?.Trim().ToLower();

                switch (response)
                {
                    case "y":
                    case "yes":
                        return true;
                    case "n":
                    case "no":
                        return false;
                    default:
                        Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
                        break;
                }
            }
        }
    }
}