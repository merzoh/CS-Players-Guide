Console.Title = "The Replicator of D'To";

Console.Clear();
Console.WriteLine("Enter 5 Numbers");

int[] firstArray = new int[5];
for (int i = 0; i < 5; i ++)
{
    Console.Write($"{i + 1}: ");
    firstArray[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Press any key to process");
Console.ReadKey(true);
Console.Clear();

int[] secondArray = new int[5];
for (int i = 0; i < 5; i++)
{
    secondArray[i] = firstArray[i];
}

Console.WriteLine("Arrays");
for (int i  = 0; i < 5; i++)
{
    Console.WriteLine($"Array One: {firstArray[i]}  Array Two: {secondArray[i]}");
}
Console.Write("Press any key to continue...");
Console.ReadKey(true);