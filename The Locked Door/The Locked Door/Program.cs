Console.Write("Enter the passcode to unlock the door: ");

Doors door = new Doors(ConsoleHelper.GetPasscode());
while (true)
{
    switch (ConsoleHelper.RequestCommand().ToLower())
    {
        case "open":
            break;
        case "close":
            break;
        case "lock":
            break;
        case "unlock":
            break;
        case "exit":
            Environment.Exit(0);
            break;
        case "change password":
            break;
        default:
            Console.WriteLine("Invalid command. Please try again.");
            break;
    }
}


//ENUM
public enum DoorState
{
    Locked,
    Open,
    Closed
}
//Classes
public class Doors
{
    //Properties
    public DoorState State { get; private set; } = DoorState.Closed;
    private int Passcode { get; set; }

    //Methods
    public void open()
    {

    }
    public void close ()
    {

    }
    public void lockDoor()
    {

    }
    public void unlockDoor(int passcode)
    {

    }
    public void changePassword()
    {

    }
    //Constructors
    public Doors(int passcode)
    {
        Passcode = passcode;
    }

}

public static class ConsoleHelper
{
    public static int GetPasscode()
    {
        int userInput;
        do
        {
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid passcode.");
                Console.Write("Enter the passcode to unlock the door: ");
            }
        } while (userInput < 0 || userInput > 9999);
        return userInput;
    }
    public static string RequestCommand()
    {
        string entry;
        Console.Clear();
        Console.Write("Enter a command (open, close, lock, unlock, change password, exit): ");
        entry = Console.ReadLine();
        if (entry == null)
            entry = "";
        return entry;
    }
}
