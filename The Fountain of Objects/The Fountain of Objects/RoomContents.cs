namespace FountainOfObjects;

public record RoomBuilder(
    string description, 
    char roomSymbol,
    ConsoleColor symbolColor,
    ConsoleColor roomMessageColor,
    string message,
    string roomAdjacencyMessage = "",
    Action? OnEnter = null
    );
public static class RoomContents
{
    public static readonly RoomBuilder Fountain = new("Fountain", 'F', ConsoleColor.Blue, ConsoleColor.Blue, "You can hear the faint sound of various objects slowly falling to the ground. The Fountain of Objects is in this room!", "You can hear a drip coming from a nearby.");
    public static readonly RoomBuilder FountainEnabled = new("Fountain", 'F', ConsoleColor.Blue, ConsoleColor.Blue, "The cascade of objects gushing out and crashing against the floor is deafening. The Fountain of Objects is here!", "The rush of objects gushing out is unmistakeable. The Fountain is near.");
    public static readonly RoomBuilder Entrance = new("Entrance", 'E', ConsoleColor.Yellow, ConsoleColor.Yellow, "You are bathed in a warm light from the outside. You're standing at the entrance.", "A faint glimmer of light is coming from nearby.");
    public static readonly RoomBuilder Empty = new("Empty", '*', ConsoleColor.White, ConsoleColor.White, "You see nothing of interest.");
    public static readonly RoomBuilder DeadAmarok = new("Dead amarok", '*', ConsoleColor.White, ConsoleColor.White, "You find the carcass of a dead amorak inside this room. Nice shot!");
    
}