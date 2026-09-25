using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using ConsoleUtil;
namespace TicTacToe;

internal class GameManager
{
    //Properties and Fields
    private GameBoard[,] board = new GameBoard[3,3];
    private Player playerX = new Player(TileOptions.X);
    private Player playerO = new Player(TileOptions.O);
    private int WindowHeight { get; set; }
    private int WindowWidth { get; set; }
    private bool IsPlayerXTurn { get; set; } = true;
    private int MovesMade { get; set; } = 0;
    private int Draws { get; set; } = 0;
    private GameStartOptions FirstPlayer { get; set; }
    private bool FirstRun { get; set; } = true;
    private bool XStartedFirstLast { get; set; }



    //Methods
    public void StartGame()
    {
        MenuManager<GameStartOptions> startManager = new MenuManager<GameStartOptions>();
        FirstPlayer = startManager.Run("Which player should go first?");
        switch (FirstPlayer)
        {
            case GameStartOptions.O:
                IsPlayerXTurn = false;
                break;
            default:
                break;
        } while (true)
        {
            if (FirstPlayer == GameStartOptions.Alternating)
            {
                if (FirstRun)
                {
                    if (FirstPlayer == GameStartOptions.X)
                        XStartedFirstLast = true;
                    else
                        XStartedFirstLast = false;
                }
                else
                {
                    if (XStartedFirstLast == true)
                    {
                        IsPlayerXTurn = false;
                        XStartedFirstLast = false;
                    }
                    else
                    {
                        IsPlayerXTurn = true;
                        XStartedFirstLast = true;
                    }
                }
            }
            
            Run();
            ResetGame();
        }

    }
    private void ResetGame()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                board[x, y].SetMarker(TileOptions.Empty);
            }
        }
        MovesMade = 0;
    }

    private void Run()
    {
        bool running = true;
        bool playerHasWon = false;
        string playerTurn;
        
        if (!IsPlayerXTurn)
            playerTurn = $"{playerO.PlayerName}'s turn!";
        else
            playerTurn = $"{playerX.PlayerName}'s turn!";
        

        DrawBoard();

        while (running)
        {
            if (IsPlayerXTurn)
            {
                bool selected;
                Console.SetCursorPosition(0, board[1, 2].TilePosition.y + 4);
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition((Console.WindowWidth - playerTurn.Length) / 2, board[1, 2].TilePosition.y + 4);
                Console.Write(playerTurn);
                do
                {
                    selected = playerX.GetSelection(board);
                } while (!selected);
                IsPlayerXTurn = false;
                MovesMade++;
                playerTurn = $"{playerO.PlayerName}'s turn!";
            }
            else
            {
                bool selected;
                Console.SetCursorPosition(0, board[1, 2].TilePosition.y + 4);
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition((Console.WindowWidth - playerTurn.Length) / 2, board[1, 2].TilePosition.y + 4);
                Console.Write(playerTurn);
                do
                {
                    selected = playerO.GetSelection(board);
                } while (!selected);
                IsPlayerXTurn = true;
                MovesMade++;
                playerTurn = $"{playerX.PlayerName}'s turn!";
            }
            playerHasWon = CheckWinConditions();
            if (!playerHasWon && MovesMade == 9)
            {
                Console.SetCursorPosition(0, 2);
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition((Console.WindowWidth - "Draw".Length) / 2, board[1, 2].TilePosition.y + 4);
                Console.Write("Draw");
                Draws++;
                Console.ReadKey(true);
                MenuManager<GameContinueOptions> continueManager = new MenuManager<GameContinueOptions>();
                GameContinueOptions continueChoice = continueManager.Run("Would you like to play again?");
                if (continueChoice != GameContinueOptions.Yes)
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                    running = false;
            }
            else if (playerHasWon)
            {
                Console.ReadKey(true);
                MenuManager<GameContinueOptions> continueManager = new MenuManager<GameContinueOptions>();
                GameContinueOptions continueChoice = continueManager.Run("Would you like to play again?");
                if (continueChoice != GameContinueOptions.Yes)
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                    running = false;
            }
        }
    }
    //Constructor
    public GameManager()
    {
        Console.SetWindowSize(180, 50);
        Console.SetBufferSize(180, 50);
        WindowHeight = Console.WindowHeight;
        WindowWidth = Console.WindowWidth;
        UpdateBoardPositions();
        

    }
    private bool CheckWinConditions()
    {
        string winningPlayer;
        (int c1, int r1, int c2, int r2, int c3, int r3)[] winConditions = 
            { (0,0, 0,1, 0,2), (1,0, 1,1, 1,2), (2,0, 2,1, 2,2), //Vertical
            (0,0, 1,0, 2,0), (0,1, 1,1, 2,1), (0,2, 1,2, 2,2),   //Horizontal
            (0,0, 1,1, 2,2), (2,0, 1,1, 0,2)};                   //Diagonal

        foreach (var condition in winConditions)
        {
            TileOptions mark = board[condition.c1, condition.r1].PlayerMarking;
            if (mark != TileOptions.Empty && mark == board[condition.c2, condition.r2].PlayerMarking && mark == board[condition.c3, condition.r3].PlayerMarking)
            {
                if (mark == TileOptions.X)
                {
                    winningPlayer = $"{playerX.PlayerName} wins!";
                    playerX.UpdateWins();
                }
                else
                {
                    winningPlayer = $"{playerO.PlayerName} wins!";
                    playerO.UpdateWins();
                }
                Console.SetCursorPosition(0, board[1, 2].TilePosition.y + 4);
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition((Console.WindowWidth - winningPlayer.Length) / 2, board[1, 2].TilePosition.y + 4);
                Console.Write(winningPlayer);
                return true;
            }
        }
        return false;
    }
    private void UpdateBoardPositions()
    {
        (int x, int y) anchor = ((WindowWidth / 2) - 9, (WindowHeight / 2) - 4);
        int cellWidth = 7;
        int cellHeight = 3;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                board[x, y] = new GameBoard();
                board[x, y].SetPosition(anchor.x + (cellWidth + 1) * x, anchor.y + (cellHeight + 1) * y);
            }
        }
    }
    private void DrawWinCounter()
    {
        string playerDrawPlayer = $"{playerX.PlayerName} - Draws - {playerO.PlayerName}";
        string winCount = $"{playerX.WinCount} - {Draws} - {playerO.WinCount}";
        Console.SetCursorPosition(0, board[1, 0].TilePosition.y - 5);
        Console.Write(new string(' ', Console.WindowWidth - 1));
        Console.SetCursorPosition(0, board[1, 0].TilePosition.y - 4);
        Console.Write(new string(' ', Console.WindowWidth - 1));
        Console.SetCursorPosition((Console.WindowWidth - playerDrawPlayer.Length) / 2, board[1,0].TilePosition.y - 5);
        Console.Write(playerDrawPlayer);
        Console.SetCursorPosition((Console.WindowWidth - winCount.Length) / 2, board[1, 0].TilePosition.y - 4);
        Console.Write(winCount);
    }
    private void DrawBoard()
    {
        Console.Clear();
        DrawWinCounter();
        (int x, int y) centerPos = (WindowWidth / 2, WindowHeight / 2);
        for (int i = 0; i < 11; i++)
        {
            Console.SetCursorPosition(centerPos.x - 12, centerPos.y - 5 + i);
            if (i == 3 || i == 7)
            {
                Console.Write("-------+-------+-------");
            }
            else
                Console.Write("       |       |");
        }
        Console.CursorVisible = false;
        
    }

}
