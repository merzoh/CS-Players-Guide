using GameExceptions;
using ConsoleUtilities;

namespace ExceptisGame;

public class Game
{
    private int oatmealCookiePos;
    private int _playerTurn = 0;
    private Cookie[] cookies = new Cookie[10];
    public Game()
    {
        oatmealCookiePos = Random.Shared.Next(0, 10);
        for (int i = 0; i < 10; i++)
        {
            cookies[i] = new Cookie(i == oatmealCookiePos);
        }
    }
    public void Start()
    {
        while (true)
        {
            bool turnTaken = false;
            do
            {
                int playerInput = TakeTurn();
                try
                {
                    if (cookies[playerInput].IsOatmealCookie)
                        throw new OatmealCookieEatenException();
                    cookies[playerInput].Eat();
                    turnTaken = true;

                }
                catch (OatmealCookieEatenException)
                {
                    ConsoleUtility.PrintCenteredMessage($"Player {_playerTurn + 1} ate the oatmeal cookie and loses! Press any key to exit...", (int)(Console.WindowHeight * (1f / 3f)) + 1);
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
                catch (CookieEatenException)
                {
                    ConsoleUtility.PrintCenteredMessage($"Player {_playerTurn + 1} tried to eat a cookie that was already eaten. Please try again. Press any key to continue...", (int)(Console.WindowHeight * (1f / 3f)) + 1);
                    Console.ReadKey();
                }
            } while (!turnTaken);
            
            if (_playerTurn == 0)
                _playerTurn++;
            else
                _playerTurn--;
        }
        
    }
    private int TakeTurn()
    {
        int input = -1;
        do
        {
            try
            {
                if (!int.TryParse(ConsoleUtility.GetInput($"Player {_playerTurn + 1}, enter a number between 0 and 9: "), out input))
                    throw new InvalidInputTypeException("Invalid input. Please enter only a number! Press any key to continue...");
                if (input < 0 || input > 9)
                    throw new InvalidInputException("Invalid input. Please enter a number between 0 and 9. Press any key to continue...");
            }
            catch (Exception ex)
            {
                HandleInvalidInput(ref input, ex);
            }

        } while (input == -1);
        return input;
    }
    private void HandleInvalidInput(ref int input, Exception e)
    {
        ConsoleUtility.PrintCenteredMessage(e.Message, (int)(Console.WindowHeight * (1f / 3f)) + 1);
        Console.ReadKey();
        input = -1;
    }
}