Console.Title = "Countdown";

Countdown(AskForNumber("Give me a number to count down from: "));
int AskForNumber(string text)
{
    Console.Write(text);
    int answer = int.Parse(Console.ReadLine());
    if (answer <= 0)
        AskForNumber(text);
    return answer;
}
int Countdown(int num)
{
    Console.WriteLine(num);
    if (num > 0)
        Countdown(num - 1);
    return 0;
}