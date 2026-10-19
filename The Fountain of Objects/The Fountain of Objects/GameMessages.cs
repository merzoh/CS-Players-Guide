namespace FountainOfObjects;

public record MessageBuilder(string message, ConsoleColor messageColor);
public static class GameMessages
{
    public static readonly MessageBuilder FailedMovement = new("You have ran into a wall. Try moving in another direction.", ConsoleColor.Red);
}