namespace Average_Temperature
{
    internal static class Program
    {
        private const string StopWord = "stop";

        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the average temperature calculator. To end the program early, " + "enter the word 'stop' at any point in the program.");
                var high = GetHigh(); 
                var low = GetLow();  
                var averageOfTemperatures = (high + low) / 2;

                Console.WriteLine($"The average temperature is: {averageOfTemperatures}");
                Console.Write("Do you want to calculate another average temperature? (Y/N): ");

                if (AnswerAnother())
                {
                    continue; // Continue to the next iteration
                }
                break; // Exit the loop
            }
        }

        private static int GetHigh()
        {
            int high;
            string? userInput;

            do
            {
                Console.Write("Enter the high of the day: ");
                userInput = Console.ReadLine();

                // Error handling moved outside of if 
                if (string.IsNullOrWhiteSpace(userInput) || userInput.Trim().Equals(StopWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine(userInput?.Trim().ToLower() == StopWord ? "Exiting..." : "Please enter a number: ");
                    if (userInput?.Trim().ToLower() == StopWord)
                    {
                        Environment.Exit(0);
                    }
                }
            } while (!int.TryParse(userInput, out high));
            return high;
        }

        private static int GetLow()
        {
            // This is the same as the GetHigh function and could be refactored.
            int low;
            string? userInput;
            do
            {
                Console.Write("Enter the low of the day: ");
                userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput) || userInput.Trim().Equals(StopWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine(userInput?.Trim().ToLower() == StopWord ? "Exiting..." : "Please enter a number: ");
                    if (userInput?.Trim().ToLower() == StopWord)
                    {
                        Environment.Exit(0);
                    }
                }
            } while (!int.TryParse(userInput, out low));
            return low;
        }

        private static bool AnswerAnother()
        {
            do
            {
                var userInput = Console.ReadLine()?.Trim().ToLower();

                switch (userInput)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("Please enter Yes(Y) or No(N): ");
                        break;
                }
            } while (true); // Loop until valid input is received
        }
    }
}
