namespace FountainOfObjects;

public class Rooms
{
    public bool HasVisited { get; private set; }
    public RoomBuilder Contents { get; private set; }
    public Rooms()
    {
        HasVisited = false;
        Contents = RoomContents.Empty;
    }
    public Rooms(RoomBuilder contents)
    {
        HasVisited = false;
        Contents = contents;
    }

}