namespace FountainOfObjects;


public class Program
{
    
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GameState game = new();
        game.run();
    }
}