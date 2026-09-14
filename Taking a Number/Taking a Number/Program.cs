Console.Title = "Taking a Number";

int AskForNumber(string text)
{
    Console.Write(text);
    return int.Parse(Console.ReadLine());
}

int AskForNumberInRange(string text, int min, int max)
{
    int num;
    do
    {
        Console.Write(text);
        num = int.Parse(Console.ReadLine());

    } while (num > max || num < min);
    return num;
}

