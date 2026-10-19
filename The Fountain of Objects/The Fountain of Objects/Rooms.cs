using System.Drawing;

namespace FountainOfObjects;

public class Rooms
{
    public bool HasVisited { get; private set; } = false;
    public RoomBuilder Contents { get; private set; }
    public Rooms()
    {
        HasVisited = false;
        Contents = RoomContents.Empty;
    }
    public Rooms(RoomBuilder contents)
    {
        Contents = contents;

    }
    public void VisitRoom()
    {
        HasVisited = true;
    }
    public void SetContent(RoomBuilder contents)
    {
        Contents = contents;
    }
}