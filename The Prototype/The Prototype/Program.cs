Console.Title = "The Prototype";

int num;
int guess;
do
{
    Console.Write("User 1, enter a number between 0 and 100: ");
    num = int.Parse(Console.ReadLine());
    Console.Clear();
}
while (num < 0 || num > 100);

Console.Write("User 2, guess the number. ");
guess = int.Parse(Console.ReadLine());
while (guess != num)
{
    if (guess > num)
        Console.Write($"{guess} is too high.");
    else
        Console.Write($"{guess} is too low.");
    Console.Write("What is your next guess? ");
    guess = int.Parse(Console.ReadLine());
}
Console.WriteLine("You guess the number!");

Console.WriteLine("\n\n\nPress any key to continue...");
Console.ReadKey(true);
Console.Clear();