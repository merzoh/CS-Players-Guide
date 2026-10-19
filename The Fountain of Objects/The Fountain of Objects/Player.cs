using System.Drawing;

namespace FountainOfObjects;

public class Player
{
    public Point PlayerPosition { get; private set; }
    public bool Alive { get; private set; }

    public Player(Point startPoint)
    {
        PlayerPosition = startPoint;
        Alive = true;
    }
    public bool Move(int x, int y, int gameSize)
    {
        if ((PlayerPosition.X + x < 0 || PlayerPosition.X + x > gameSize) || (PlayerPosition.Y + y < 0 || PlayerPosition.Y + y > gameSize))
        {
            return false;
        }
        PlayerPosition = new Point(PlayerPosition.X + x, PlayerPosition.Y + y);
        return true;
    }
    public void KillPlayer()
    {
        Alive = false;
    }
}