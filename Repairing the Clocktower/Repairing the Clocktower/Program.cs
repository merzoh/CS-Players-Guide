int num;
Console.Write("Enter a number: ");
num = int.Parse(Console.ReadLine());
if (num % 2 == 1)
    Console.WriteLine("Tock");
else
    Console.WriteLine("Tick");