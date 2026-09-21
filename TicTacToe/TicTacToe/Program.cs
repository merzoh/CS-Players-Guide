namespace TicTacToe;
class TicTacToe
{
    static void Main()
    {
        GameManager manager = new GameManager();
        manager.Run();
        Console.ReadKey(true);
    }
}