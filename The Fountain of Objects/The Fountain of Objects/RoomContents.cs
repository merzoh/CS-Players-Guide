namespace FountainOfObjects;

public record RoomBuilder(string description, string symbol, ConsoleColor color, string message);
public static class RoomContents
{
    public static readonly RoomBuilder Fountain = new("Fountain", "F", ConsoleColor.Blue, "You can hear the faint drip of water. The Fountain of Objects is in this room!");
    public static readonly RoomBuilder Entrance = new("Entrance", "E", ConsoleColor.Yellow, "You see light pouring in from the entrance of the cave.");
    public static readonly RoomBuilder Empty = new("Empty", " ", ConsoleColor.White, "You see nothing of interest.");
}