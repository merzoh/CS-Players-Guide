Console.Title = "Hunting the Manticore";

int distance;
Console.Write("Player 1, how far away from the city do you want to station the Manticore? ");
distance = int.Parse(Console.ReadLine());
while (distance > 100 ||  distance < 0)
{
    Console.Write("Enter a distance between 0 and 100. ");
    distance = int.Parse(Console.ReadLine());
}
Console.Clear();



int cityHealth = 15;
int manticoreHealth = 10;
int round = 1;
int cannonTarget;
Console.WriteLine("Player 2, it is your turn.");
while (cityHealth != 0 && manticoreHealth != 0)
{
    PrintState(round, cityHealth, manticoreHealth);
    cannonTarget = GetTarget();
    Console.ForegroundColor = ConsoleColor.Yellow;
    switch (CheckHit(distance, cannonTarget))
    {
        case 1:
            Console.WriteLine("That round OVERSHOT the target.");
            break;
        case -1:
            Console.WriteLine("That round FELL SHORT of the target");
            break;
        case 0:
            Console.WriteLine("That round was a DIRECT HIT!");
            manticoreHealth -= CalculateDamage(round);
            break;
    }
    if (manticoreHealth < 1)
    {
        Console.Clear();
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        Console.Write("Press any key to exit.");
        Console.ReadKey(true);
        break;
    }
    cityHealth--;
    if (cityHealth == 0)
    {
        Console.Clear();
        Console.WriteLine("The city of Consolas has been destroyed!");
        Console.Write("Press any key to exit.");
        Console.ReadKey(true);
        break;
    }
    round++;
}



static int CheckHit(int ship, int cannon)
{
    if (cannon > ship)
        return 1;
    else if (cannon < ship)
        return -1;
    else return 0;
}
static int GetTarget()
{
    int targetDistance;
    do
    {
        Console.Write("Enter desired cannon range: ");
        targetDistance = int.Parse(Console.ReadLine());
    } while (targetDistance > 100 || targetDistance < 0);
    return targetDistance;
}
static void PrintState(int round, int cityHealth, int manticoreHealth)
{
    Console.WriteLine("------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"The cannon is expected to deal {CalculateDamage(round)} damage this round.");
    Console.ForegroundColor = ConsoleColor.White;
}
static int CalculateDamage(int round)
{
    switch (round % 3, round % 5)
    {
        case (0, 0):
            return 10;
        case (_, 0):
            return 3;
        case (0, _):
            return 3;
        default:
            return 1;
    }
}