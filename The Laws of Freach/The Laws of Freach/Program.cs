Console.Title = "The Laws of Freach";

int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
int currentSmallest = int.MaxValue;
int total = 0;
foreach (int num in array)
{
    if (num < currentSmallest)
    {
        currentSmallest = num;
    }
    total += num;
}
Console.WriteLine(currentSmallest.ToString());
float average = (float)total / (float)array.Length;
Console.WriteLine(average.ToString());