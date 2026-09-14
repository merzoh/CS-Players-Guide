using System.Data;
Console.Title = "Defense of Consolas";
int row, col = 0;
Console.ForegroundColor = ConsoleColor.Green;
do
{
    Console.Write("Target Row? ");
    row = int.Parse(Console.ReadLine());
} while (row > 8 || row < 0);
do
{
    Console.Write("Traget Column? ");
    col = int.Parse(Console.ReadLine());
} while (col > 8 || col < 0);

Console.ForegroundColor = ConsoleColor.Red; //Switch text colors to red for deployment instructions.
Console.WriteLine($"\nDeploy to:\n({row + 1}, {col})\n({row}, {col - 1})\n({row}, {col + 1})\n({row - 1} , {col})");
Console.Beep();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Press any key to exit");
Console.ReadKey(true);
Console.Clear();