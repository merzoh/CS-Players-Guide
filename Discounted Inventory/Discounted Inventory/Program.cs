Console.Title = "Discounted Inventory";
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("The folllowing items are available:");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("1 - Rope\n2 - Torches\n3 - Climbing Equipment\n4 - Clean Water\n5 - Machete\n6 - Canoe\n7 - Food Supplies");
Console.ForegroundColor = ConsoleColor.White;
Console.Write("What number do you want to see the price of? ");
int choice = int.Parse(Console.ReadLine());
Console.Write("What is your name? ");
string name = Console.ReadLine();

switch (choice)
{
    case 1:
        if (name != "Michael")
            Console.WriteLine("Rope is 10 gold.");
        else
            Console.WriteLine("Rope is 5 gold.");
        break;
    case 2:
        if (name != "Michael")
            Console.WriteLine("Torches are 15 gold.");
        else
            Console.WriteLine("Torches are 8 gold.");
        break;
    case 3:
        if (name != "Michael")
            Console.WriteLine("Climbing equipment is 25 gold.");
        else
            Console.WriteLine("Climbing equipment is 13 gold.");
        break;
    case 4:
        Console.WriteLine("Clean water is 1 gold.");
        break;
    case 5:
        if (name != "Michael")
            Console.WriteLine("A machete is 20 gold.");
        else
            Console.WriteLine("A machete is 10 gold.");
        break;
    case 6:
        if (name != "Michael")
            Console.WriteLine("A canoe is 200 gold.");
        else
            Console.WriteLine("a canoe is 100 gold.");
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