using ConsoleUtilities;
namespace TheSieve;

public class Sieve
{
    Func<int, bool> sieveFunc; 
    public Sieve(Func<int, bool> func)
    {
        this.sieveFunc = func;
    }

    public void Run()
    {
        string input = string.Empty;
        while (true)
        {
            input = ConsoleUtility.GetInput("Enter a number to test (or type 'exit' to quit):");
            if (input.ToLower() == "exit")
            {
                ConsoleUtility.PrintCenteredMessage("Exiting the sieve program.", Console.WindowHeight / 2, ConsoleColor.Yellow);
                break;
            }
            
            if (int.TryParse(input, out int number))
            {
                if (sieveFunc(number))
                {
                    ConsoleUtility.PrintCenteredMessage($" {number} passes the test. Press any key to continue...", Console.WindowHeight / 2, ConsoleColor.Green);
                    Console.ReadKey(true);
                }
                else
                {
                    ConsoleUtility.PrintCenteredMessage($" {number} does not pass the test. Press any key to continue...", Console.WindowHeight / 2, ConsoleColor.Red);
                    Console.ReadKey(true);
                }
            }
            else
            {
                ConsoleUtility.PrintCenteredMessage("Invalid input. Please enter a valid integer. Press any key to continue...", Console.WindowHeight / 2, ConsoleColor.Yellow);
                Console.ReadKey(true);
            }
        }
    }

}