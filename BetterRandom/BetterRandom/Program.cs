namespace BetterRandom;

public class Program
{
    public static void Main()
    {
        Random rand = Random.Shared;
        ConsoleKeyInfo key = new ConsoleKeyInfo();
        do
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine(rand.BetterDouble());
                    Console.WriteLine(rand.NextString("Up", "Down", "Left", "Right"));
                    Console.WriteLine(rand.CoinToss(.75f));
                    Console.WriteLine();
                }
            }
        }while (key.Key != ConsoleKey.Escape);

    }
}