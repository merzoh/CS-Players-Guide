namespace RoomCoordinates;

public class Program
{
    static void Main()
    {
        Coordinate room1 = new Coordinate(0, 1);
        Coordinate room2 = new Coordinate(1, 0);
        Coordinate room3 = new Coordinate(1, 1);
        if (((room1.row - room2.row <= 1 && room1.row - room2.row >= -1) && room1.col == room2.col) || ((room1.col - room2.col <= 1 && room1.col - room2.col >= -1) && room1.row == room2.row))
            Console.WriteLine("Rooms 1 and 2 are adjacent to one another");
        if (((room1.row - room3.row <= 1 && room1.row - room3.row >= -1) && room1.col == room3.col) || ((room1.col - room3.col <= 1 && room1.col - room3.col >= -1) && room1.row == room3.row))
            Console.WriteLine("Rooms 1 and 3 are adjacent to one another");
        if (((room2.row - room3.row <= 1 && room2.row - room3.row >= -1) && room2.col == room3.col) || ((room2.col - room3.col <= 1 && room2.col - room3.col >= -1) && room2.row == room3.row))
            Console.WriteLine("Rooms 2 and 3 are adjacent to one another");
    }
}