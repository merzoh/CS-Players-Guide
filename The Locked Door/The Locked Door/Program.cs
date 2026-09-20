using ConsoleUtil;
namespace The_Locked_Door;
class Program
{
    static void Main()
    {
        Doors door = new Doors();
        door.Run();
        
    }
}
//Classes
public class Doors
{
    //Properties and Fields
    private DoorStates State { get; set; } = DoorStates.Closed;
    private int Passcode { get; set; }
    private MenuManager<DoorOptions> manager;

    //Methods
    private int GetPasscode(string text)
    {
        int userInput;
        do
        {
            ConsoleHelpers.DrawWindow(text);
            while (!int.TryParse(ConsoleHelpers.ReadMaskedKey(), out userInput))
            {
                ConsoleHelpers.DrawWindow("Invalid input. Please enter a valid passcode.");
                Console.SetCursorPosition((Console.WindowWidth / 2) - 2, (int)(Console.WindowHeight * (2f / 3f)));
            }
        } while (userInput < 0 || userInput > 9999);
        return userInput;
    }
    private void Open()
    {
        switch (State)
        {
            case DoorStates.Locked:
                ConsoleHelpers.DrawWindow("The door is locked. Please unlock it first.  Press any key to continue.");
                Console.ReadKey(true);
                break;
            case DoorStates.Closed:
                State = DoorStates.Open;
                break;
            
        }
    }
    private void Close ()
    {
        if (State == DoorStates.Open)
        {
            State = DoorStates.Closed;
        }
    }
    private void LockDoor()
    {
        if (State == DoorStates.Closed)
        {
            State = DoorStates.Locked;
        }
    }
    private void UnlockDoor()
    {
        if (State == DoorStates.Locked)
        {
            if ((VerifyPasscode(GetPasscode("Enter the passcode to unlock the door: "))))
            {
                State = DoorStates.Closed;
                ConsoleHelpers.DrawWindow("The door has been unlocked. Press any key to continue.");
                Console.ReadKey(true);
            }
            else
            {
                ConsoleHelpers.DrawWindow("Incorrect passcode. The door remains locked. Press any key to continue.");
                Console.ReadKey(true);
            }
        }
    }
    private bool ChangePassword()
    {
        if (VerifyPasscode(GetPasscode("Enter the current passcode: ")))
        {
            Passcode = GetPasscode("Enter the new passcode: ");
            return true;
        }
        else
            return false;
        
        
    }
    private bool VerifyPasscode(int userEntry) => userEntry == Passcode;

    public void Run()
    {
        while (true)
        {
            switch (manager.Run($"The door is currently {State.ToString().ToLower()}. Pick an option."))
            {
                case DoorOptions.Open:
                    Open();
                    break;
                case DoorOptions.Close:
                    Close();
                    break;
                case DoorOptions.Lock:
                    LockDoor();
                    break;
                case DoorOptions.Unlock:
                    UnlockDoor();
                    break;
                case DoorOptions.Exit:
                    Environment.Exit(0);
                    break;
                case DoorOptions.ChangePassword:
                    if (ChangePassword())
                    {
                        ConsoleHelpers.DrawWindow("Passcode changed successfully. Press any key to continue.");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        ConsoleHelpers.DrawWindow("Incorrect passcode. Passcode change failed. Press any key to continue.");
                        Console.ReadKey(true);
                    }
                    break;
            }
        }
    }
    //Constructors
    public Doors()
    {
        manager = new MenuManager<DoorOptions>();
        Passcode = GetPasscode("Enter the initial passcode: ");
    }


}