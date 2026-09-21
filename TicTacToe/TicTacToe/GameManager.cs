using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
    public void Run()
    {
        bool running = true;
        bool playerHasWon = false;
        DrawBoard();
        while (running)
        {
            if (IsPlayerXTurn)
            {
                bool selected;
                do
                {
                    selected = playerX.GetSelection(board);
                } while (!selected);
                IsPlayerXTurn = false;
                MovesMade++;
            }
            else
            {
                bool selected;
                do
                {
                    selected = playerO.GetSelection(board);
                } while (!selected);
                IsPlayerXTurn = true;
                MovesMade++;
            }
            playerHasWon = CheckWinConditions();
            if (!playerHasWon && MovesMade == 9)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - ("Draw".Length) / 2, 2);
                Console.Write("Draw");
                Console.ReadKey(true);
                running = false;
            }
            else if (playerHasWon)
            {
                Console.ReadKey(true);
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
        //Win Con 1
        tile1 = board[0, 0].PlayerMarking;
        tile2 = board[0, 1].PlayerMarking;
        tile3 = board[0, 2].PlayerMarking;
        if (tile1 == tile2 && tile2 == tile3)
        {
            if (tile2 != TileOptions.Empty)
            {
                winningPlayer = $"Player {tile1.ToString()} wins!";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (winningPlayer.Length) / 2, 2);
                Console.Write(winningPlayer);
                return true;
            }
        }
        //Win Con 2
        tile1 = board[1, 0].PlayerMarking;
        tile2 = board[1, 1].PlayerMarking;
        tile3 = board[1, 2].PlayerMarking;
        if (tile1 == tile2 && tile2 == tile3)
        {
            if (tile2 != TileOptions.Empty)
            {
                winningPlayer = $"Player {tile1.ToString()} wins!";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (winningPlayer.Length) / 2, 2);
                Console.Write(winningPlayer);
                return true;
            }
        }
        //Win Con 3
        tile1 = board[2, 0].PlayerMarking;
        tile2 = board[2, 1].PlayerMarking;
        tile3 = board[2, 2].PlayerMarking;
        if (tile1 == tile2 && tile2 == tile3)
        {
            if (tile2 != TileOptions.Empty)
            {
                winningPlayer = $"Player {tile1.ToString()} wins!";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (winningPlayer.Length) / 2, 2);
                Console.Write(winningPlayer);
                return true;
            }
        }
        //Win Con 4
        tile1 = board[0, 0].PlayerMarking;
        tile2 = board[1, 0].PlayerMarking;
        tile3 = board[2, 0].PlayerMarking;
        if (tile1 == tile2 && tile2 == tile3)
        {
            if (tile2 != TileOptions.Empty)
            {
                winningPlayer = $"Player {tile1.ToString()} wins!";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (winningPlayer.Length) / 2, 2);
                Console.Write(winningPlayer);
                return true;
            }
        }
        //Win Con 5
        tile1 = board[0, 1].PlayerMarking;
        tile2 = board[1, 1].PlayerMarking;
        tile3 = board[2, 1].PlayerMarking;
        if (tile1 == tile2 && tile2 == tile3)
        {
            if (tile2 != TileOptions.Empty)
            {
                winningPlayer = $"Player {tile1.ToString()} wins!";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (winningPlayer.Length) / 2, 2);
                Console.Write(winningPlayer);
                return true;
            }
        }
        //Win Con 6
        tile1 = board[0, 2].PlayerMarking;
        tile2 = board[1, 2].PlayerMarking;
        tile3 = board[2, 2].PlayerMarking;
        if (tile1 == tile2 && tile2 == tile3)
        {
            if (tile2 != TileOptions.Empty)
            {
                winningPlayer = $"Player {tile1.ToString()} wins!";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (winningPlayer.Length) / 2, 2);
                Console.Write(winningPlayer);
                return true;
            }
        }
        //Win Con 7
        tile1 = board[0, 0].PlayerMarking;
        tile2 = board[1, 1].PlayerMarking;
        tile3 = board[2, 2].PlayerMarking;
        if (tile1 == tile2 && tile2 == tile3)
            if (tile1 == tile2 && tile2 == tile3)
            {
                if (tile2 != TileOptions.Empty)
                {
                    winningPlayer = $"Player {tile1.ToString()} wins!";
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (winningPlayer.Length) / 2, 2);
                    Console.Write(winningPlayer);
                    return true;
                }
            }
        //Win Con 8
        tile1 = board[0, 2].PlayerMarking;
        tile2 = board[1, 1].PlayerMarking;
        tile3 = board[2, 0].PlayerMarking;
        if (tile1 == tile2 && tile2 == tile3)
        {
            if (tile2 != TileOptions.Empty)
            {
                winningPlayer = $"Player {tile1.ToString()} wins!";
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
