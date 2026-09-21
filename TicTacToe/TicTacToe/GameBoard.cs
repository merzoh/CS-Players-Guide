using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TicTacToe;

internal class GameBoard
{
    public TileOptions PlayerMarking { get; private set; } = TileOptions.Empty;
    public (int x, int y) TilePosition { get; private set; }
    public void SetPosition(int x, int y) => TilePosition = (x, y);
    public void SetMarker(TileOptions playerMark) => PlayerMarking = playerMark;
}
