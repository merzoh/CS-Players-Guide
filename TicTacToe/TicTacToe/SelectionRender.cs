using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    internal static class SelectionRender
    {
        public static void Update(GameBoard tileOld, GameBoard tileNew)
        {
            Console.SetCursorPosition(tileOld.TilePosition.x - 2, tileOld.TilePosition.y);
            Console.Write(" ");
            Console.SetCursorPosition(tileOld.TilePosition.x + 2, tileOld.TilePosition.y);
            Console.Write(" ");
            Console.SetCursorPosition(tileNew.TilePosition.x - 2, tileNew.TilePosition.y);
            Console.Write(">");
            Console.SetCursorPosition(tileNew.TilePosition.x + 2, tileNew.TilePosition.y);
            Console.Write("<");
        }
    }
}
