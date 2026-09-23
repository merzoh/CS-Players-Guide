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



    //Methods
    public void StartGame()
    {
        while (true)
        {
            MenuManager<GameStartOptions> startManager = new MenuManager<GameStartOptions>();
            GameStartOptions firstPlayer = startManager.Run("Which player should go first?");
            Run(firstPlayer.ToString());

        }

    }

    private void Run(string firstPlayer)
    {
        bool running = true;
        bool playerHasWon = false;
        string playerTurn = "Player X's turn!";
        if (firstPlayer == GameStartOptions.PlayerO.ToString())
        {
            IsPlayerXTurn = false;
            playerTurn = "Player Y's turn!";
        }
            
        DrawBoard();

        while (running)
        {
            if (IsPlayerXTurn)
            {
                bool selected;
                Console.SetCursorPosition((Console.WindowWidth / 2) - playerTurn.Length, 2);
                Console.Write(playerTurn);
                do
                {
                    selected = playerX.GetSelection(board);
                } while (!selected);
                IsPlayerXTurn = false;
                MovesMade++;
                playerTurn = "Player Y's turn!";
            }
            else
            {
                bool selected;
                Console.SetCursorPosition((Console.WindowWidth / 2) - playerTurn.Length, 2);
                Console.Write(playerTurn);
                do
                {
                    selected = playerO.GetSelection(board);
                } while (!selected);
                IsPlayerXTurn = true;
                MovesMade++;
                playerTurn = "Player X's turn!";
            }
            playerHasWon = CheckWinConditions();
            if (!playerHasWon && MovesMade == 9)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - ("Draw".Length) / 2, 2);
                Console.Write("Draw");
                Console.ReadKey(true);
                MenuManager<GameContinueOptions> continueManager = new MenuManager<GameContinueOptions>();
                GameContinueOptions continueChoice = continueManager.Run("Would you like to play again?");
                if (continueChoice != GameContinueOptions.Yes)
                    Environment.Exit(0);
                else
                    running = false;
            }
            else if (playerHasWon)
            {
                Console.ReadKey(true);
                MenuManager<GameContinueOptions> continueManager = new MenuManager<GameContinueOptions>();
                GameContinueOptions continueChoice = continueManager.Run("Would you like to play again?");
                if (continueChoice != GameContinueOptions.Yes)
                    Environment.Exit(0);
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
        TileOptions tile1, tile2, tile3;
        string winningPlayer;
        (int c1, int r1, int c2, int r2, int c3, int r3)[] winConditions = { (0,0, 0,1, 0,2), (1,0, 1,1, 1,2), (2,0, 2,1, 2,2), 
        (0,0, 1,0, 2,0), (1,1, 2,1, 2,2), (0,2, 1,2, 2,2), (0,0, 1,1, 2,2), (0,2, 1,1, 2,0)};

        foreach (var condition in winConditions)
        {
            TileOptions mark = board[condition.r1, condition.c1].PlayerMarking;
            if (mark != TileOptions.Empty && mark == board[condition.r2, condition.c2].PlayerMarking && mark == board[condition.r3, condition.c3].PlayerMarking)
            {
                winningPlayer = $"Player {mark.ToString()} wins!";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (winningPlayer.Length) / 2, 2);
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
    private void DrawBoard()
    {
        Console.Clear();
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
