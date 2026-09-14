Console.Write("X: ");
int x = int.Parse(Console.ReadLine());
Console.Write("Y: ");
int y  = int.Parse(Console.ReadLine());

if (x == 0)
{
    if (y > 0)
        Console.WriteLine("The enemy is to the north!");
    else if (y == 0)
        Console.WriteLine("The enemy is here!");
    else if (y < 0)
        Console.WriteLine("The enemy is to the south!");
}
else if (x < 0)
{
    if (y > 0)
        Console.WriteLine("The enemy is to the northwest!");
    else if (y == 0)
        Console.WriteLine("The enemy is to the west!");
    else if (y < 0)
        Console.WriteLine("The enemy is to the southwest!");
}
else
{
    if (y > 0)
        Console.WriteLine("The enemy is to the northeast!");
    else if (y == 0)
        Console.WriteLine("The enemy is to the east!");
    else if (y < 0)
        Console.WriteLine("The enemy is to the southeast!");
}
