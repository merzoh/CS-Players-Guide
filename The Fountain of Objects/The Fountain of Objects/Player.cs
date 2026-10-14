using System.Drawing;

namespace FountainOfObjects;

public class Player
{
    public Point PlayerPosition { get; private set; }

    public Player()
    {
        PlayerPosition = new Point(0, 0);
    }
    public bool Move(int x, int y)
    {
        if ((PlayerPosition.X + x < 0 || PlayerPosition.X + x > 3) || (PlayerPosition.Y + y < 0 || PlayerPosition.Y + y > 3))
        {
            return false;
        }
        PlayerPosition = new Point(PlayerPosition.X + x, PlayerPosition.Y + y);
        return true;
    }
}