using ConsoleUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe;

internal class Player
{
    
    public int WinCount { get; private set; }
    public TileOptions PlayerMark { get; }
    public string PlayerName { get; private set; }
    public void SetName(string prompt)
    {
        
        do
        {
            PlayerName = ConsoleHelpers.GetInput(prompt);
        } while (PlayerName == string.Empty);
        

    }
    public void UpdateWins() => WinCount++;
    public bool GetSelection(GameBoard[,] board)
    {
        Console.SetCursorPosition(board[0, 0].TilePosition.x - 2, board[0, 0].TilePosition.y);
        Console.Write('>');
        Console.SetCursorPosition(board[0, 0].TilePosition.x + 2, board[0, 0].TilePosition.y);
        Console.Write('<');

        (int x, int y) selectedIndex = (0, 0);

        ConsoleKeyInfo keyInfo = default;
        do
        {
            keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedIndex.y != 0)
                    {
                        SelectionRender.Update(board[selectedIndex.x, selectedIndex.y], board[selectedIndex.x, selectedIndex.y - 1]);
                        selectedIndex.y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedIndex.y != 2)
                    {
                        SelectionRender.Update(board[selectedIndex.x, selectedIndex.y], board[selectedIndex.x, selectedIndex.y + 1]);
                        selectedIndex.y++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (selectedIndex.x != 2)
                    {
                        SelectionRender.Update(board[selectedIndex.x, selectedIndex.y], board[selectedIndex.x + 1, selectedIndex.y]);
                        selectedIndex.x++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (selectedIndex.x != 0)
                    {
                        SelectionRender.Update(board[selectedIndex.x, selectedIndex.y], board[selectedIndex.x - 1, selectedIndex.y]);
                        selectedIndex.x--;
                    }
                    break;
                default:
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Enter);
        if (board[selectedIndex.x, selectedIndex.y].PlayerMarking == TileOptions.Empty)
        {
            board[selectedIndex.x, selectedIndex.y].SetMarker(PlayerMark);
            Console.SetCursorPosition(board[selectedIndex.x, selectedIndex.y].TilePosition.x, board[selectedIndex.x, selectedIndex.y].TilePosition.y);
            if (PlayerMark == TileOptions.X)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(board[selectedIndex.x, selectedIndex.y].PlayerMarking.ToString());
            Console.ResetColor();
            Console.SetCursorPosition(board[selectedIndex.x, selectedIndex.y].TilePosition.x - 2, board[selectedIndex.x, selectedIndex.y].TilePosition.y);
            Console.Write(" ");
            Console.SetCursorPosition(board[selectedIndex.x, selectedIndex.y].TilePosition.x + 2, board[selectedIndex.x, selectedIndex.y].TilePosition.y);
            Console.Write(" ");
            return true;
        }
        else
        {
            Console.SetCursorPosition(board[selectedIndex.x, selectedIndex.y].TilePosition.x - 2, board[selectedIndex.x, selectedIndex.y].TilePosition.y);
            Console.Write(" ");
            Console.SetCursorPosition(board[selectedIndex.x, selectedIndex.y].TilePosition.x + 2, board[selectedIndex.x, selectedIndex.y].TilePosition.y);
            Console.Write(" ");
            return false;
        }
    }
    public Player(TileOptions playerMark)
    {
        PlayerMark = playerMark;
        SetName($"Enter a name for Player {this.PlayerMark}: ");
    }
}
