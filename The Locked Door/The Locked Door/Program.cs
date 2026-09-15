Doors door = new Doors(ConsoleHelper.GetPasscode("Enter the initial passcode: "));
Console.Clear();
while (true)
{
    switch (ConsoleHelper.RequestCommand().ToLower())
    {
        case "open":
            door.Open();
            break;
        case "close":
            door.Close();
            break;
        case "lock":
            door.LockDoor();
            break;
        case "unlock":
            door.UnlockDoor();
            break;
        case "exit":
            Environment.Exit(0);
            break;
        case "change password":
            if (door.ChangePassword())
            {
                Console.WriteLine("Passcode changed successfully.");
                Console.Write("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Incorrect passcode. Passcode change failed.");
            }
            break;
        case "clear screen":
            Console.Clear();
            break;
        case "status":
            Console.WriteLine($"The door is currently {door.State.ToString().ToLower()}.");
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
    public void Open()
    {
        switch (State)
        {
            case DoorState.Locked:
                Console.WriteLine("The door is locked. Please unlock it first.");
                break;
            case DoorState.Closed:
                State = DoorState.Open;
                Console.WriteLine("The door is now open.");
                break;
            case DoorState.Open:
                Console.WriteLine("The door is already open.");
                break;
        }
    }
    public void Close ()
    {
        switch (State)
        {
            case DoorState.Locked:
                Console.WriteLine("The door is already closed.");
                break;
            case DoorState.Closed:
                Console.WriteLine("The door is already closed.");
                break;
            case DoorState.Open:
                State = DoorState.Closed;
                Console.WriteLine("The door is now closed.");
                break;
        }
    }
    public void LockDoor()
    {
        switch (State)
        {
            case DoorState.Locked:
                Console.WriteLine("the door is already locked.");
                break;
            case DoorState.Closed:
                State = DoorState.Locked;
                Console.WriteLine("The door is now locked.");
                break;
            case DoorState.Open:
                Console.WriteLine("Please close the door before locking it.");
                break;
        }
    }
    public void UnlockDoor()
    {
        switch (State)
        {
            case DoorState.Locked:
                if ((VerifyPasscode(ConsoleHelper.GetPasscode("Enter the passcode to unlock the door: "))))
                {
                    State = DoorState.Closed;
                    Console.WriteLine("The door is now unlocked.");
                }
                else
                {
                    Console.WriteLine("Incorrect passcode. The door remains locked.");
                }
                break;
            case DoorState.Closed:
                Console.WriteLine("The door is already unlocked.");
                break;
            case DoorState.Open:
                Console.WriteLine("The door is already unlocked.");
                break;
        }
    }
    public bool ChangePassword()
    {
        if (VerifyPasscode(ConsoleHelper.GetPasscode("Enter the current passcode: ")))
        {
            Console.WriteLine("You may now change the passcode.");
            Passcode = ConsoleHelper.GetPasscode("Enter the new passcode: ");
            return true;
        }
        else
            return false;
        
        
    }
    public bool VerifyPasscode(int userEntry) => userEntry == Passcode;
    //Constructors
    public Doors(int passcode)
    {
        Passcode = passcode;
    }

}

public static class ConsoleHelper
{
    public static int GetPasscode(string text)
    {
        int userInput;
        do
        {
            Console.Write(text);
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid passcode.");
                Console.Write(text);
            }
        } while (userInput < 0 || userInput > 9999);
        return userInput;
    }
    public static string RequestCommand()
    {
        string entry;
        Console.Write("Enter a command (open, close, lock, unlock, change password, status, clear screen, exit): ");
        entry = Console.ReadLine();
        if (entry == null)
            entry = "";
        return entry;
    }
}