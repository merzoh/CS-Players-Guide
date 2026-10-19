using System.Drawing;

namespace FountainOfObjects;

public static class MapRender
{
    
    private static readonly int _cellWidth = 4;
    public static readonly int _cellHeight = 3;
    public static readonly string continueText = "Press any key to continue...";
    public static void DrawMap(Rooms[,] map, Point playerPosition, int gameSize)
    {
        Point _anchor = new((Console.WindowWidth / 2) - (((gameSize / 2) * _cellWidth) + 1), (Console.WindowHeight / 2) - ((gameSize / 2) * _cellHeight) - 1);
        int limit = gameSize - 1;
        Console.Clear();
        
        for (int i = 0; i < gameSize; i++)
        {
            for (int j = 0; j < gameSize; j++)
            {
                
                Console.SetCursorPosition(_anchor.X + (j * _cellWidth), _anchor.Y + (i * _cellHeight) - i);
                switch (i, j)
                {
                    case (0, 0):
                        DrawTLCornerBox();
                        break;
                    case var (r, c) when r == 0 && c == limit:
                        DrawTRCornerBox();
                        break;
                    case var (r, c) when r == limit && c == 0:
                        DrawBLCornerBox(i);
                        break;
                    case var (r, c) when r == limit && c == limit:
                        DrawBRCornerBox(i);
                        break;
                    case var (_, c) when c == limit:
                        DrawRightEdgeBox(i);
                        break;
                    case var (r, _) when r == 0:
                        DrawTopEdgeBox();
                        break;
                    case var (_, c) when c == 0:
                        DrawLeftEdgeBox(i);
                        break;
                    case var (r, _) when r == limit:
                        DrawBottomEdgeBox(i);
                        break;
                    case (_, _):
                        DrawInnerBox(i);
                        break;
                }
                RenderRoomSymbol(map[i, j], playerPosition, new Point(j, i));
                
            }
        }
        Console.SetCursorPosition((Console.WindowWidth - continueText.Length) / 2, Console.WindowHeight - 2);
        Console.Write(continueText);

    }
    public static void RenderRoomSymbol(Rooms room, Point playerPosition, Point currentIndex)
    {
        if (playerPosition == currentIndex)
        {
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('P');
            Console.ResetColor();
        }
        else if (!room.HasVisited)
        {
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write('?');
            Console.ResetColor();
        }
        else
        {
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop - 1);
            Console.ForegroundColor = room.Contents.symbolColor;
            Console.Write(room.Contents.roomSymbol);
            Console.ResetColor();
        }
    }
    public static void DrawTLCornerBox()
    {
        Console.Write(MapSymbols.TopLeft + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TeeTop);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.TeeLeft + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Cross);
    }
    public static void DrawTRCornerBox()
    {
        Console.Write(MapSymbols.TeeTop + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TopRight);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Cross + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TeeRight);
    }
    public static void DrawTopEdgeBox()
    {
        Console.Write(MapSymbols.TeeTop + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TeeTop);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Cross + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Cross);
    }
    public static void DrawBLCornerBox(int col)
    {
        
        Console.Write(MapSymbols.TeeLeft + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Cross);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.BottomLeft + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TeeBottom);
       
    }
    public static void DrawBRCornerBox(int col)
    {
        
        Console.Write(MapSymbols.Cross + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TeeRight);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.TeeBottom + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.BottomRight);
        
    }
    public static void DrawInnerBox(int col)
    {
        
        Console.Write(MapSymbols.Cross + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Cross);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Cross + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Cross);
    }
    public static void DrawLeftEdgeBox(int col)
    {
       
        Console.Write(MapSymbols.TeeLeft + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Cross);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.TeeLeft + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Cross);
    }
    public static void DrawRightEdgeBox(int col)
    {
       
        Console.Write(MapSymbols.Cross + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TeeRight);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Cross + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TeeRight);
    }
    
    public static void DrawBottomEdgeBox(int col)
    {
        
        Console.Write(MapSymbols.Cross + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Cross);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.Vertical + "   " + MapSymbols.Vertical);
        Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop + 1);
        Console.Write(MapSymbols.TeeBottom + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.Horizontal + MapSymbols.TeeBottom);
        
        
    }
}
public static class MapSymbols
{
    public const string TopLeft = "\u250C";     // ┌
    public const string TopRight = "\u2510";    // ┐
    public const string BottomLeft = "\u2514";  // └
    public const string BottomRight = "\u2518"; // ┘
    public const string Horizontal = "\u2500";  // ─
    public const string Vertical = "\u2502";    // │
    public const string TeeTop = "\u252C";      // ┬
    public const string TeeBottom = "\u2534";   // ┴
    public const string TeeLeft = "\u251C";     // ├
    public const string TeeRight = "\u2524";    // ┤
    public const string Cross = "\u253C";       // ┼
}