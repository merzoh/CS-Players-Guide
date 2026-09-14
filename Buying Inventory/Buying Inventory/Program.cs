Console.Title = "Buying Inventory";
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("The folllowing items are available:");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("1 - Rope\n2 - Torches\n3 - Climbing Equipment\n4 - Clean Water\n5 - Machete\n6 - Canoe\n7 - Food Supplies");
Console.ForegroundColor = ConsoleColor.White;
Console.Write("What number do you want to see the price of? ");
int choice = int.Parse(Console.ReadLine());

switch (choice)
{
    case 1:
        Console.WriteLine("Rope is 10 gold.");
        break;
    case 2:
        Console.WriteLine("Torches are 15 gold.");
        break;
    case 3:
        Console.WriteLine("Climbing equipment is 25 gold.");
        break;
    case 4:
        Console.WriteLine("Clean water is 1 gold.");
        break;
    case 5:
        Console.WriteLine("A machete is 20 gold.");
        break;
    case 6:
        Console.WriteLine("A canoe is 200 gold.");
        break;
    case 7:
        Console.WriteLine("Food supplies are 1 gold.");
        break;
    default:
        Console.WriteLine("You picked something I don't have!");
        break;
}

Console.WriteLine("\n\n\nPress any key to continue.");
Console.ReadKey(true);