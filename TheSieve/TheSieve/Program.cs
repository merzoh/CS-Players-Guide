using MenuManagerUtility;
namespace TheSieve;

public class Program
{
    
    public static void Main(string[] args)
    {
        
        Sieve sieve = null;
        List<MenuItem> menuItems = new List<MenuItem>
        {
            new MenuItem("Even Numbers", () => sieve = new Sieve(IsEven)),
            new MenuItem("Positive Numbers", () => sieve = new Sieve(IsPositive)),
            new MenuItem("Multiples of 10", () => sieve = new Sieve(IsMultipleOfTen))
        };
        var selection = new MenuManager().Run(menuItems, "pick a sieve option:");
        selection.Execute?.Invoke();
        sieve?.Run();


    }
    private static bool IsEven(int number)
    {
        return number % 2 == 0;
    }
    private static bool IsPositive(int number)
    {
        return number > 0;
    }
    private static bool IsMultipleOfTen(int number)
    {
        return number % 10 == 0;
    }
}