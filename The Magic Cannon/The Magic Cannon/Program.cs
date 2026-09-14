Console.Title = "The Magic Cannon";

for (int i = 1; i <= 100; i++)
{
    Console.Write($"{i}: ");
    switch (i % 3, i % 5)
    {
        case (0, 0):
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("COMBINATION");
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case (0, _):
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Fire\n");
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case (_, 0):
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Lightning\n");
            Console.ForegroundColor = ConsoleColor.White;
            break;
        default:
            Console.Write("Normal\n");
            break;
    }
}